using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class BuildingsRequestData
    {
        public BuildingsFilterData _BuildingsFilterData { get; set; } = new();
        public SortOrder _SortOrder { get; set; } = SortOrder.None;
        public BuildingOrderBy _BuildingOrderBy { get; set; } = BuildingOrderBy.None;

      /*  public BuildingsRequestData(BuildingsFilterData buildingsFilterData, SortOrder sortOrder, BuildingOrderBy buildingOrderBy) 
        { 
            _BuildingOrderBy = buildingOrderBy;
            _SortOrder = sortOrder;
            _BuildingsFilterData = buildingsFilterData;
        }   */
    }
}
