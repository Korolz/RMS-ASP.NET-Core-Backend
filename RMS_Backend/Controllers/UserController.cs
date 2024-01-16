using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RMS_Backend.Dto;
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
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger, IMapper mapper)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{userPersonellNumber}/publications")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult GetUserPublications(string userPersonnelNumber)
        {
            if (!_userRepository.UserExist(userPersonnelNumber))
            {
                return NotFound("User not found");
            }

            var user = _userRepository.GetUser(userPersonnelNumber);
            string username = user.Username;

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(username)))
            {
                _logger.LogInformation($"Session id(getPubs): {HttpContext.Session.GetString(username)}");
                return Unauthorized("Unauthorized request, please login");
            }

            var publications = _userRepository.GetUserPublications(userPersonnelNumber);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(publications);
        }

        [HttpPut("{userPersonellNumber}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUserPassword(string userPersonellNumber, [FromBody] ChangePasswordModel updatedUser)
        {
            if (updatedUser == null)
                return BadRequest(ModelState);

            if (!_userRepository.UserExist(userPersonellNumber))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            //check for auth
            var user = _userRepository.GetUser(userPersonellNumber);
            string username = user.Username;
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(username)))
            {
                _logger.LogInformation($"Session id(updatePass): {HttpContext.Session.GetString(username)}");
                return Unauthorized("Unauthorized request, please login");
            }

            //changing password
            updatedUser.Password = HashHelper.ComputeSHA256Hash(updatedUser.Password);

            if (!user.Password.Equals(updatedUser.Password))
                return Unauthorized("Wrong old password");

            user.Password = HashHelper.ComputeSHA256Hash(updatedUser.NewPassword);

            if (!_userRepository.UpdatePassword(user))
            {
                ModelState.AddModelError("", "Something went wrong updating owner");
                return StatusCode(500, ModelState);
            }

            return Ok($"Password for {user.Username} changed successfully");
        }

    }
}
