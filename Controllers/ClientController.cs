using DAW.Models._1_1;
using DAW.Models.Authentication;
using DAW.Services;
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
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult getByFullName(string name)
        {
            var result = _clientService.getClientByName(name);
            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public IActionResult getById([FromRoute] string id)
        {
            var guidID = new Guid(id);
            var result = _clientService.FindByIdWithDetails(guidID);
            return Ok(result);
        }

        [HttpGet("detailsUser")]
        public IActionResult getByNameWithDetails(string name)
        {
            var result = _clientService.getClientByNameWithDetails(name);
            return Ok(result);
        }

        //[Authorization(Rol.Admin)]
        //[Authorization]
        [HttpGet("getAll")]
        public IActionResult getAllWithInclude()
        {
            var usersList = _clientService.getAll();
            return Ok(usersList);
        }

        [HttpPost]
        public IActionResult AddWithFromBody(Client user)
        {
            var result = _clientService.createClient(user);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch([FromRoute] string id, [FromBody] JsonPatchDocument<Client> user)
        {
            //var entity = VideoGames.FirstOrDefault(videoGame => videoGame.Id == id);
            Guid parsedId = new Guid(id);
            Client userToUpdate = _clientService.FindById(parsedId);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            user.ApplyTo(userToUpdate, ModelState); // Must have Microsoft.AspNetCore.Mvc.NewtonsoftJson installed
            _clientService.Save();

            return Ok(userToUpdate);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserRequestDTO user)
        {
            var response = _clientService.Authenticate(user);

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
            Client userToDelete = _clientService.FindById(guidId);
            if (userToDelete == null)
            {
                return NotFound();
            }
            _clientService.deleteUser(userToDelete);
            _clientService.Save();



            return Ok(userToDelete);
        }
    }
}
