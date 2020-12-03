using AutoMapper;
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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courses;
        private readonly IMapper _mapper;
        public CourseController(ICourseService courses, IMapper mapper)
        {
            _courses = courses;
            _mapper = mapper;
        }


        [HttpGet("Read")]
        public IActionResult Get()
        {
            var courses = _courses.GetCourses();
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(courses));
        }

        [HttpGet("ReadById/{id}")]
        public IActionResult Get(Guid id)
        {
            var course = _courses.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CourseDto>(course));
        }

        [HttpGet("ReadByCourseId/{teacherId}")]
        public IActionResult GetByCourseId(Guid courseId)
        {
            var courses = _courses.GetCoursesByTeacherId(courseId);
            if (courses.Count() == 0)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(courses));
        }

        [HttpPost("Create")]
        public IActionResult Post(CourseDto course)
        {
            if (ModelState.IsValid)
            {
                var _course = _mapper.Map<Course>(course);
                var item = _courses.CreateCourse(_course);
                return Created("", item);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update")]
        public IActionResult Put(CourseDto course)
        {
            if (ModelState.IsValid)
            {
                var _course = _mapper.Map<Course>(course);
                return StatusCode((int)HttpStatusCode.NoContent, _courses.UpdateCourse(_course));
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _courses.Delete(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}