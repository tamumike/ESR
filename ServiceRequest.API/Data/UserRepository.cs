using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ServiceRequest.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        public UserRepository(IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env, IConfiguration configuration)
        {
            _configuration = configuration;
            _env = env;
            _httpContextAccessor = httpContextAccessor;

        }

        public string GetUserInformation()
        {
            var info = _configuration.GetSection("UserInformation");
            return info["Group"];
        }

        public string GetUsername()
        {
            string username = null;

            if (_env.IsDevelopment())
            {
                username = Environment.UserName;
            }
            else
            {
                username = _httpContextAccessor.HttpContext.User.Identity.Name;
            }

            return username;
        }
    }
}