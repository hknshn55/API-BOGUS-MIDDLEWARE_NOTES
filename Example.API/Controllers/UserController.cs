using Example.API.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace Example.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult Users()
        {
            var users = Context.GetUsers();
            if (users.Count>0)
            {
                return Ok(users);
            }
            return NotFound();
        }
    }
}
