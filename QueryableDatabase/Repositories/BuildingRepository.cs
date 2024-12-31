using QueryableCore.DTOs;
using QueryableCore.Services.Interfaces;
using QueryableDatabase.Migrations;
using QueryableDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryableDatabase.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly MSQLContext _sqlContext;

        public BuildingRepository(MSQLContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public int? CreaBuilding(BuildingsDtos buildingDto)
        {
            Buildings building = new Buildings
            {
                Id = default,
                Name = buildingDto.Name,
                City = buildingDto.City,
                Street = buildingDto.Street,
                BuildingNumber = buildingDto.BuildingNumber,
                Floors = buildingDto.Floors,
                YearBuilt = buildingDto.YearBuilt,
            };

            _sqlContext.Buildings.Add(building);
            //_sqlContext.Buildings.Where(b => );
            int changesCount = _sqlContext.SaveChanges();

            return changesCount > 0 ? building.Id : null;
        }

        public int? Get()
        {
            
        }
    }
}
