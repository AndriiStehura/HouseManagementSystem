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
    public class ProvidersController : ControllerBase
    {
        private IHmsUnitOfWork _unit;
        public ProvidersController(IHmsUnitOfWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        public IEnumerable<Provider> Get()
        {
            return _unit.ProvidersRepository.Get(includeProperties: "Address,Contact");
        }

        [HttpGet("{id}")]
        public Provider Get(int id)
        {
            return _unit.ProvidersRepository.Get(id);
        }

        [HttpPost]
        public void Post([FromBody] Provider value)
        {
            _unit.ProvidersRepository.Add(value);
            _unit.Submit();
        }

        [HttpPut]
        public void Put([FromBody] Provider value)
        {
            _unit.ProvidersRepository.Update(value);
            _unit.Submit();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _unit.ProvidersRepository.Delete(id);
            _unit.Submit();
        }
    }
}
