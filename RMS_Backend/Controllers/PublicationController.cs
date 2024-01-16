using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RMS_Backend.Interfaces;
using RMS_Backend.Dto;
using RMS_Backend.Models;

namespace RMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationController : Controller
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public PublicationController(IPublicationRepository publicationRepository, IUserRepository userRepository, ILogger<UserController> logger, IMapper mapper)
        {
            _publicationRepository = publicationRepository;
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult SubmitPublication([FromQuery] string userPersonnelNumber, [FromBody] PublicationDto publicationToSubmit)
        {
            if (!_userRepository.UserExist(userPersonnelNumber))
            {
                return NotFound("User not found");
            }

            var user = _userRepository.GetUser(userPersonnelNumber);
            string username = user.Username;

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(username)))
            {
                _logger.LogInformation($"Session id(submitPub): {HttpContext.Session.GetString(username)}");
                return Unauthorized("Unauthorized request, please login");
            }

            if (publicationToSubmit == null)
                return BadRequest(ModelState);

            var publications = _publicationRepository.GetUserPublications(userPersonnelNumber)
                .Where(p => p.DOI == publicationToSubmit.DOI)
                .FirstOrDefault();

            if (publications != null)
            {
                ModelState.AddModelError("", "Publication already exists");
                return StatusCode(422, ModelState);
            }

            publicationToSubmit.PublicationDate = DateTime.Parse(publicationToSubmit.PublicationDate.ToString());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var publicationMap = _mapper.Map<Publication>(publicationToSubmit);

            publicationMap.User = user;


            if (!_publicationRepository.CreatePublication(userPersonnelNumber, publicationMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok($"Publication {publicationMap.DOI} successfully submitted by user {username}");
        }
    }
}
