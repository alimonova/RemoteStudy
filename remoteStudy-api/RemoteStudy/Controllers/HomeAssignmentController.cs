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
    public class HomeAssignmentController : ControllerBase
    {
        private readonly IHomeAssignmentService _homeAssignments;
        private readonly IMapper _mapper;
        public HomeAssignmentController(IHomeAssignmentService homeAssignments, IMapper mapper)
        {
            _homeAssignments = homeAssignments;
            _mapper = mapper;
        }


        [HttpGet("Read")]
        public IActionResult Get()
        {
            var homeAssignments = _homeAssignments.GetHomeAssignments();
            return Ok(_mapper.Map<IEnumerable<HomeAssignmentDto>>(homeAssignments));
        }

        [HttpGet("ReadById/{id}")]
        public IActionResult Get(Guid id)
        {
            var homeAssignment = _homeAssignments.GetHomeAssignmentById(id);
            if (homeAssignment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<HomeAssignmentDto>(homeAssignment));
        }

        [HttpGet("ReadByLessonId/{id}")]
        public IActionResult GetByLessonId(Guid lessonId)
        {
            var homeAssignments = _homeAssignments.GetHomeAssignmentsByLessonId(lessonId);
            if (homeAssignments.Count() == 0)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<HomeAssignmentDto>>(homeAssignments));
        }

        [HttpPost("Create")]
        public IActionResult Post(HomeAssignmentDto homeAssignment)
        {
            if (ModelState.IsValid)
            {
                var _homeAssignment = _mapper.Map<HomeAssignment>(homeAssignment);
                var item = _homeAssignments.CreateHomeAssignment(_homeAssignment);
                return Created("", item);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update")]
        public IActionResult Put(HomeAssignmentDto homeAssignment)
        {
            if (ModelState.IsValid)
            {
                var _homeAssignment = _mapper.Map<HomeAssignment>(homeAssignment);
                return StatusCode((int)HttpStatusCode.NoContent, _homeAssignments.UpdateHomeAssignment(_homeAssignment));
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _homeAssignments.Delete(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
