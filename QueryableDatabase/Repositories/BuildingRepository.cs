using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _mapper;
        public BuildingRepository(MSQLContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;   
        }

        public int? CreaBuilding(BuildingsDtos buildingDto)
        {
            Buildings building = _mapper.Map<Buildings>(buildingDto);

            _sqlContext.Buildings.Add(building);
            //_sqlContext.Buildings.Where(b => );
            int changesCount = _sqlContext.SaveChanges();

            return changesCount > 0 ? building.Id : null;
        }
  

        IQueryable<BuildingsDtos> IBuildingRepository.GetFilteredBuildings(BuildingsRequestData buildingsRequestData)
        {

            IQueryable<Buildings> buildings = _sqlContext.Buildings;
            //IQueryable<BuildingsDtos> dtoQuery = query.ProjectTo<BuildingsDtos>(_mapper.ConfigurationProvider);

            /*  var dtoQuery = query.Select(b => new BuildingsDtos
              {
                  Id = b.Id,
                  Name = b.Name,
                  City = b.City,
                  Street = b.Street,
                  BuildingNumber = b.BuildingNumber,
                  Floors = b.Floors,
                  YearBuilt = b.YearBuilt
              });*/



            if (buildingsRequestData.BuildingsFilterData.Names != null && buildingsRequestData.BuildingsFilterData.Names.Any()) 
                buildings = buildings.Where(b => buildingsRequestData.BuildingsFilterData.Names.Contains(b.Name));

            if (buildingsRequestData.BuildingsFilterData.Citys != null && buildingsRequestData.BuildingsFilterData.Citys.Any())
                buildings = buildings.Where(b => buildingsRequestData.BuildingsFilterData.Citys.Contains(b.City));

            if (buildingsRequestData.BuildingsFilterData.Streets != null && buildingsRequestData.BuildingsFilterData.Streets.Any())
                buildings = buildings.Where(b => buildingsRequestData.BuildingsFilterData.Streets.Contains(b.Street));

            if (buildingsRequestData.BuildingsFilterData.BuildingNumbers != null && buildingsRequestData.BuildingsFilterData.BuildingNumbers.Any())
                buildings = buildings.Where(b => buildingsRequestData.BuildingsFilterData.BuildingNumbers.Contains(b.BuildingNumber));

       
            if (buildingsRequestData.BuildingsFilterData.MinFloors.HasValue)
                buildings = buildings.Where(b => b.Floors >= buildingsRequestData.BuildingsFilterData.MinFloors);

            if (buildingsRequestData.BuildingsFilterData.MaxFloors.HasValue)
                buildings = buildings.Where(b => b.Floors <= buildingsRequestData.BuildingsFilterData.MaxFloors);

            if (buildingsRequestData.BuildingsFilterData.MinYearBuilt.HasValue)
                buildings = buildings.Where(b => b.YearBuilt >= buildingsRequestData.BuildingsFilterData.MinYearBuilt);

            if (buildingsRequestData.BuildingsFilterData.MaxYearBuilt.HasValue)
                buildings = buildings.Where(b => b.YearBuilt <= buildingsRequestData.BuildingsFilterData.MaxYearBuilt);


            if (buildingsRequestData.BuildingOrderBy != BuildingOrderBy.None && buildingsRequestData.SortOrder != SortOrder.None)
            {
                if (buildingsRequestData.BuildingOrderBy == BuildingOrderBy.Name)
                {
                    if (buildingsRequestData.SortOrder == SortOrder.Ascending)
                    {
                        buildings = buildings.OrderBy(b => b.Name);
                    }
                    else
                    {
                        buildings = buildings.OrderByDescending(b => b.Name);
                    }
                }
                else if (buildingsRequestData.BuildingOrderBy == BuildingOrderBy.Address)
                {
                    if (buildingsRequestData.SortOrder == SortOrder.Ascending)
                    {
                        buildings = buildings.OrderBy(b => b.City)
                                     .ThenBy(b => b.Street)
                                     .ThenBy(b => b.BuildingNumber);
                    }
                    else
                    {
                        buildings = buildings.OrderByDescending(b => b.City)
                                     .ThenByDescending(b => b.Street)
                                     .ThenByDescending(b => b.BuildingNumber);
                    }
                }
                else if (buildingsRequestData.BuildingOrderBy == BuildingOrderBy.Floors)
                {
                    if (buildingsRequestData.SortOrder == SortOrder.Ascending)
                    {
                        buildings = buildings.OrderBy(b => b.Floors);
                    }
                    else
                    {
                        buildings = buildings.OrderByDescending(b => b.Floors);
                    }
                }
                else if (buildingsRequestData.BuildingOrderBy == BuildingOrderBy.YearBuilt)
                {
                    if (buildingsRequestData.SortOrder == SortOrder.Ascending)
                    {
                        buildings = buildings.OrderBy(b => b.YearBuilt);
                    }
                    else
                    {
                        buildings = buildings.OrderByDescending(b => b.YearBuilt);
                    }
                }
            }
            var dtoBuildings = buildings.ProjectTo<BuildingsDtos>(_mapper.ConfigurationProvider);

            /*List<Buildings> buildingsList = query.ToList()
            return _mapper.Map<List<BuildingsDtos>>(buildingsList);*/
            return dtoBuildings;
        }
    }
}
