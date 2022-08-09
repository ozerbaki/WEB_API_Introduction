using _01_Web_Api_Ornek.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_Web_Api_Ornek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        //[HttpGet]
        //public string Get()
        //{
        //    return "Get Users";
        //}


        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "Get Users2" + id;
        //}

        private List<User> users = Fake.FakeData.GetUsers(100);


        /// <summary>
        /// User List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<User> Get()
        {
            return users;
        }

        /// <summary>
        /// Select a User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] //Select
        public User Get(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Insert a User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost] //Insert
        public User Post([FromBody] User user)
        {
            users.Add(user);
            return user;
        }

        /// <summary>
        /// Update a User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public User Put([FromBody] User user)
        {
            var editUser = users.FirstOrDefault(x => x.Id == user.Id);
            editUser.FirstName = user.FirstName;
            editUser.LastName = user.LastName;
            editUser.Address = user.Address;

            return user;
        }

        /// <summary>
        /// Delete a User
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleteUser = users.FirstOrDefault(x => x.Id == id);

            users.Remove(deleteUser);
        }
    }
}
