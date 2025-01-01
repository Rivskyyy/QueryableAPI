using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class BuildingsFilterData
    {
        public List<string> Name { get; set; }
        public List<int> Id { get; set; }
        public List<string> City { get; set; }
        public List<string> Street { get; set; }
        public List<string> BuildingNumber { get; set; }
        public List<int> Floors { get; set; }
        public List<int> YearBuilt { get; set; }
    }
}
