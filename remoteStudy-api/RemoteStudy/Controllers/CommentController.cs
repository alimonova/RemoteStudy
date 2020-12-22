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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _comments;
        private readonly IMapper _mapper;
        public CommentController(ICommentService comments, IMapper mapper)
        {
            _comments = comments;
            _mapper = mapper;
        }


        [HttpGet("Read")]
        public IActionResult Get()
        {
            var comments = _comments.GetComments();
            return Ok(_mapper.Map<IEnumerable<CommentDto>>(comments));
        }

        [HttpGet("ReadById/{id}")]
        public IActionResult Get(Guid id)
        {
            var comment = _comments.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommentDto>(comment));
        }

        [HttpGet("ReadByLessonId/{id}")]
        public IActionResult GetByLessonId(Guid lessonId)
        {
            var comments = _comments.GetCommentsByLessonId(lessonId);
            if (comments.Count() == 0)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<CommentDto>>(comments));
        }

        [HttpPost("Create")]
        public IActionResult Post(CommentDto comment)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var claim = claims.First(x => x.Type == "UserID").Value;

            comment.UserId = Guid.Parse(claim);
            if (ModelState.IsValid)
            {
                var _comment = _mapper.Map<Comment>(comment);
                var item = _comments.CreateComment(_comment);
                return Created("", item);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update")]
        public IActionResult Put(CommentDto comment)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var claim = claims.First(x => x.Type == "UserID").Value;

            if (ModelState.IsValid)
            {
                var _comment = _mapper.Map<Comment>(comment);
                return StatusCode((int)HttpStatusCode.NoContent, _comments.UpdateComment(_comment, Guid.Parse(claim)));
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var claim = claims.First(x => x.Type == "UserID").Value;

            _comments.Delete(id, Guid.Parse(claim));
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
