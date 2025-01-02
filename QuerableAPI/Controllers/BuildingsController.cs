using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueryableCore.DTOs;
using QueryableCore.Services;
using QueryableCore.Services.Interfaces;
using QueryableDatabase.Migrations;
using QueryableDatabase.Repositories;
using Shared;

namespace QuerableAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingService _buildingService;
        public BuildingsController(IBuildingService buildingService)
        {

            _buildingService = buildingService;

        }

        [HttpPost]
        [Route("get")]
        public IActionResult Get([FromBody] BuildingsRequestData requestData)
        {
            var buildings = _buildingService.GetFilteredBuildings(requestData);
            return Ok(buildings);
           
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateBuilding([FromBody] BuildingsDtos buildingDto)
        {
            int? id = _buildingService.CreateBuilding(buildingDto);

            return id.HasValue ? Ok(id) : BadRequest();
        }

    }
}
