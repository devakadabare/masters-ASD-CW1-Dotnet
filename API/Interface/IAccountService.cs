using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;

namespace API.Interface
{
    public interface IAccountService
    {
        public Task<List<Account>> GetAccounts();

        public Task<Account?> GetAccount(int id);

        public Task<Account> CreateAccount(AccountDTO account);

        public Task<Account> UpdateAccount(int id, AccountDTO account);
        
    }
}