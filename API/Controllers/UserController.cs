using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController: ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _userService.GetUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            return user;
        }

        [HttpPost("create")]
        public async Task<ActionResult<User>> CreateUser(UserCreateDTO user)
        {
            if(user == null)
            {
                return BadRequest();
            }

            var newUser = await _userService.CreateUser(user);
            return newUser;
        }

        [HttpPut("update")]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            if(user == null)
            {
                return BadRequest();
            }

            var updatedUser = await _userService.UpdateUser(user);
            return updatedUser;
        }

    }
}