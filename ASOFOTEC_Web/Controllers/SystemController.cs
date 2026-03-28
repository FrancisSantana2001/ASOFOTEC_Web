using ASOFOTEC_Web.Data;
using ASOFOTEC_Web.DTOs;
using ASOFOTEC_Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASOFOTEC_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private AppdbContext _context;
        private ISystemService _systemService;

        public SystemController(AppdbContext context, SystemService systemService)
        {
            _context = context;
            _systemService = systemService;
        }

        [HttpGet]
        public async Task<IEnumerable<SystemDto>> GetSystem()
        {
            return await _systemService.GetSystem();
        }

        [HttpGet ("{id}")]
        public async Task <ActionResult<SystemDto>>GetbyId(int id)
        {
            var system = await _systemService.GetbyId(id);
            return system == null ? NotFound() : Ok(system);
        }

        [HttpPost]
        public async Task<ActionResult<SystemDto>> Insert(InsertSystemDto insertSystem)
        {
            var System = new Models.Systems
            {
                SystemName = insertSystem.SystemName,
                Description = insertSystem.Description,
                DeveloperName = insertSystem.DeveloperName,
                DateDeveloped = insertSystem.DateDeveloped
            };

            await _context.Systems.AddAsync(System);
            await _context.SaveChangesAsync();

            var SystemDto = new SystemDto
            {
                SystemID = System.SystemID,
                SystemName = System.SystemName,
                Description = System.Description,
                DeveloperName = System.DeveloperName,
                DateDeveloped = System.DateDeveloped
            };

            return CreatedAtAction(nameof(GetSystem), new { id = SystemDto.SystemID }, SystemDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateSystemDto updateSystem)
        {
            var existingSystem = await _context.Systems.FindAsync(id);
            if (existingSystem == null)
            {
                return NotFound();
            }
            existingSystem.SystemName = updateSystem.SystemName;
            existingSystem.Description = updateSystem.Description;
            existingSystem.DeveloperName = updateSystem.DeveloperName;
            existingSystem.DateDeveloped = updateSystem.DateDeveloped;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        { 
            var ExSystem = await _context.Systems.FindAsync(id);
            if(ExSystem == null)
            {
                return NotFound();
            }
            _context.Systems.Remove(ExSystem);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
