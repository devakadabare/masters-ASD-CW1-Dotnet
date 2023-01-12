using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AccountService
    {
        private readonly StoreContext _context;

        public AccountService(StoreContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<ActionResult<Account?>> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            return account;
        }

        public async Task<ActionResult<Account>> CreateAccount(AccountDTO account)
        {
            var newAccount = new Account
            {
                name = account.name,
                description = account.description,
                balance = account.balance,
                status = account.status
            };

            var result =_context.Accounts.Add(newAccount);
            await _context.SaveChangesAsync();
            return newAccount;
        }

        public async Task<ActionResult<Account>> UpdateAccount(int id, AccountDTO account)
        {
            var updateAccount = await _context.Accounts.FindAsync(id);

            updateAccount.name = account.name;
            updateAccount.description = account.description;
            updateAccount.balance = account.balance;
            updateAccount.status = account.status;

            _context.Accounts.Update(updateAccount);
            await _context.SaveChangesAsync();

            return updateAccount;
        }
    }
}