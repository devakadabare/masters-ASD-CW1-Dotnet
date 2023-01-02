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
    public class AccountController: ControllerBase
    {
        private readonly StoreContext _context;
        public AccountController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            return Ok(account);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Account>> CreateAccount(AccountDTO account)
        {
            if(account == null)
            {
                return BadRequest();
            }

            //create new account
            var newAccount = new Account
            {
                name = account.name,
                description = account.description,
                balance = account.balance,
                status = account.status
            };

            _context.Accounts.Add(newAccount);
            await _context.SaveChangesAsync();

            return Ok(newAccount);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Account>> UpdateAccount(int id, AccountDTO account)
        {
            var updateAccount = await _context.Accounts.FindAsync(id);

            if(updateAccount == null)
                return NotFound();

            updateAccount.name = account.name;
            updateAccount.description = account.description;
            updateAccount.balance = account.balance;
            updateAccount.status = account.status;

            _context.Accounts.Update(updateAccount);
            await _context.SaveChangesAsync();

            return Ok(updateAccount);
        }
        
    }
}