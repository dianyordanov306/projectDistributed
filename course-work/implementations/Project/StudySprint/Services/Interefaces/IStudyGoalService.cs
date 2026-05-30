using System;
using System.Collections.Generic;
using System.Text;
using StudySprint.Services.DTOs;

namespace StudySprint.Services.Interfaces
{
    public interface IStudyGoalService
    {
        Task<IEnumerable<GetStudyGoalDto>> GetAll(int page, int pageSize, string? sortBy);

        Task<GetStudyGoalDto?> GetById(int id);

        Task<CreateStudyGoalDto> Create(CreateStudyGoalDto dto);

        Task<bool> Update(int id, CreateStudyGoalDto dto);

        Task<bool> Delete(int id);

        Task<IEnumerable<GetStudyGoalDto>> Search(string? title, bool? completed);
    }
}