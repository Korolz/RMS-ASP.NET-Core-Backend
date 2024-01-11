using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RMS_Backend.Data;
using RMS_Backend.Dto;
using RMS_Backend.Models;

namespace RMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly RMSDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public LoginController(RMSDbContext dbContext, IMapper mapper, ILogger<LoginController> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            model.Password = HashHelper.ComputeSHA256Hash(model.Password);
            // Check for existing user
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == model.Username);
            if (user != null)
            {
                if(model.Password == user.Password)
                {
                    if (string.IsNullOrEmpty(HttpContext.Session.GetString(model.Username)))
                    {
                        HttpContext.Session.SetString(model.Username, Guid.NewGuid().ToString());
                    }
                    
                    _logger.LogInformation($"Session id(login): {HttpContext.Session.GetString(model.Username)}");
                    var userDto = _mapper.Map<UserDto>(user);

                    if (user.IsAdmin)
                    {
                        return Ok(new {Message = "Admin login successful", UserInfo = userDto });
                    }
                    else
                    {
                        return Ok(new { Message = "Regular user login successful", UserInfo = userDto });
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
