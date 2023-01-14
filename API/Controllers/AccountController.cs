using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController: ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> GetAccounts()
        {
            var result = await _accountService.GetAccounts();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account?>> GetAccount(int id)
        {
            var result = await _accountService.GetAccount(id);
            return result;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Account>> CreateAccount(AccountDTO account)
        {
            if(account == null)
            {
                return BadRequest();
            }

            //create new account
            var result = await _accountService.CreateAccount(account);

            return result;
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Account>> UpdateAccount(int id, AccountDTO account)
        {
            var updateAccount = await _accountService.GetAccount(id);

            if(updateAccount == null)
                return NotFound();

            var result = await _accountService.UpdateAccount(id, account);

            return result;
        }
        
    }
}