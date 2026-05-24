using System;
using System.Collections.Generic;
using System.Text;
using StudySprint.Services.DTOs;
using StudySprint.Data.Entities;
using StudySprint.Repository.Interfaces;
using StudySprint.Services.Interfaces;

namespace StudySprint.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User>
            _repository;

        public UserService(
            IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<CreateUserDto> Create(CreateUserDto dto)
        {
            var user =
                new User
                {
                    Username = dto.Username,

                    Email = dto.Email,

                    Password = dto.Password,

                    Role = dto.Role,

                    Age = dto.Age,

                    CreatedAt = DateTime.UtcNow
                };

            await _repository.Create(user);

            return dto;
        }

        public async Task<IEnumerable<GetUserDto>> GetAll()
        {
            var users = await _repository.GetAll();

            return users .Select(x =>
                new GetUserDto{
                        Id =x.Id,

                        Username = x.Username,

                        Email = x.Email,

                        Role = x.Role,

                        Age = x.Age
                    });
        }

        public async Task<GetUserDto?> GetById(int id)
        {
            var user = await _repository.GetById(id);

            if (user == null)
                return null;

            return new GetUserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                Age = user.Age
            };
        }

        public async Task<bool> Update(
    int id,
    UpdateUserDto dto)
        {
            var user = await _repository.GetById(id);

            if (user == null)
                return false;

            user.Username = dto.Username;

            user.Email = dto.Email;

            user.Password = dto.Password;

            user.Role = dto.Role;

            user.Age = dto.Age;

            return await _repository.Update(user);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteById(id);
        }
    }
}
