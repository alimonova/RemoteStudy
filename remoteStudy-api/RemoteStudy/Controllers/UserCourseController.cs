using AutoMapper;
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
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseService _userCourses;
        private readonly IMapper _mapper;
        public UserCourseController(IUserCourseService userCourses, IMapper mapper)
        {
            _userCourses = userCourses;
            _mapper = mapper;
        }

        [HttpGet("Read")]
        public IActionResult Get()
        {
            var userCourses = _userCourses.GetUserCourses();
            return Ok(_mapper.Map<IEnumerable<UserCourseDto>>(userCourses));
        }

        [HttpGet("ReadById/{id}")]
        public IActionResult Get(Guid id)
        {
            var userCourse = _userCourses.GetUserCourseById(id);
            if (userCourse == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserCourseDto>(userCourse));
        }

        [HttpPost("Create")]
        public IActionResult Post(UserCourseDto userCourse)
        {
            if (ModelState.IsValid)
            {
                var _userCourse = _mapper.Map<UserCourse>(userCourse);
                var item = _userCourses.CreateUserCourse(_userCourse);
                return Created("", item);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _userCourses.Delete(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
