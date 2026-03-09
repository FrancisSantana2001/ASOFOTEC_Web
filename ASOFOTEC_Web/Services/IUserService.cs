using ASOFOTEC_Web.DTOs;

namespace ASOFOTEC_Web.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UsersDto>> Get();
        Task<UsersDto> GetById(int id);
        Task<UsersDto> Insert(InsertUsersDto insertUsersDto);
        Task<UsersDto>Update(int id, UpdateUsersDto updateUsersDto);
        Task<UsersDto>Delete(int id);
    }
}
