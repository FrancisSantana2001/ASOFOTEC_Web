using ASOFOTEC_Web.Data;
using ASOFOTEC_Web.DTOs;
using ASOFOTEC_Web.Models;
using ASOFOTEC_Web.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASOFOTEC_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AppdbContext _context;
        private IValidator<InsertUsersDto> _insertValidator;
        private IValidator<UpdateUsersDto> _updateValidator;
        private IUserService _UserService;

        public UserController(AppdbContext appContext,
            IValidator<InsertUsersDto> InsertValidator,
            IValidator<UpdateUsersDto> updateValidator,
            IUserService UserService)
        {
            _context = appContext;
            _insertValidator = InsertValidator;
            _updateValidator = updateValidator;
            _UserService = UserService;
        }

        [HttpGet]
        public async Task<IEnumerable<UsersDto>> Get()
        {
            return await _UserService.Get();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<UsersDto>> GetById(int id)
        {
            var userDto = await _UserService.GetById(id);
            return userDto == null ? NotFound() : Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<ModelUser>> Insert(InsertUsersDto insertUsers)
        {
            var validationResult = await _insertValidator.ValidateAsync(insertUsers);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var userDto = await _UserService.Insert(insertUsers);

            return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);

        }


        [HttpPut("{Id}")]
        public async Task<ActionResult<UsersDto>> Update(int id, UpdateUsersDto updateUsers)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateUsers);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var userDto = await _UserService.Update(id, updateUsers);
            return userDto == null ? NotFound() : Ok(userDto);

        }

        [HttpDelete ("{Id}")]
        public async Task<ActionResult<UsersDto>> Delete(int id)
        {
            var userDto = await _UserService.Delete(id);
            return userDto == null ? NotFound() : Ok(userDto);

        }
    }
}
