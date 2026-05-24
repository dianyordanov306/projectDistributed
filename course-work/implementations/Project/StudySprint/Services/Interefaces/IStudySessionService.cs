using System;
using System.Collections.Generic;
using System.Text;
using StudySprint.Services.DTOs;

namespace StudySprint.Services.Interfaces
{
    public interface IStudySessionService
    {
        Task<IEnumerable<GetStudySessionDto>> GetAll();

        Task<GetStudySessionDto?> GetById(int id);

        Task<CreateStudySessionDto> Create(CreateStudySessionDto dto);

        Task<bool> Update(int id, CreateStudySessionDto dto);

        Task<bool> Delete(int id);
    }
}