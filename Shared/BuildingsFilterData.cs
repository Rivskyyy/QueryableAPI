using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class BuildingsFilterData
    {
        public List<string>? Names { get; set; }
        public List<int>? Ids { get; set; }
        public List<string>? Citys { get; set; }
        public List<string>? Streets { get; set; }
        public List<string>? BuildingNumbers { get; set; }
        public List<int>? Floors { get; set; }
        public List<int>? YearBuilts { get; set; }
    }
}
