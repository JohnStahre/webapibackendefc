using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using webapi;
using webapi.Models;

namespace webapi.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly SqlContext _context;

        public AuthenticationController(SqlContext context)
        {
            _context = context;
        }

       [HttpPost("LogIn")]
       public async Task<ActionResult<dynamic>> LogIn(LoginModel model)
        {
            var user = await _context.Users.Where(x => x.Email == model.Email).FirstOrDefaultAsync();

            if (user != null)
            {
                if(user.Password == model.Password)
                {
                    return new OkObjectResult(JsonConvert.SerializeObject(new { userId = user.Id, sessionId = Guid.NewGuid().ToString() }));
                }
                return new BadRequestObjectResult(JsonConvert.SerializeObject(new { message = "incorrect emailadreess or password" }));
            }
            return new BadRequestObjectResult(JsonConvert.SerializeObject(new { message = "incorrect emailadreess or password" }));
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<dynamic>> SignUp(SignUpModel model)
        {
            var _user = await _context.Users.Where(x => x.Email == model.Email).FirstOrDefaultAsync();

            if (_user == null)
            {
                var user = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,

                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return new OkResult();


            }
            return new BadRequestObjectResult(JsonConvert.SerializeObject(new { message = "Email already exist." }));
        }

    }
}
