using AssetManagementAPI.DTO;
using AssetManagementAPI.Interfaces;
using AssetManagementAPI.Model;
using AssetManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace AssetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            this._cityService = cityService;
        }
        [HttpGet]
        public IActionResult GetDetails()
        {

            return Ok(_cityService.GetCities());
        }

        [HttpPost]
        public IActionResult Create(CityDTO city) {

            try
            {
                int id = _cityService.CreateCity(city);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
