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

        [HttpGet("ReadFavourites")]
        public IActionResult GetFavourites()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var claim = claims.First(x => x.Type == "UserID").Value;

            var userCourses = _userCourses.GetFavouriteCourses(Guid.Parse(claim));
            return Ok(_mapper.Map<IEnumerable<UserCourseDto>>(userCourses));
        }

        [HttpGet("AddToFavourites/{courseId}")]
        public IActionResult AddToFavourites(Guid courseId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var claim = claims.First(x => x.Type == "UserID").Value;

            var userCourse = _userCourses.AddCourseToFavourites(Guid.Parse(claim), courseId);
            return Ok(_mapper.Map<UserCourseDto>(userCourse));
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
