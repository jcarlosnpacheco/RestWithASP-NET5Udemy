using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASP_NET5Udemy.Model;
using RestWithASP_NET5Udemy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        //declara o uso do serviço IPersonService

        private IPersonService _ipersonService;

        public PersonController(IPersonService ipersonService)
        {
            _ipersonService = ipersonService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_ipersonService.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int Id)
        {
            var lPerson = _ipersonService.FindById(Id);

            if (lPerson == null) {
                return NotFound();
            }
            return Ok(lPerson);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                return NotFound();
            }
            return Ok(_ipersonService.Create(person));
        }


        [HttpPut]
        public ActionResult Put([FromBody] Person person)
        {
            if (person == null)
            {
                return NotFound();
            }
            return Ok(_ipersonService.Update(person));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int Id)
        {
            _ipersonService.Delete(Id);            
            return NoContent();
        }

    }
}
