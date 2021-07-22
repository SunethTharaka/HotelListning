using AutoMapper;
using HotelListning2.IRepository;
using HotelListning2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListning2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                var resutl = _mapper.Map<IList<CountryDTO>>(countries);
                return Ok(resutl);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error - {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(x => x.Id.Equals(id), new List<string> { "Hotels" });
                var resutl = _mapper.Map<CountryDTO>(country );
                return Ok(resutl);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error - {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }
    }
}
