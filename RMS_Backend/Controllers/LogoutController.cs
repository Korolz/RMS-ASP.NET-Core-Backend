using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RMS_Backend.Data;
using RMS_Backend.Models;

namespace RMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : Controller
    {
        private readonly RMSDbContext _dbContext;
        private readonly ILogger<LogoutController> _logger;

        public LogoutController(RMSDbContext dbContext, ILogger<LogoutController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Logout([FromBody] LogoutModel model)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == model.Username);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(HttpContext.Session.GetString(model.Username)))
                {
                    _logger.LogInformation($"Terminating session {HttpContext.Session.GetString(model.Username)}");
                    HttpContext.Session.Remove(model.Username);
                    return Ok(new { Message = $"User {model.Username} logout successfull" });
                }
                else
                {
                    return Unauthorized(new { Message = $"User {model.Username} session missing" });
                }
            }
            
            return BadRequest(new { Message = $"User {model.Username} not found" });
        }
    }
}
