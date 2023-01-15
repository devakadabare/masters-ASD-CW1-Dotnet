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

            //create transaction
            var newTransaction = new Transaction
            {
                amout = transaction.amout,
                note = transaction.note,
                date = transaction.date,
                type = (Enum.TransactionType)transaction.type,
                account = await _context.Accounts.FindAsync(transaction.accountId),
                category = await _context.Categories.FindAsync(transaction.categoryId) ?? null,
                creditDebitIndicator = transaction.type == Enum.TransactionType.Income ? Enum.CreditDebitIndicator.Credit : Enum.CreditDebitIndicator.Debit
            };
            var result = _context.Transactions.Add(newTransaction);

            //if transaction type is transfer, create another transaction
            if(transaction.type == Enum.TransactionType.Transfer && transaction.transferAccountId != null)
            {
                var transaction2 = new Transaction
                {
                    amout = transaction.amout,
                    note = transaction.note,
                    date = transaction.date,
                    type = Enum.TransactionType.Transfer,
                    creditDebitIndicator = Enum.CreditDebitIndicator.Credit,
                    account = await _context.Accounts.FindAsync(transaction.transferAccountId),
                    category = await _context.Categories.FindAsync(transaction.categoryId) ?? null
                };
                _context.Transactions.Add(transaction2);
            }

            await _context.SaveChangesAsync(); //save changes to database

            return newTransaction;
            
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