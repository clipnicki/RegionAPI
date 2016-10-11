using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApiZipcodes.Models;

namespace TestApiZipcodes.Repository
{
    public interface IRegionRepository
    {
        void Add(Region item);
        IEnumerable<Region> GetAll();
        Region Find(string key);
        Region Remove(string key);
        void Update(Region item);
    }
}
