using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;

namespace API.Interface
{
    public interface ITransactionService
    {
        public Task<List<Transaction>> GetTransactions();
        public Task<Transaction?> GetTransaction(int id);
        public Task<Transaction> CreateTransaction(TransactionCreateDTO transaction);
        public Task<Transaction> UpdateTransaction(int id, TransactionDTO transaction);
    }
}