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
    public class HomeAssignmentUserController : ControllerBase
    {
        private readonly IHomeAssignmentUserService _homeAssignmentUsers;
        private readonly IMapper _mapper;
        public HomeAssignmentUserController(IHomeAssignmentUserService homeAssignmentUsers, IMapper mapper)
        {
            _homeAssignmentUsers = homeAssignmentUsers;
            _mapper = mapper;
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet("Read")]
        public IActionResult Get()
        {
            var homeAssignmentUsers = _homeAssignmentUsers.GetHomeAssignmentUsers();
            return Ok(_mapper.Map<IEnumerable<HomeAssignmentUserDto>>(homeAssignmentUsers));
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet("ReadById/{id}")]
        public IActionResult Get(Guid id)
        {
            var homeAssignmentUser = _homeAssignmentUsers.GetHomeAssignmentUserById(id);
            if (homeAssignmentUser == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<HomeAssignmentUserDto>(homeAssignmentUser));
        }

        [Authorize(Roles = "Student")]
        [HttpPost("Create")]
        public IActionResult Post(HomeAssignmentUserDto homeAssignmentUser)
        {
            if (ModelState.IsValid)
            {
                var _homeAssignmentUser = _mapper.Map<HomeAssignmentUser>(homeAssignmentUser);
                var item = _homeAssignmentUsers.CreateHomeAssignmentUser(_homeAssignmentUser);
                return Created("", item);
            }
            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Student")]
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _homeAssignmentUsers.Delete(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPut("GradeAssignment/{homeAssignmentUserId}/{mark}")]
        public IActionResult GradeAssignment(Guid homeAssignmentUserId, double mark)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var claim = claims.First(x => x.Type == "UserID").Value;

            _homeAssignmentUsers.GradeHomeAssignment(homeAssignmentUserId, mark, Guid.Parse(claim));
            return Ok();
        }
    }
}
