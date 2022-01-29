using DAW.Models._1_1;
using DAW.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IUserService _userService;

        public ClientController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult getByFullName(string name)
        {
            var result = _userService.getUserByName(name);
            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public IActionResult getById([FromRoute] string id)
        {
            var guidID = new Guid(id);
            var result = _userService.FindByIdWithData(guidID);
            return Ok(result);
        }

        [HttpGet("detailsUser")]
        public IActionResult getByNameWithDetails(string name)
        {
            var result = _userService.getUserByNameWithDetails(name);
            return Ok(result);
        }

        //[Authorization(Rol.Admin)]
        //[Authorization]
        [HttpGet("getAll")]
        public IActionResult getAllWithInclude()
        {
            var usersList = _userService.getAll();
            return Ok(usersList);
        }

        [HttpPost]
        public IActionResult AddWithFromBody(Client user)
        {
            var result = _userService.createUser(user);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch([FromRoute] string id, [FromBody] JsonPatchDocument<Client> user)
        {
            //var entity = VideoGames.FirstOrDefault(videoGame => videoGame.Id == id);
            Guid parsedId = new Guid(id);
            Client userToUpdate = _userService.FindById(parsedId);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            user.ApplyTo(userToUpdate, ModelState); // Must have Microsoft.AspNetCore.Mvc.NewtonsoftJson installed
            _userService.Save();

            return Ok(userToUpdate);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserRequestDTO user)
        {
            var response = _userService.Authenticate(user);

            if (response == null)
            {
                return BadRequest(new { Message = "Username or Password is invalid!" });
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] string id)
        {
            Guid guidId = new Guid(id);
            Client userToDelete = _userService.FindById(guidId);
            if (userToDelete == null)
            {
                return NotFound();
            }
            _userService.deleteUser(userToDelete);
            _userService.Save();



            return Ok(userToDelete);
        }
    }
}
