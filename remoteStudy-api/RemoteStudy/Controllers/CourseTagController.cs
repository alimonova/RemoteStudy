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
    public class CourseTagController : ControllerBase
    {
        private readonly ICourseTagService _courseTags;
        private readonly IMapper _mapper;
        public CourseTagController(ICourseTagService courseTags, IMapper mapper)
        {
            _courseTags = courseTags;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("Read")]
        public IActionResult Get()
        {
            var courseTags = _courseTags.GetCourseTags();
            return Ok(_mapper.Map<IEnumerable<CourseTagDto>>(courseTags));
        }

        [Authorize]
        [HttpGet("ReadById/{id}")]
        public IActionResult Get(Guid id)
        {
            var courseTag = _courseTags.GetCourseTagById(id);
            if (courseTag == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CourseTagDto>(courseTag));
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost("Create")]
        public IActionResult Post(CourseTagDto courseTag)
        {
            if (ModelState.IsValid)
            {
                var _courseTag = _mapper.Map<CourseTag>(courseTag);
                var item = _courseTags.CreateCourseTag(_courseTag);
                return Created("", item);
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Teacher")]
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _courseTags.Delete(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}