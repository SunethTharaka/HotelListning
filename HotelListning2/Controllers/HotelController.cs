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
    public class HotelController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork, ILogger<HotelController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotels = await _unitOfWork.Hotels.GetAll();
                var resutl = _mapper.Map<IList<HotelDTO>>(hotels);
                return Ok(resutl);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error - {ex.Message}");
                return StatusCode(500, "Internal Server Error.");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var hotel = await _unitOfWork.Hotels.Get(x => x.Id.Equals(id));
                var resutl = _mapper.Map<HotelDTO>(hotel);
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
