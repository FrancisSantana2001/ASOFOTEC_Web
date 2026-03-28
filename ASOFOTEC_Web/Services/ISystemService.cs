using ASOFOTEC_Web.DTOs;

namespace ASOFOTEC_Web.Services
{
    public interface ISystemService
    {
        Task<IEnumerable<SystemDto>> GetSystem();
        Task<SystemDto> GetbyId(int id);
        Task<SystemDto> Insert(InsertSystemDto insertSystem);
        Task<SystemDto> Update(int id, UpdateSystemDto updateSystem);
        Task<SystemDto> Delete(int id);
    }
}
