using Airbnb.Domain.Data;
using Airbnb.Domain.Entities;
using Airbnb.Infrastructure.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AirbnbClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlaceToRentController : ControllerBase
    {

        PlaceToRentService _service;
        CityService _cityService;

        public PlaceToRentController(PlaceToRentService service, CityService cityService)
        {
            _service = service;
            _cityService = cityService;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List() 
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity.Name;
                var list = _service.List(x => x.User.UserName == user);
                return Ok(list);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create() 
        {
            return Ok();
        }

    }
}
