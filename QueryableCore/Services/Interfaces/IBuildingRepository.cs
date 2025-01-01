using QueryableCore.DTOs;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryableCore.Services.Interfaces
{
    public interface IBuildingRepository
    {
        int? CreaBuilding(BuildingsDtos buildingDto);

        public IQueryable<BuildingsDtos> GetFilteredBuildings(BuildingsRequestData buildingsRequestData);
    }
}
