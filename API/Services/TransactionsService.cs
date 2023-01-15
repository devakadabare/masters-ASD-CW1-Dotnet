using API.Data;
using API.DTO;
using API.Entities;
using API.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class TransactionsService: ITransactionService
    {
        private readonly StoreContext _context;

        public TransactionsService(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();

        }

        public async Task<Transaction?> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            return transaction;
        }

        public async Task<Transaction> CreateTransaction(TransactionCreateDTO transaction){

            switch (transaction.type)
            {
                case Enum.TransactionType.Expense:
                    var newExpense = new Expense
                    {
                        amout = transaction.amout,
                        note = transaction.note,
                        date = transaction.date,
                        account = await _context.Accounts.FindAsync(transaction.accountId),
                        category = await _context.Categories.FindAsync(transaction.categoryId) ?? null,
                        creditDebitIndicator = Enum.CreditDebitIndicator.Debit
                    };
                    _context.Transactions.Add(newExpense);
                     await _context.SaveChangesAsync();
                    return newExpense;

                case Enum.TransactionType.Income:
                    var newIncome = new Income
                    {
                        amout = transaction.amout,
                        note = transaction.note,
                        date = transaction.date,
                        account = await _context.Accounts.FindAsync(transaction.accountId),
                        category = await _context.Categories.FindAsync(transaction.categoryId) ?? null,
                        creditDebitIndicator = Enum.CreditDebitIndicator.Credit
                    };
                    _context.Transactions.Add(newIncome);
                     await _context.SaveChangesAsync();
                    return newIncome;
                    
                case Enum.TransactionType.Transfer:
                    var newTransfer = new Transfer
                    {
                        amout = transaction.amout,
                        note = transaction.note,
                        date = transaction.date,
                        account = await _context.Accounts.FindAsync(transaction.accountId),
                        category = await _context.Categories.FindAsync(transaction.categoryId) ?? null,
                        creditDebitIndicator = Enum.CreditDebitIndicator.Credit
                    };

                    var newTransfer2 = new Transfer
                    {
                        amout = transaction.amout,
                        note = transaction.note,
                        date = transaction.date,
                        account = await _context.Accounts.FindAsync(transaction.transferAccountId),
                        category = await _context.Categories.FindAsync(transaction.categoryId) ?? null,
                        creditDebitIndicator = Enum.CreditDebitIndicator.Debit
                    };

                    _context.Transactions.Add(newTransfer);
                    _context.Transactions.Add(newTransfer2);
                    await _context.SaveChangesAsync(); //save changes to database
                    return newTransfer;
                default:
                    return null;
            }    
          
        }

        public async Task<Transaction> UpdateTransaction(int id, TransactionDTO transaction)
        {
            var updateTransaction = await GetTransaction(id);
            if(updateTransaction == null)
            {
                return null;
            }
            updateTransaction.amout = transaction.amout;
            updateTransaction.note = transaction.note;
            updateTransaction.date = transaction.date;
            updateTransaction.type = (Enum.TransactionType)transaction.type;
            updateTransaction.category = await _context.Categories.FindAsync(transaction.categoryId);
            updateTransaction.account = await _context.Accounts.FindAsync(transaction.accountId) ;

            _context.Transactions.Update(updateTransaction);
            await _context.SaveChangesAsync();
            return updateTransaction;
        }
    }
}