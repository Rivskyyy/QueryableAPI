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
        public BuildingsFilterData BuildingsFilterData { get; set; } = new();
        public SortOrder SortOrder { get; set; } = SortOrder.None;
        public BuildingOrderBy BuildingOrderBy { get; set; } = BuildingOrderBy.None;

        public BuildingsRequestData(BuildingsFilterData buildingsFilterData, SortOrder sortOrder, BuildingOrderBy buildingOrderBy)
        {
            BuildingOrderBy = buildingOrderBy;
            SortOrder = sortOrder;
            BuildingsFilterData = buildingsFilterData;
        }
    }
}
