using API.DTO;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController: ControllerBase
    {
        private readonly TransactionsService _transactionsService;
        private readonly AccountService _accountService;

        
        public TransactionsController(TransactionsService transactionsService, AccountService accountService)
        {
            _transactionsService = transactionsService;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> GetTransactions()
        {
            return await _transactionsService.GetTransactions();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int id)
        {
            var transaction = await _transactionsService.GetTransaction(id);
            return transaction;
        }


        [HttpPost("create")]
        public async Task<ActionResult<Transaction>> CreateTransaction(TransactionCreateDTO transaction)
        {
            
            if(transaction == null)
            {
                return BadRequest();
            }

            //if transaction type is income
            if(transaction.type == Enum.TransactionType.Income)
            {
                // var account = await _context.Accounts.FindAsync(transaction.accountId);
                var account = await _accountService.GetAccount(transaction.accountId);

                
                if(account == null || account.balance < transaction.amout)
                {
                    return BadRequest();
                }

                account.balance += transaction.amout;
                var newAccount = new AccountDTO
                {
                    name = account.name,
                    description = account.description,
                    balance = account.balance,
                    status = account.status
                };
                await _accountService.UpdateAccount(account.id, newAccount);
            }
            //if transaction type is expense
            else if (transaction.type == Enum.TransactionType.Expense)
            {
                var account = await _accountService.GetAccount(transaction.accountId);
                if(account == null || account.balance < transaction.amout)
                {
                    return BadRequest();
                }
                account.balance -= transaction.amout;

                var newAccount = new AccountDTO
                {
                    name = account.name,
                    description = account.description,
                    balance = account.balance,
                    status = account.status
                };
                await _accountService.UpdateAccount(account.id, newAccount);
            }
            //if transaction type is transfer
            else if(transaction.type == Enum.TransactionType.Transfer)
            {
                //check if account has enough money
                var account = await _accountService.GetAccount(transaction.accountId);
                if(account == null || account.balance < transaction.amout )
                {
                    return BadRequest();
                }
                //update account balance
                account.balance -= transaction.amout;
                
                //check if transfer account has enough money
                var account2 = await _accountService.GetAccount((int)transaction.transferAccountId);
                if(account2 == null || account2.balance < transaction.amout)
                {
                    return BadRequest();
                }
                //update transfer account balance
                account2.balance += transaction.amout;

                var newAccount = new AccountDTO
                {
                    name = account.name,
                    description = account.description,
                    balance = account.balance,
                    status = account.status
                };

                var newAccount2 = new AccountDTO
                {
                    name = account.name,
                    description = account.description,
                    balance = account.balance,
                    status = account.status
                };

                await _accountService.UpdateAccount(account.id, newAccount);
                await _accountService.UpdateAccount(account2.id, newAccount2);

            }
            else
            {
                return BadRequest();
            }
            
            //create transaction
            var result = await _transactionsService.CreateTransaction(transaction);
            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Transaction>> UpdateTransaction(int id, TransactionDTO transaction)
        {
            var updateTransaction = await _transactionsService.GetTransaction(id);
            
            if(updateTransaction == null)
                return NotFound();
    
            return await _transactionsService.UpdateTransaction(id, transaction);
            
        }
    }
}