using IncidentApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace IncidentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private IncidentsContext dbContext;
        public IncidentController(IncidentsContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public IEnumerable<Incident> Get()
        {
            return dbContext.Incidents;
        }

        [HttpGet("{id}")]
        public Incident Get(string? id)
        {
            return dbContext.Incidents.FirstOrDefault(i => i.NameId == id);
        }

        [HttpPost]
        public void Post([FromBody]Incident value)
        {
            dbContext.Incidents.Add(value);
            dbContext.SaveChanges();
        }

        [HttpPut]
        public void Put(string? id, [FromBody] Incident value)
        {
            var incident = dbContext.Incidents.FirstOrDefault(i => i.NameId == id);
            if (incident == null) 
            {
                dbContext.Entry<Incident>(incident).CurrentValues.SetValues(value);
                dbContext.SaveChanges();
            }
        }

        [HttpDelete]
        public  void Delete(string? id)
        {
            var incident = dbContext.Incidents.FirstOrDefault(x => x.NameId == id);
            if (incident != null)
            {
                dbContext.Incidents.Remove(incident);
                dbContext.SaveChanges();
            }
        }
    }
}
