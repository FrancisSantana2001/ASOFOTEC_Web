using ASOFOTEC_Web.Data;
using ASOFOTEC_Web.DTOs;
using ASOFOTEC_Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ASOFOTEC_Web.Services
{
    public class SystemService : ISystemService
    {
        private AppdbContext _Context;
        private IMapper _Mapper;
        public SystemService( AppdbContext DbContext, IMapper Mapper)
        {
            _Context = DbContext;
            _Mapper = Mapper;
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

        public async Task<SystemDto> Insert(InsertSystemDto insertSystem)
        {
            var System = _Mapper.Map<Systems>(insertSystem);

            await _Context.Systems.AddAsync(System);
            await _Context.SaveChangesAsync();

            var SystemDto = _Mapper.Map<SystemDto>(System);

            return SystemDto;
        }

        public async Task<SystemDto> Update(int id, UpdateSystemDto updateSystem)
        {
            var existingSystem = await _Context.Systems.FindAsync(id);

            if(existingSystem != null)
            {
                existingSystem.SystemName = updateSystem.SystemName;
                existingSystem.Description = updateSystem.Description;
                existingSystem.DeveloperName = updateSystem.DeveloperName;
                existingSystem.DateDeveloped = updateSystem.DateDeveloped;
                await _Context.SaveChangesAsync();
                var systemDto = new SystemDto
                {
                    SystemID = existingSystem.SystemID,
                    SystemName = existingSystem.SystemName,
                    Description = existingSystem.Description,
                    DeveloperName = existingSystem.DeveloperName,
                    DateDeveloped = existingSystem.DateDeveloped
                };
                return systemDto;
            }

            return null;
        }

        public async Task<SystemDto> Delete(int id)
        {
            var SystemDelete = await _Context.Systems.FindAsync(id);

            if (SystemDelete != null)
            {
                var systemDto = new SystemDto
                {
                    SystemID = SystemDelete.SystemID,
                    SystemName = SystemDelete.SystemName,
                    Description = SystemDelete.Description,
                    DeveloperName = SystemDelete.DeveloperName,
                    DateDeveloped = SystemDelete.DateDeveloped
                };
                _Context.Systems.Remove(SystemDelete);
                await _Context.SaveChangesAsync();
                return systemDto;
            }
            return null;
        }
    }
}
