using AutoMapper;
using QueryableCore.DTOs;
using QueryableDatabase.Models;
using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryableDatabase.Mapping
{
    public class QueryableDatabaseMapperProfile : Profile
    {
         public QueryableDatabaseMapperProfile()
        {
            CreateMap<Buildings, BuildingsDtos>().ReverseMap();
        }
    }
}
