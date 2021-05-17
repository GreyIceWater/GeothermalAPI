using GeothermalAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GeothermalAPI.Database;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeothermalAPI.Controllers
{
    [Route("api/[controller]")]
    public class InstallerController : Controller
    {
        private readonly GeothermalContext _context;

        public InstallerController(GeothermalContext context)
        {
            _context = context;
        }

        // GET: api/<InstallerController>
        // Reads installers.json file
        [HttpGet]
        public IEnumerable<Installer> Get()
        {
            string s = System.IO.File.ReadAllText("./installers.json");
            InstallerList installers = JsonConvert.DeserializeObject<InstallerList>(s);

            return installers.installers;
        }

        // GET: api/<InstallerController>/installers
        [HttpGet("installers")]
        public async Task<ActionResult<IEnumerable<Installer>>> GetInstallers()
        {
            return await _context.Installers.Select(i => i).ToListAsync();            
        }

        // GET: api/<InstallerController>/installer/5
        [HttpGet("installer")]
        public async Task<ActionResult<Installer>> GetInstaller(Guid id)
        {
            var installer = await _context.FindAsync<Installer>(id);
            if (installer == null)
                return NotFound();

            return installer;
        }

        // POST api/<InstallerController>/5
        [HttpPost("{id}")]
        public async Task<ActionResult<Installer>> AddInstaller([FromBody] Installer installer, Guid id)
        {
            if (id != installer.Id)
                return BadRequest();
            _context.Installers.Add(installer);

            await _context.SaveChangesAsync();

            return await GetInstaller(id);
        }

        // PUT api/<InstallerController>/5
        [HttpPut("{id}")]
        public async Task<bool> PutAsync(Guid id, [FromBody] Installer value)
        {
            if (id != value.Id)
                return false;

            var updateVal = await _context.Installers.FindAsync(value.Id);

            if (updateVal == null)
                return false;

            updateVal.Name = value.Name;
            updateVal.Location = value.Location;
            updateVal.PhoneNumber = value.PhoneNumber;
            updateVal.Email = value.Email;
            updateVal.GoogleRating = value.GoogleRating;
            updateVal.ImageURL = value.ImageURL;

            _context.Installers.Update(updateVal);
            int num = await _context.SaveChangesAsync();           

            return num > 0 ? true : false;
        }

        // DELETE api/<InstallerController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            var installer = await _context.Installers.FindAsync(id);

            if (installer == null)
            {
                return false;
            }

            _context.Installers.Remove(installer);
            int num = await _context.SaveChangesAsync();

            return num > 0 ? true : false;
        }
    }
}
