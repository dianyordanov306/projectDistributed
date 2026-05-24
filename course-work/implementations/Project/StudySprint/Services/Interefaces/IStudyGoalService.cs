using System;
using System.Collections.Generic;
using System.Text;
using StudySprint.Services.DTOs;

namespace StudySprint.Services.Interfaces
{
    public interface IStudyGoalService
    {
        Task<IEnumerable<GetStudyGoalDto>> GetAll();

        Task<GetStudyGoalDto?> GetById(int id);

        Task<CreateStudyGoalDto> Create(CreateStudyGoalDto dto);

        Task<bool> Update(int id, CreateStudyGoalDto dto);

        Task<bool> Delete(int id);
    }
}