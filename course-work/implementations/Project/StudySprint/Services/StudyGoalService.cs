using System;
using System.Collections.Generic;
using System.Text;
using StudySprint.Data.Entities;
using StudySprint.Repository.Interfaces;
using StudySprint.Services.DTOs;
using StudySprint.Services.Interfaces;

namespace StudySprint.Services
{
    public class StudyGoalService : IStudyGoalService
    {
        private readonly IRepository<StudyGoal> _repository;

        public StudyGoalService(IRepository<StudyGoal> repository)
        {
            _repository = repository;
        }

        public async Task<CreateStudyGoalDto> Create(CreateStudyGoalDto dto)
        {
            var goal = new StudyGoal
            {
                GoalTitle = dto.GoalTitle,
                TargetHours = dto.TargetHours,
                Deadline = dto.Deadline,
                Completed = dto.Completed,
                Priority = dto.Priority,
                UserId = dto.UserId
            };

            await _repository.Create(goal);

            return dto;
        }

        public async Task<IEnumerable<GetStudyGoalDto>> GetAll(int page, int pageSize, string? sortBy)
        {
            var goals = await _repository.GetAll();

            goals = sortBy?.ToLower() switch
            {
                "title" => goals.OrderBy(x => x.GoalTitle),
                "priority" => goals.OrderBy(x => x.Priority),
                "deadline" => goals.OrderBy(x => x.Deadline),
                _ => goals.OrderBy(x => x.Id)
            };

            goals = goals
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return goals.Select(x => new GetStudyGoalDto
            {
                Id = x.Id,
                GoalTitle = x.GoalTitle,
                TargetHours = x.TargetHours,
                Deadline = x.Deadline,
                Completed = x.Completed,
                Priority = x.Priority,
                UserId = x.UserId
            });
        }
        public async Task<GetStudyGoalDto?> GetById(int id)
        {
            var goal = await _repository.GetById(id);

            if (goal == null)
                return null;

            return new GetStudyGoalDto
            {
                Id = goal.Id,
                GoalTitle = goal.GoalTitle,
                TargetHours = goal.TargetHours,
                Deadline = goal.Deadline,
                Completed = goal.Completed,
                Priority = goal.Priority,
                UserId = goal.UserId
            };
        }

        public async Task<bool> Update(int id, CreateStudyGoalDto dto)
        {
            var goal = await _repository.GetById(id);

            if (goal == null)
                return false;

            goal.GoalTitle = dto.GoalTitle;
            goal.TargetHours = dto.TargetHours;
            goal.Deadline = dto.Deadline;
            goal.Completed = dto.Completed;
            goal.Priority = dto.Priority;

            return await _repository.Update(goal);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteById(id);
        }

        public async Task<IEnumerable<GetStudyGoalDto>> Search(string? title, bool? completed)
        {
            var goals = await _repository.GetAll();

            if (!string.IsNullOrWhiteSpace(title))
            {
                goals = goals.Where(x => x.GoalTitle.ToLower().Contains(title.ToLower()));
            }

            if (completed.HasValue)
            {
                goals = goals.Where(x => x.Completed == completed.Value);
            }

            return goals.Select(x => new GetStudyGoalDto
            {
                Id = x.Id,
                GoalTitle = x.GoalTitle,
                TargetHours = x.TargetHours,
                Deadline = x.Deadline,
                Completed = x.Completed,
                Priority = x.Priority,
                UserId = x.UserId
            });
        }
    }
}
