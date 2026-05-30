using StudySprint.Services.DTOs;

namespace StudySprint.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> GetAll(int page, int pageSize, string? sortBy);

        Task<GetUserDto?> GetById(int id);

        Task<CreateUserDto> Create(CreateUserDto dto);

        Task<bool> Update(int id, UpdateUserDto dto);

        Task<bool> Delete(int id);

        Task<IEnumerable<GetUserDto>> Search(string? username, string? role);

    }
}