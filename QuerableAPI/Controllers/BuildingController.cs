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
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;
        public BuildingController(IBuildingService buildingService)
        {

            // BuildingRepository buildingRepository = new BuildingRepository(mSQLContext);
            _buildingService = buildingService;

        }

        [HttpGet]
        public IActionResult Get([FromQuery] BuildingsRequestData requestData)
        {
            var buildings = _buildingService.GetFilteredBuildings(requestData);
            return Ok(buildings);
           
        }

        [HttpPost]
        public IActionResult CreateBuilding([FromBody] BuildingsDtos buildingDto)
        {
            int? id = _buildingService.CreateBuilding(buildingDto);

            return id.HasValue ? Ok(id) : BadRequest();
        }

    }
}
