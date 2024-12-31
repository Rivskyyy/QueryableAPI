using QueryableCore.DTOs;
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
        
    }
}
