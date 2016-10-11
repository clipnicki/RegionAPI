using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApiZipcodes.Models;
using TestApiZipcodes.Repository;

namespace TestApiZipcodes.Controllers
{
    [Route("api/[controller]")]
    public class RegionController : Controller
    {
        public RegionController(IRegionRepository regionItems)
        {
            RegionItems = regionItems;
        }
        public IRegionRepository RegionItems { get; set; }

        // GET: api/region
        [HttpGet]
        public IEnumerable<Region> Get()
        {
            return RegionItems.GetAll();
        }

        // GET api/region/e085dddb-b66f-4e08-9a91-00a7a300c6ca
        [HttpGet("{id}", Name = "GetRegion")]
        public IActionResult Get(string id)
        {
            var item = RegionItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/region
        // should return 201 response if successful, 400 if fails
        [HttpPost]
        public IActionResult Create([FromBody] Region item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            RegionItems.Add(item);
            return CreatedAtRoute("GetRegion", new { id = item.Key }, item);
        }

        // PUT api/region/e085dddb-b66f-4e08-9a91-00a7a300c6ca
        // should return 204 (NoContent) response if successful, 400 if fails
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Region item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var region = RegionItems.Find(id);
            if (region == null)
            {
                return NotFound();
            }

            RegionItems.Update(item);
            return new NoContentResult();
        }

        // DELETE api/region/e085dddb-b66f-4e08-9a91-00a7a300c6ca
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var todo = RegionItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            RegionItems.Remove(id);
            return new NoContentResult();
        }

    }
}
