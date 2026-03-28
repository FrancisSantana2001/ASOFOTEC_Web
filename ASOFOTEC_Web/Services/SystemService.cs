using ASOFOTEC_Web.Data;
using ASOFOTEC_Web.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ASOFOTEC_Web.Services
{
    public class SystemService : ISystemService
    {
        private AppdbContext _Context;
        public SystemService( AppdbContext DbContext)
        {
            _Context = DbContext;
        }

        public async Task<SystemDto> GetbyId(int id)
        {
           var system = await _Context.Systems.FindAsync(id);
            if (system != null)
            {
                var systemDto = new SystemDto
                {
                    SystemID = system.SystemID,
                    SystemName = system.SystemName,
                    DateDeveloped = system.DateDeveloped,
                    Description = system.Description,
                    DeveloperName = system.DeveloperName
                };
                return systemDto;
            }
            return null;

        }

        public async Task<IEnumerable<SystemDto>> GetSystem()
        {
           return await _Context.Systems.Select(S => new SystemDto
            {
                SystemID = S.SystemID,
                SystemName = S.SystemName,
                DateDeveloped = S.DateDeveloped,
                Description = S.Description,
                DeveloperName = S.DeveloperName
            }).ToListAsync();
        }

        public Task<SystemDto> Insert(InsertSystemDto insertSystem)
        {
            throw new NotImplementedException();
        }

        public Task<SystemDto> Update(int id, UpdateSystemDto updateSystem)
        {
            throw new NotImplementedException();
        }

        public async Task<SystemDto> Delete(int id) =>
    }
}
