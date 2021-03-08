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
    public class ServicesController : ControllerBase
    {
        private IHmsUnitOfWork _unit;
        public ServicesController(IHmsUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public IEnumerable<Service> Get()
        {
            return _unit.ServicesRepository.Get(includeProperties: "Provider");
        }

        [HttpGet("{id}")]
        public Service Get(int id)
        {
            return _unit.ServicesRepository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] Service value)
        {
            _unit.ServicesRepository.Add(value);
            _unit.Submit();
        }

        [HttpPut]
        public void Put([FromBody] Service value)
        {
            _unit.ServicesRepository.Update(value);
            _unit.Submit();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unit.ServicesRepository.Delete(id);
            _unit.Submit();
        }
    }
}
