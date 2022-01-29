using DAW.Models._1_1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly IDetailsService _detailsService;

        public DetailsController(IDetailsService detailsService)
        {
            _detailsService = detailsService;
        }

        [HttpPost("fromBody")]
        public IActionResult AddWithFromBody(DetailsClient info)
        {
            var result = _detailsService.create(info);
            return Ok(result);
        }
    }
}
