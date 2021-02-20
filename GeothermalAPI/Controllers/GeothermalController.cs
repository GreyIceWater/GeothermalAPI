using GeothermalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeothermalAPI.Controllers
{
    [Route("api/[controller]")]
    public class GeothermalController : Controller
    {
        // GET: api/<GeothermalController>
        [HttpGet]
        public IEnumerable<Geothermal> Get()
        {
            string s = System.IO.File.ReadAllText("./geothermals.json");
            GeothermalList geothermals = JsonConvert.DeserializeObject<GeothermalList>(s);

            return geothermals.geothermals;
        }

        // GET api/<GeothermalController>/5
        [HttpGet("{id}")]
        public Geothermal Get(Guid id)
        {
            List<Geothermal> geothermals = Get().ToList();
            if (geothermals == null)
                return null;
            return geothermals.SingleOrDefault(g => g.Id == id);
        }

        // POST api/<GeothermalController>
        [HttpPost]
        public Guid Post([FromBody] Geothermal value)
        {
            List<Geothermal> geothermals = Get().ToList();
            if (geothermals == null)
            {
                List<Geothermal> myGeothermals = new List<Geothermal>();
                myGeothermals.Add(value);
                GeothermalList smallList = new GeothermalList { geothermals = myGeothermals };
                string smallgeothermals = JsonConvert.SerializeObject(smallList);
                System.IO.File.WriteAllText("./geothermals.json", smallgeothermals);
                return value.Id;
            }

            geothermals.Add(value);
            GeothermalList geothermalList = new GeothermalList { geothermals = geothermals };
            string sgeothermals = JsonConvert.SerializeObject(geothermalList);
            System.IO.File.WriteAllText("./geothermals.json", sgeothermals);

            return value.Id;
        }

        // PUT api/<GeothermalController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, [FromBody] Geothermal value)
        {
            if (id != value.Id)
                return false;

            var geothermals = Get();
            if (geothermals == null)
                return false;

            var lst = geothermals.ToList();
            var oldVal = lst.SingleOrDefault(g => g.Id == id);
            if (oldVal == null)
                return false;

            int ix = lst.IndexOf(oldVal);
            lst[ix] = value;

            GeothermalList gl = new GeothermalList() { geothermals = lst };

            System.IO.File.WriteAllText("./geothermals.json", JsonConvert.SerializeObject(gl));

            return true;
        }

        // DELETE api/<GeothermalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
