using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data.Entities;
using ProductManagement.Data.Services;
using ProductManagement.WebAPI.Helpers;
using ProductManagement.WebAPI.Models;

namespace ProductManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly GenerateToken _generateToken;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserController(GenerateToken generateToken,
            IMapper mapper,
            IUserRepository userRepository)
        {
            _generateToken = generateToken;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var userModel = _mapper.Map<User>(model);
            var response = _generateToken.Authenticate(userModel);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }
    }
}
