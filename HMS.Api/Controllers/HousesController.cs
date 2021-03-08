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
    public class HousesController : ControllerBase
    {
        private IHmsUnitOfWork _unit;
        public HousesController(IHmsUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public IEnumerable<House> Get()
        {
            return _unit.HousesRepository.Get();
        }

        [HttpGet("{id}")]
        public House Get(int id)
        {
            return _unit.HousesRepository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] House value)
        {
            _unit.HousesRepository.Add(value);
            _unit.Submit();
        }

        [HttpPut]
        public void Put([FromBody] House value)
        {
            _unit.HousesRepository.Update(value);
            _unit.Submit();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unit.HousesRepository.Delete(id);
            _unit.Submit();
        }
    }
}
