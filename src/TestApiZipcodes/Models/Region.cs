using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApiZipcodes.Models
{
    public class Region
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public List<RegionGroup> RegionGroups { get; set; }
    }

    public class RegionGroup
    {
        public string StartZip { get; set; }
        public string EndZip { get; set; }
    }
}
