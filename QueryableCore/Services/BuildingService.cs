using QueryableCore.DTOs;
using QueryableCore.Services.Interfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryableCore.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;

        public BuildingService(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;
        }

        public int? CreateBuilding(BuildingsDtos buildingDto)
        {
            return _buildingRepository.CreaBuilding(buildingDto);
        }

        public List<BuildingsDtos> GetFilteredBuildings(BuildingsRequestData buildingsRequestData)
        {

            /*  var query = _buildingRepository.GetFilteredBuildings(buildingsRequestData);

              var buildingsDtos = query
                  .Select(building => new BuildingsDtos
                  {
                      Id = building.Id,
                      Name = building.Name,
                      City = building.City,
                      Street = building.Street,
                      BuildingNumber = building.BuildingNumber,
                      Floors = building.Floors,
                      YearBuilt = building.YearBuilt
                  })
                  .ToList(); */

            return _buildingRepository.GetFilteredBuildings(buildingsRequestData).ToList();
        }

    }
}
