using ExampleWebApi.Models;
using ExampleWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IRepository _db;

        private readonly ILogger<UsersController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
       [ActivatorUtilitiesConstructor]
        public UsersController(IRepository db)
        {
            _db = db;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            var allUsers = _db?.GetAllUsers();
            if (allUsers == null)
            {
                return null;
            }

            return allUsers;
        }


        /// <summary>
        /// save user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void Create([FromBody] User userItem)
        {
            _db.CreateUser(userItem);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <param name="updatedUserItem"></param>
        ///// <returns></returns>
        //[HttpPut("{id}")]
        //public IActionResult Update(int Id, [FromBody] User updatedUserItem)
        //{
        //    if (updatedUserItem == null || updatedUserItem.Id != Id)
        //    {
        //        return BadRequest();
        //    }

        //    var todoItem = _db.GetUser(Id);
        //    if (todoItem == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.UpdateUser(updatedUserItem);
        //    return RedirectToRoute("GetAllItems");
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns></returns>
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int Id)
        //{
        //    var deletedUserItem = _db.DeleteUser(Id);

        //    if (deletedUserItem == null)
        //    {
        //        return BadRequest();
        //    }

        //    return new ObjectResult(deletedUserItem);
        //}
    }
}
