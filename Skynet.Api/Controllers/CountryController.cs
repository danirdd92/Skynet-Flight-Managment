using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skynet.Entities.Dtos;
using Skynet.Entities.Models;
using Skynet.Repository;

namespace Skynet.Api.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CountryController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var countries = _repository.Country.GetAllCountries();
            var countriesDto = _mapper.Map<IEnumerable<CountryDto>>(countries);
            return Ok(countriesDto);
        }
    }
}
