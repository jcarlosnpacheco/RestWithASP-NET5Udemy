using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASP_NET5Udemy.Model;
using RestWithASP_NET5Udemy.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Controllers
{
    [ApiController]

    //se quisesse criar novas versões do controller, para por exemplo adicionar novos campos ao objeto person, utilizar a biblioteca Apiversioning.
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private IPersonBusiness _ipersonBusiness;

        public PersonController(IPersonBusiness ipersonBusiness)
        {
            _ipersonBusiness = ipersonBusiness;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_ipersonBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int Id)
        {
            var lPerson = _ipersonBusiness.FindById(Id);

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
            return Ok(_ipersonBusiness.Create(person));
        }


        [HttpPut]
        public ActionResult Put([FromBody] Person person)
        {
            if (person == null)
            {
                return NotFound();
            }
            return Ok(_ipersonBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int Id)
        {
            _ipersonBusiness.Delete(Id);            
            return NoContent();
        }

    }
}
