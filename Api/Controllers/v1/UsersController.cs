using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1;

[Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<CreateUserRequestDTO> users = new List<CreateUserRequestDTO>
        {
          
            // Add more users as needed
        };

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUserById(int id)
        {
           return Ok();
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequestDTO user)
        {
        return Ok();
    }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] CreateUserRequestDTO updatedUser)
        {
        return Ok();
    }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
        return Ok();
    }
}



