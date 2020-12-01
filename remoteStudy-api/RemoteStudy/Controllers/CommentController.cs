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
        public ActionResult<CommentDto> Get()
        {
            var comments = _comments.GetComments();
            return Ok(_mapper.Map<IEnumerable<CommentDto>>(comments));
        }

        [HttpGet("ReadById/{id}")]
        public ActionResult<CommentDto> Get(Guid id)
        {
            var comment = _comments.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommentDto>(comment));
        }

        [HttpGet("ReadByLessonId/{id}")]
        public ActionResult<CommentDto> GetByLessonId(Guid lessonId)
        {
            var comments = _comments.GetCommentsByLessonId(lessonId);
            if (comments == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<CommentDto>>(comments));
        }


        [HttpPost("Create")]
        public ActionResult<Comment> Post(CommentDto comment)
        {
            if (ModelState.IsValid)
            {
                var _comment = _mapper.Map<Comment>(comment);
                var item = _comments.CreateComment(_comment);
                return CreatedAtAction("", item);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update")]
        public IActionResult Put(CommentDto comment)
        {
            if (ModelState.IsValid)
            {
                var _comment = _mapper.Map<Comment>(comment);
                return StatusCode((int)HttpStatusCode.NoContent, _comments.UpdateComment(_comment));
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _comments.Delete(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
