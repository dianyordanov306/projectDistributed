using System;
using System.Collections.Generic;
using System.Text;
using StudySprint.Data.Entities;
using StudySprint.Repository.Interfaces;
using StudySprint.Services.DTOs;
using StudySprint.Services.Interfaces;

namespace StudySprint.Services
{
    public class StudySessionService : IStudySessionService
    {
        private readonly IRepository<StudySession> _repository;

        public StudySessionService(IRepository<StudySession> repository)
        {
            _repository = repository;
        }

        public async Task<CreateStudySessionDto> Create(CreateStudySessionDto dto)
        {
            var session =
                new StudySession
                {
                    Title = dto.Title,

                    Subject = dto.Subject,

                    DurationMinutes = dto.DurationMinutes,

                    SessionDate = dto.SessionDate,

                    Difficulty = dto.Difficulty,

                    UserId = dto.UserId
                };

            await _repository
                .Create(session);

            return dto;
        }

        public async Task<IEnumerable<GetStudySessionDto>> GetAll()
        {
            var sessions = await _repository.GetAll();

            return sessions.Select(x =>
                    new GetStudySessionDto
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Subject = x.Subject,
                        DurationMinutes = x.DurationMinutes,
                        SessionDate = x.SessionDate,
                        Difficulty = x.Difficulty,
                        UserId = x.UserId
                    });
        }

        public async Task<GetStudySessionDto?> GetById(int id)
        {
            var session = await _repository.GetById(id);

            if (session == null)
                return null;

            return new GetStudySessionDto
            {
                Id = session.Id,
                Title = session.Title,
                Subject = session.Subject,
                DurationMinutes = session.DurationMinutes,
                SessionDate = session.SessionDate,
                Difficulty = session.Difficulty,
                UserId = session.UserId
            };
        }

        public async Task<bool> Update(int id, CreateStudySessionDto dto)
        {
            var session = await _repository.GetById(id);

            if (session == null)
                return false;

            session.Title = dto.Title;
            session.Subject = dto.Subject;
            session.DurationMinutes = dto.DurationMinutes;
            session.SessionDate = dto.SessionDate;
            session.Difficulty = dto.Difficulty;

            return await _repository.Update(session);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteById(id);
        }
    }
}