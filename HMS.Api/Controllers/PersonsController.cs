using HMS.Api.Repositories;
using HMS.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IHmsUnitOfWork _unit;
        public PersonsController(IHmsUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _unit.PersonsRepository.Get();
        }

        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _unit.PersonsRepository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] Person value)
        {
            _unit.PersonsRepository.Add(value);
            _unit.Submit();
        }

        [HttpPut]
        public void Put([FromBody] Person value)
        {
            _unit.PersonsRepository.Update(value);
            _unit.Submit();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unit.PersonsRepository.Delete(id);
            _unit.Submit();
        }
    }
}
