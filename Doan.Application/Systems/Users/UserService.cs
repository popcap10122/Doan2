using Doan.Data.Entites;
using Doan.ViewModels.Common;
using Doan.ViewModels.Systems.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Doan.Application.Systems.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;

        public UserService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
             IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return new ApiErrorResult<string>($"{request.UserName} not exists !!!");
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>(" user Name or pass word incorrect !!!");
            }
            //create claims contain info for token
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[] {
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Role,string.Join(";",roles)),
                new Claim(ClaimTypes.Name, user.UserName )
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],//dia chia dang ky
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(10),
              signingCredentials: credentials);

            if (token == null)
            {
                return new ApiErrorResult<string>("Cannot generate tokens");
            }
            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<bool>> RegisterCus(RegisterRequestCustomer request)
        {
            var check = await CheckUser(request);
            if (!check.IsSuccesed)
            {
                return check;
            }
            Random random = new Random();
            var id = random.Next(1000);
            var user = new AppUser
            {
                Id = String.Concat("K", id.ToString()),
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<bool>("Register fail!");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> RegisterSup(RegisterRequestSupplier request)
        {
            var check = await CheckUser(request);
            if (!check.IsSuccesed)
            {
                return check;
            }
            Random random = new Random();
            var id = random.Next(1000);
            var user = new AppUser
            {
                Id = String.Concat("NCC", id.ToString()),
                UserName = request.UserName,
                Name = request.NameSupplier,
                NameContact = request.NameContract,
                Email = request.Email,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<bool>("Register fail!");
            }
            return new ApiSuccessResult<bool>();
        }

        private async Task<ApiResult<bool>> CheckUser(RegisterBase request)
        {
            var existUser = await _userManager.FindByNameAsync(request.UserName);
            if (existUser != null)
            {
                return new ApiErrorResult<bool>("User Name is exists !");
            }
            var existEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existEmail != null)
            {
                return new ApiErrorResult<bool>("Email is exists !");
            }
            return new ApiSuccessResult<bool>();
        }
    }
}