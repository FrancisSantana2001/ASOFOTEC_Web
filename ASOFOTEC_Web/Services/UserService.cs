using ASOFOTEC_Web.Data;
using ASOFOTEC_Web.DTOs;
using ASOFOTEC_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace ASOFOTEC_Web.Services
{
    public class UserService: IUserService
    {
        private readonly AppdbContext _context;

        public UserService(AppdbContext context)
        {
           _context = context;
        }

        public async Task<UsersDto> Delete(int id)
        {
            var user = await _context.ModelUsers.FindAsync(id);
            if (user == null)
            {
                return null;
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
            return UserDto;
        }

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

        public async Task<UsersDto> GetById(int id)
        {
            var user = await _context.ModelUsers.FindAsync(id);
            if (user == null)
            {
                return null;
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

            return DtoUser;
        }

        public async Task<UsersDto> Insert(InsertUsersDto insertUsers)
        {
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

            return UserDto;
        }

        public async Task<UsersDto> Update(int id, UpdateUsersDto updateUsers)
        {
            var user = await _context.ModelUsers.FindAsync(id);
            if (user == null)
            {
                return null;
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
            return UserDto;
        }
    }
}
