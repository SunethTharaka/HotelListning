using AutoMapper;
using HotelListning2.Data;
using HotelListning2.Models;
using HotelListning2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class AccountController : ControllerBase
    {
        private readonly UserManager<APIUser> userManager;
        //private readonly SignInManager<APIUser> signInManager;
        private readonly ILogger<AccountController> logger;
        private readonly IMapper mapper;
        private readonly IAuthManager _authManager;

        public AccountController(UserManager<APIUser> userManager, /*SignInManager<APIUser> signInManager,*/ ILogger<AccountController> logger, IMapper mapper, IAuthManager authManager)
        {
            this.userManager = userManager;
            //this.signInManager = signInManager;
            this.logger = logger;
            this.mapper = mapper;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        {
            logger.LogInformation($"User registration for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = mapper.Map<APIUser>(userDTO);
                user.UserName = user.Email;
                var result = await userManager.CreateAsync(user, userDTO.Password);

                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }
                    return BadRequest("User registration attemp failded");
                }

                await userManager.AddToRolesAsync(user, userDTO.Roles);
                return Accepted();

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error - {ex.Message}");
                return Problem("Internal Server Error.", statusCode: 500);

            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO userDTO)
        {
            logger.LogInformation($"Login registration for {userDTO.Email}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await _authManager.ValidateUser(userDTO))
                {
                    return Unauthorized();
                }

                return Accepted(new { Token = await _authManager.CreateToketn() });

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error - {ex.Message}");
                return Problem("Internal Server Error.", statusCode: 500);

            }
        }

    }
}
