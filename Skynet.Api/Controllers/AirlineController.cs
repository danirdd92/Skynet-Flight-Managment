using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skynet.Entities.Dtos;
using Skynet.Repository;

namespace Skynet.Api.Controllers
{
    [Route("api/airlines")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public AirlineController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var airlines = _repository.Airline.GetAllAirlines();
            var airlinesDto = _mapper.Map<IEnumerable<AirlineDto>>(airlines);
            return Ok(airlinesDto);
        }
    }
}
