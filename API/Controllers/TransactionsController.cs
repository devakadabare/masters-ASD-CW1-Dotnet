using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController: ControllerBase
    {
        private readonly StoreContext _context;
        public TransactionsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> GetTransactions()
        {
            return await _context.Transactions.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            return Ok(transaction);
        }


        [HttpPost("create")]
        public async Task<ActionResult<Transaction>> CreateTransaction(TransactionDTO transaction)
        {
            
            if(transaction == null)
            {
                return BadRequest();
            }

            //if transaction type is income
            if(transaction.type == Enum.TransactionType.Income)
            {
                var account = await _context.Accounts.FindAsync(transaction.accountId);
                
                if(account == null || account.balance < transaction.amout)
                {
                    return BadRequest();
                }

                account.balance += transaction.amout;
                _context.Accounts.Update(account);
            }
            //if transaction type is expense
            else if (transaction.type == Enum.TransactionType.Expense)
            {
                var account = await _context.Accounts.FindAsync(transaction.accountId);
                if(account == null || account.balance < transaction.amout)
                {
                    return BadRequest();
                }
                account.balance -= transaction.amout;
                _context.Accounts.Update(account);
            }
            //if transaction type is transfer
            else if(transaction.type == Enum.TransactionType.Transfer)
            {
                //check if account has enough money
                var account = await _context.Accounts.FindAsync(transaction.accountId);
                if(account == null || account.balance < transaction.amout )
                {
                    return BadRequest();
                }
                //update account balance
                account.balance -= transaction.amout;
                
                //check if transfer account has enough money
                var account2 = await _context.Accounts.FindAsync(transaction.transferAccountId);
                if(account2 == null || account2.balance < transaction.amout)
                {
                    return BadRequest();
                }
                //update transfer account balance
                account2.balance += transaction.amout;

                _context.Accounts.Update(account);
                _context.Accounts.Update(account2);
            }
            else
            {
                return BadRequest();
            }
            
            //create transaction
            var newTransaction = new Transaction
            {
                amout = transaction.amout,
                note = transaction.note,
                date = transaction.date,
                type = (Enum.TransactionType)transaction.type,
                categoryId = transaction.categoryId,
                accountId = (int)transaction.accountId,
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
                    categoryId = transaction.categoryId,
                    accountId = (int)transaction.transferAccountId
                };
                _context.Transactions.Add(transaction2);
            }

            await _context.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Transaction>> UpdateTransaction(int id, TransactionDTO transaction)
        {
            var updateTransaction = await _context.Transactions.FindAsync(id);
            
            if(updateTransaction == null)
            {
                return NotFound();
            }
            updateTransaction.amout = transaction.amout;
            updateTransaction.note = transaction.note;
            updateTransaction.date = transaction.date;
            updateTransaction.type = (Enum.TransactionType)transaction.type;
            updateTransaction.categoryId = transaction.categoryId;
            updateTransaction.accountId = (int)transaction.accountId;

            _context.Transactions.Update(updateTransaction);
            await _context.SaveChangesAsync();
            return Ok(updateTransaction);
        }
    }
}