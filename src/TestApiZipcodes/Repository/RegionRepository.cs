using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using TestApiZipcodes.Models;

namespace TestApiZipcodes.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private static ConcurrentDictionary<string, Region> _regions =
              new ConcurrentDictionary<string, Region>();

        public RegionRepository()
        {
            List<RegionGroup> groups = new List<RegionGroup>();
            groups.Add(new RegionGroup { StartZip = "06108", EndZip = "06110" });
            groups.Add(new RegionGroup { StartZip = "06115", EndZip = "06115" });
            Add(new Region { Key = Guid.NewGuid().ToString(), Name = "Region1", RegionGroups = groups });
        }

        public IEnumerable<Region> GetAll()
        {
            return _regions.Values;
        }

        public void Add(Region item)
        {
            item.Key = Guid.NewGuid().ToString();
            _regions[item.Key] = item;
        }

        public Region Find(string key)
        {
            Region item;
            _regions.TryGetValue(key, out item);
            return item;
        }

        public Region Remove(string key)
        {
            Region item;
            _regions.TryRemove(key, out item);
            return item;
        }

        public void Update(Region item)
        {
            _regions[item.Key] = item;
        }
    }
}
