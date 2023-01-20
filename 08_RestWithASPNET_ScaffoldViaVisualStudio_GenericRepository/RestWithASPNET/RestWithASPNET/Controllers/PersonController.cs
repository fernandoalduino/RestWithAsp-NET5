using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Models;
using RestWithASPNET.Business;
using System;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;

        private IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personService)
        {
            _logger = logger;
            _personBusiness = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("Person cannot be null");
            }

            return Ok(_personBusiness.Create(person));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("Person cannot be null");
            }

            return Ok(_personBusiness.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null)
            {
                return BadRequest("Invalid Person");
            }

            _personBusiness.Delete(id); // Void Method

            return NoContent();
        }
    }
}