using ASOFOTEC_Web.DTOs;

namespace ASOFOTEC_Web.Services
{
    public interface IPostService
    {
        public Task<IEnumerable<PostDto>> Get();
        
    }

    public interface IPostSeviceUser
    {
        public Task<IEnumerable<UsersDto>> GetUsers();
    }
}
