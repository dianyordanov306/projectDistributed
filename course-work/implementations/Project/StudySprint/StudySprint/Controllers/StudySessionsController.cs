using Microsoft.AspNetCore.Mvc;
using StudySprint.Services.DTOs;
using StudySprint.Services.Interfaces;

namespace StudySprint.API.Controllers
    {
        [ApiController]
        [Route("api/study-sessions")]
        public class StudySessionController : ControllerBase
        {
            private readonly IStudySessionService _service;

            public StudySessionController(IStudySessionService service)
            {
                _service = service;
            }


        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? sortBy = null)
        {
            var result = await _service.GetAll(page, pageSize, sortBy);

            return Ok(result);
        }

        [HttpPost]
            public async Task<ActionResult> Create(CreateStudySessionDto dto)
            {
                return Ok(await _service.Create(dto));
            }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CreateStudySessionDto dto)
        {
            var result = await _service.Update(id, dto);

            if (!result)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<ActionResult> Search([FromQuery] string? subject, [FromQuery] int? difficulty)
        {
            var result = await _service.Search(subject, difficulty);

            return Ok(result);
        }
    }
}
