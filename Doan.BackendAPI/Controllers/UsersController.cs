using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doan.Application.Systems.Users;
using Doan.ViewModels.Systems.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doan.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        ///ex http:abc/api/users/authenticate
        public async Task<ActionResult> Authenticate([FromForm] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.Authenticate(request);
            if (!result.IsSuccesed)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.ResultObj);
        }

        [AllowAnonymous]
        [HttpPost("register/customer")]
        ///ex http:abc/api/users/register/cus
        public async Task<ActionResult> RegisterCus([FromForm] RegisterRequestCustomer request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.RegisterCus(request);
            if (!result.IsSuccesed)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.ResultObj);
        }

        [AllowAnonymous]
        [HttpPost("register/supplier")]
        ///ex http:abc/api/users/register/cus
        public async Task<ActionResult> RegisterSup([FromForm] RegisterRequestSupplier request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.RegisterSup(request);
            if (!result.IsSuccesed)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.ResultObj);
        }
    }
}