using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceRequest.API.Data;

namespace ServiceRequest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IUserRepository repo, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _repo = repo;

        }

        [HttpGet]
        public string GetUsername()
        {
            var username = _repo.GetUsername();
            Response.Cookies.Append("Username", username);

            return username;
        }

        [HttpGet("UserInfo")]
        public string GetUserInfo()
        {
            return _repo.GetUserInformation();
        }

    }
}