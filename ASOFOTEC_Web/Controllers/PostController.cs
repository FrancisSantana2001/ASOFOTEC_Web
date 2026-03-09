using ASOFOTEC_Web.DTOs;
using ASOFOTEC_Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASOFOTEC_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        IPostService _TitlepostService;
        IPostSeviceUser _ServiceUsers;

        public PostController(IPostService postService, IPostSeviceUser serviceUsers)
        {
            _TitlepostService = postService;
            _ServiceUsers = serviceUsers;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get() => 
            await _TitlepostService.Get();

        [HttpGet]
        public async Task<IEnumerable<UsersDto>> GetUsers() =>
            await _ServiceUsers.GetUsers();
    }
}
