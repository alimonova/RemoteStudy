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
using System.Security.Claims;
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

        [Authorize]
        [HttpGet("Read")]
        public IActionResult Get([FromQuery] PageFilterSortModel parameters)
        {
            var courses = _courses.GetCourses(parameters);
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(courses));
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize(Roles = "Teacher")]
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

        [Authorize(Roles = "Teacher")]
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

        [Authorize(Roles = "Teacher")]
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _courses.Delete(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [Authorize]
        [HttpGet("ReadFavourites")]
        public IActionResult GetFavourites()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var claim = claims.First(x => x.Type == "UserID").Value;

            var courses = _courses.GetFavouriteCourses(Guid.Parse(claim));
            return Ok(_mapper.Map<IEnumerable<CourseDto>>(courses));
        }

        [Authorize]
        [HttpGet("AddToFavourites/{courseId}")]
        public IActionResult AddToFavourites(Guid courseId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var claim = claims.First(x => x.Type == "UserID").Value;

            _courses.AddCourseToFavourites(Guid.Parse(claim), courseId);
            return StatusCode((int)HttpStatusCode.NoContent);
        }

    }
}