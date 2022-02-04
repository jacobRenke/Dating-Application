using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers() //allows us to get information for our DbUsers
        {
            var users = _context.Users.ToList();

            return users;
        }

        // api/users/3
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id) // needed to remove the IEnumerable
        {
            return _context.Users.Find(id);
        }


    }
}