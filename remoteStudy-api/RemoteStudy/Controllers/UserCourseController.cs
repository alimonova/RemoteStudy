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
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseService _userCourses;
        private readonly IMapper _mapper;
        public UserCourseController(IUserCourseService userCourses, IMapper mapper)
        {
            _userCourses = userCourses;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin, Teacher")]
        [HttpGet("Read")]
        public IActionResult Get()
        {
            var userCourses = _userCourses.GetUserCourses();
            return Ok(_mapper.Map<IEnumerable<UserCourseDto>>(userCourses));
        }

        [Authorize(Roles = "Admin, Teacher")]
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

        [Authorize(Roles = "Teacher")]
        [HttpGet("GetRequests/{id}")]
        public IActionResult GetRequests(Guid courseId)
        {
            var userCourse = _userCourses.GetUserCourseById(courseId);
            if (userCourse == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserCourseDto>(userCourse));
        }

        [Authorize(Roles = "Student")]
        [HttpPost("Create")]
        public IActionResult Post(UserCourseDto userCourse)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var claim = claims.First(x => x.Type == "UserID").Value;

            userCourse.UserId = Guid.Parse(claim);
            userCourse.HasAccess = false;
            if (ModelState.IsValid)
            {
                var _userCourse = _mapper.Map<UserCourse>(userCourse);
                var item = _userCourses.CreateUserCourse(_userCourse);
                return Created("", item);
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Student")]
        [HttpPut("RateCourse/{courseId}/{rate}")]
        public IActionResult RateCourse(Guid courseId, double rate)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var claim = claims.First(x => x.Type == "UserID").Value;

            var rating = _userCourses.RateCourse(Guid.Parse(claim), courseId, rate);
            return Ok(rating);
        }

        [Authorize(Roles = "Teacher")]
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _userCourses.Delete(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPut("AcceptRequest/{id}")]
        public IActionResult AcceptRequest(Guid id)
        {
            _userCourses.AcceptRequest(id);
            return Ok();
        }

        [Authorize]
        [HttpGet("CheckAccess/{courseId}")]
        public IActionResult CheckAccess(Guid courseId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var claim = claims.First(x => x.Type == "UserID").Value;

            return Ok(_userCourses.UserHasAccessToCourse(Guid.Parse(claim), courseId));
        }
    }
}
