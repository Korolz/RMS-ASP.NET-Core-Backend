using Microsoft.AspNetCore.Mvc;
using RMS_Backend.Interfaces;
using RMS_Backend.Models;

namespace RMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpGet("{userPersonellNumber}/publication")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUserPublications(string userPersonellNumber)
        {
            if (!_userRepository.UserExist(userPersonellNumber))
            {
                return NotFound(new {Message = "User not found"});
            }

            var user = _userRepository.GetUser(userPersonellNumber);
            string username = user.Username;

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(username)))
            {
                _logger.LogInformation($"Session id(getPubs): {HttpContext.Session.GetString(username)}");
                return Unauthorized(new { Message = "Unauthorized request, please login" });
            }

            var publications = _userRepository.GetUserPublications(userPersonellNumber);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(publications);
        }
    }
}
