using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ProyectoRegularizador.Data;
using ProyectoRegularizador.Entities;
using ProyectoRegularizador.Models.Dtos;
using ProyectoRegularizador.Services;

namespace ProyectoRegularizador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }



        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult CreateUser(UserForCreationDto dto)
        {
            try
            {
                _userService.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Created("Created", dto);
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }



        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            User? user = _userService.GetById(id);
            if (user is null)
            {
                return BadRequest("no existe");
            }
            _userService.Delete(id);
            return NoContent();
        }




    }
}
