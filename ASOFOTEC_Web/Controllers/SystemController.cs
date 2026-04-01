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
            var SystemDto = await _systemService.Insert(insertSystem);

            return CreatedAtAction(nameof(GetbyId), new { id = SystemDto.SystemID }, SystemDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateSystemDto updateSystem)
        {
            var system = await _systemService.Update(id, updateSystem);

            return system == null ? NotFound() : Ok(system);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        { 
           var systemDto = await _systemService.Delete(id);
            return systemDto == null ? NotFound() : Ok(systemDto);

        }
    }
}
