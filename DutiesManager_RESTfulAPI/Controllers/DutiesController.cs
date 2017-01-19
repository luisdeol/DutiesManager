using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DutiesManager_RESTfulAPI.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DutiesManager_RESTfulAPI.Controllers
{
    [Route("api/[controller]")]
    public class DutiesController : Controller
    {
        private DutiesManagerDbContext _context;
        public DutiesController(DutiesManagerDbContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Duty> Get()
        {
            var duties = _context.Duties.ToList();
            return duties;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Duty Get(int id)
        {
            Duty duty = _context.Duties.Single(d => d.DutyId == id);
            return duty;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Duty duty)
        {
            _context.Duties.Add(duty);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var duty = _context.Duties.Single(d => d.DutyId == id);
            _context.Duties.Remove(duty);
            _context.SaveChanges();
        }
    }
}
