using Microsoft.AspNetCore.Mvc;
using RMS_Backend.Data;
using RMS_Backend.Models;
using static RMS_Backend.HashHelper;

namespace RMS_Backend.Controllers
{
    public class LoginController : Controller
    {
        private readonly RMSDbContext _dbContext;

        public LoginController(RMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            model.Password = HashHelper.ComputeSHA256Hash(model.Password);
            // Check for existing user
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == model.Username);
            if (user != null)
            {
                if(model.Password == user.Password)
                {
                    if (user.IsAdmin)
                    {
                        return Ok(new { Message = "Admin login successful" });
                    }
                    else
                    {
                        return Ok(new { Message = "Regular user login successful" });
                    }
                }
                else
                {
                    return Unauthorized(new { Message = "Wrong password" });
                }
            }

            return Unauthorized(new { Message = "User not found" });
        }
    }
}
