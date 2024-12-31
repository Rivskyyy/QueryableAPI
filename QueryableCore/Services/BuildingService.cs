using QueryableCore.DTOs;
using QueryableCore.Services.Interfaces;

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

       public int? Get()
        {

        }
    }
}
