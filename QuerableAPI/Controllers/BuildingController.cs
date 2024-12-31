using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueryableCore.DTOs;
using QueryableCore.Services;
using QueryableDatabase.Migrations;
using QueryableDatabase.Repositories;

namespace QuerableAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly BuildingService _buildingService;
        public BuildingController(MSQLContext mSQLContext)
        {

            BuildingRepository buildingRepository = new BuildingRepository(mSQLContext);
            _buildingService = new BuildingService(buildingRepository);

        }

        [HttpGet]
        public IActionResult GetAllBuildings()
        {
            var buildings = _buildingService.GetAllBuildings();
            return Ok(buildings);
        }

        [HttpPost]
        public IActionResult CreateBuilding([FromBody] BuildingDtos buildingDto)
        {
            int? id = _buildingService.CreateBuilding(buildingDto);

            return id.HasValue ? Ok(id) : BadRequest();
        }

    }
}
