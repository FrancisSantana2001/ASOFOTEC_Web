using ASOFOTEC_Web.Data;
using ASOFOTEC_Web.DTOs;
using ASOFOTEC_Web.Models;
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

        public UserController(AppdbContext appContext, IValidator<InsertUsersDto> InsertValidator, IValidator<UpdateUsersDto> updateValidator)
        {
            _context = appContext;
            _insertValidator = InsertValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IEnumerable<UsersDto>> Get()
        {
            

            return await _context.ModelUsers.Select(u => new UsersDto
            {
                Id = u.Id,
                Id_Card = u.Id_Card,
                Name = u.Name,
                Last_Name = u.Last_Name,
                Email = u.Email,
                Age = u.Age,
                Phone = u.Phone,
                Country = u.Country,
                Adress = u.Adress
            }).ToListAsync();

        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<UsersDto>> GetById(int id)
        {
            var user = await _context.ModelUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var DtoUser = new UsersDto
            {
                Id = user.Id,
                Id_Card = user.Id_Card,
                Name = user.Name,
                Last_Name = user.Last_Name,
                Email = user.Email,
                Age = user.Age,
                Phone = user.Phone,
                Country = user.Country,
                Adress = user.Adress
            };

            return Ok(DtoUser);


        }

        [HttpPost]
        public async Task<ActionResult<ModelUser>> Insert(InsertUsersDto insertUsers)
        {
            var validationResult = await _insertValidator.ValidateAsync(insertUsers);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }


            var user = new ModelUser
            {
                Id_Card = insertUsers.Id_Card,
                Name = insertUsers.Name,
                Last_Name = insertUsers.Last_Name,
                Email = insertUsers.Email,
                Age = insertUsers.Age,
                Phone = insertUsers.Phone,
                Country = insertUsers.Country,
                Adress = insertUsers.Adress

            };

            await _context.ModelUsers.AddAsync(user);
            await _context.SaveChangesAsync();

            var UserDto = new UsersDto
            {
                Id = user.Id,
                Id_Card = user.Id_Card,
                Name = user.Name,
                Last_Name = user.Last_Name,
                Email = user.Email,
                Age = user.Age,
                Phone = user.Phone,
                Country = user.Country,
                Adress = user.Adress
            };

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, UserDto);

        }


        [HttpPut("{Id}")]
        public async Task<ActionResult<UsersDto>> Update(int id, UpdateUsersDto updateUsers)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateUsers);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var user = await _context.ModelUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.Id_Card = updateUsers.Id_Card;
            user.Name = updateUsers.Name;
            user.Last_Name = updateUsers.Last_Name;
            user.Email = updateUsers.Email;
            user.Age = updateUsers.Age;
            user.Phone = updateUsers.Phone;
            user.Country = updateUsers.Country;
            user.Adress = updateUsers.Adress;
            await _context.SaveChangesAsync();

            var UserDto = new UsersDto
            {
                Id = user.Id,
                Id_Card = user.Id_Card,
                Name = user.Name,
                Last_Name = user.Last_Name,
                Email = user.Email,
                Age = user.Age,
                Phone = user.Phone,
                Country = user.Country,
                Adress = user.Adress
            };
            return Ok(UserDto);


        }

        [HttpDelete ("{Id}")]
        public async Task<ActionResult<UsersDto>> Delete(int id)
        {
            var user = await _context.ModelUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.ModelUsers.Remove(user);
            await _context.SaveChangesAsync();

            var UserDto = new UsersDto
            {
                Id = user.Id,
                Id_Card = user.Id_Card,
                Name = user.Name,
                Last_Name = user.Last_Name,
                Email = user.Email,
                Age = user.Age,
                Phone = user.Phone,
                Country = user.Country,
                Adress = user.Adress
            };
            return Ok(UserDto);

        }
    }
}
