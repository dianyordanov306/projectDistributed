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
            public async Task<ActionResult> Get()
            {
                return Ok(await _service.GetAll());
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
    }
    }
