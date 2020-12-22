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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjects;
        private readonly IMapper _mapper;
        public SubjectController(ISubjectService subjects, IMapper mapper)
        {
            _subjects = subjects;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("Read")]
        public IActionResult Get()
        {
            var subjects = _subjects.GetSubjects();
            return Ok(_mapper.Map<IEnumerable<SubjectDto>>(subjects));
        }

        [Authorize]
        [HttpGet("ReadById/{id}")]
        public IActionResult Get(Guid id)
        {
            var subject = _subjects.GetSubjectById(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SubjectDto>(subject));
        }

        [Authorize]
        [HttpGet("ReadByCourseId/{id}")]
        public IActionResult GetByCourseId(Guid id)
        {
            var subject = _subjects.GetSubjectByCourseId(id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SubjectDto>(subject));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public IActionResult Post(SubjectDto subject)
        {
            if (ModelState.IsValid)
            {
                var _subject = _mapper.Map<Subject>(subject);
                var item = _subjects.CreateSubject(_subject);
                return Created("", item);
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Update")]
        public IActionResult Put(SubjectDto subject)
        {
            if (ModelState.IsValid)
            {
                var _subject = _mapper.Map<Subject>(subject);
                return StatusCode((int)HttpStatusCode.NoContent, _subjects.UpdateSubject(_subject));
            }

            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _subjects.Delete(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}