using QueryableCore.DTOs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryableCore.Services.Interfaces
{
    public  interface IBuildingService
    {
        int? CreateBuilding(BuildingsDtos buildingDto);

        public List<BuildingsDtos> GetFilteredBuildings(BuildingsRequestData buildingsRequestData);
        
    }
}
