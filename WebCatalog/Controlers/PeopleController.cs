using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCatalog.Models;
using WebCatalog.Services;

namespace WebCatalog.Controlers
{
    [Route("[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public PeopleController(JsonFilePeopleService peopleService)
        {
            PeopleService = peopleService;
        }

        public JsonFilePeopleService PeopleService { get; }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return PeopleService.GetPeople();
        }


        
        //[HttpPatch]
        [Route("additional")]
        [HttpGet]
        public ActionResult Get<T>(
            [FromQuery]int id,
            [FromQuery]string property_name, 
            [FromQuery]T property_value)
        {
            PeopleService.AddProperty(id, property_name, property_value);
            return Ok();
        }
    }
}
