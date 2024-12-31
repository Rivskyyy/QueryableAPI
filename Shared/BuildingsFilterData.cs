using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class BuildingsFilterData
    {
        List<string> Name {  get; set; }

        List<int> Id { get; set; }
        List<string> City { get; set; }
        List<string> Street { get; set; }
        List<string> BuildingNumber { get; set; }
        List<int> Floors { get; set; }
        List<int> YearBuilt { get; set; }
    }
}
