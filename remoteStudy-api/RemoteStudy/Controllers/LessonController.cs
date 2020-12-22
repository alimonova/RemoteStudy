using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RemoteStudy.Dto;
using RemoteStudy.Models;
using RemoteStudy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RemoteStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessons;
        private readonly IMapper _mapper;
        public LessonController(ILessonService lessons, IMapper mapper)
        {
            _lessons = lessons;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("Read")]
        public IActionResult Get()
        {
            var lessons = _lessons.GetLessons();
            return Ok(_mapper.Map<IEnumerable<LessonDto>>(lessons));
        }

        [Authorize]
        [HttpGet("ReadById/{id}")]
        public IActionResult Get(Guid id)
        {
            var lesson = _lessons.GetLessonById(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<LessonDto>(lesson));
        }

        [Authorize]
        [HttpGet("ReadByCourseId/{id}")]
        public IActionResult GetByCourseId(Guid courseId)
        {
            var lessons = _lessons.GetLessonsByCourseId(courseId);
            if (lessons.Count() == 0)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<LessonDto>>(lessons));
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost("Create")]
        public IActionResult Post(LessonDto lesson)
        {
            if (ModelState.IsValid)
            {
                var _lesson = _mapper.Map<Lesson>(lesson);
                var item = _lessons.CreateLesson(_lesson);
                return Created("", item);
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPut("Update")]
        public IActionResult Put(LessonDto lesson)
        {
            if (ModelState.IsValid)
            {
                var _lesson = _mapper.Map<Lesson>(lesson);
                return StatusCode((int)HttpStatusCode.NoContent, _lessons.UpdateLesson(_lesson));
            }

            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Teacher")]
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _lessons.Delete(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
