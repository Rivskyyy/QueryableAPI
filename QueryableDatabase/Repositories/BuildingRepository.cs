using QueryableCore.DTOs;
using QueryableCore.Services.Interfaces;
using QueryableDatabase.Migrations;
using QueryableDatabase.Models;
using Shared;
using Shared.Enum;
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
  

        IQueryable<BuildingsDtos> IBuildingRepository.GetFilteredBuildings(BuildingsRequestData buildingsRequestData)
        {
            IQueryable<Buildings> query = _sqlContext.Buildings;

            var dtoQuery = query.Select(b => new BuildingsDtos
            {
                Id = b.Id,
                Name = b.Name,
                City = b.City,
                Street = b.Street,
                BuildingNumber = b.BuildingNumber,
                Floors = b.Floors,
                YearBuilt = b.YearBuilt
            });

            if (buildingsRequestData.BuildingsFilterData.Name.Any())
                query = query.Where(b => buildingsRequestData.BuildingsFilterData.Name.Contains(b.Name));

            if (buildingsRequestData.BuildingsFilterData.City.Any())
                query = query.Where(b => buildingsRequestData.BuildingsFilterData.City.Contains(b.City));

            if (buildingsRequestData.BuildingsFilterData.Street.Any())
                query = query.Where(b => buildingsRequestData.BuildingsFilterData.Street.Contains(b.Street));

            if (buildingsRequestData.BuildingsFilterData.BuildingNumber.Any())
                query = query.Where(b => buildingsRequestData.BuildingsFilterData.BuildingNumber.Contains(b.BuildingNumber));

            if (buildingsRequestData.BuildingsFilterData.Floors.Any())
                query = query.Where(b => buildingsRequestData.BuildingsFilterData.Floors.Contains(b.Floors));

            if (buildingsRequestData.BuildingsFilterData.YearBuilt.Any())
                query = query.Where(b => buildingsRequestData.BuildingsFilterData.YearBuilt.Contains(b.YearBuilt));


            if (buildingsRequestData.BuildingOrderBy != BuildingOrderBy.None && buildingsRequestData.SortOrder != SortOrder.None)
            {
                if (buildingsRequestData.BuildingOrderBy == BuildingOrderBy.Name)
                {
                    if (buildingsRequestData.SortOrder == SortOrder.Ascending)
                    {
                        query = query.OrderBy(b => b.Name);
                    }
                    else
                    {
                        query = query.OrderByDescending(b => b.Name);
                    }
                }
                else if (buildingsRequestData.BuildingOrderBy == BuildingOrderBy.Address)
                {
                    if (buildingsRequestData.SortOrder == SortOrder.Ascending)
                    {
                        query = query.OrderBy(b => b.City)
                                     .ThenBy(b => b.Street)
                                     .ThenBy(b => b.BuildingNumber);
                    }
                    else
                    {
                        query = query.OrderByDescending(b => b.City)
                                     .ThenByDescending(b => b.Street)
                                     .ThenByDescending(b => b.BuildingNumber);
                    }
                }
                else if (buildingsRequestData.BuildingOrderBy == BuildingOrderBy.Floors)
                {
                    if (buildingsRequestData.SortOrder == SortOrder.Ascending)
                    {
                        query = query.OrderBy(b => b.Floors);
                    }
                    else
                    {
                        query = query.OrderByDescending(b => b.Floors);
                    }
                }
                else if (buildingsRequestData.BuildingOrderBy == BuildingOrderBy.YearBuilt)
                {
                    if (buildingsRequestData.SortOrder == SortOrder.Ascending)
                    {
                        query = query.OrderBy(b => b.YearBuilt);
                    }
                    else
                    {
                        query = query.OrderByDescending(b => b.YearBuilt);
                    }
                }
            }

            return dtoQuery;
        }
    }
}
