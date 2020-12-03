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
    public class TagController : ControllerBase
    {
        private readonly ITagService _tags;
        private readonly IMapper _mapper;
        public TagController(ITagService tags, IMapper mapper)
        {
            _tags = tags;
            _mapper = mapper;
        }


        [HttpGet("Read")]
        public IActionResult Get()
        {
            var tags = _tags.GetTags();
            return Ok(_mapper.Map<IEnumerable<TagDto>>(tags));
        }

        [HttpGet("ReadById/{id}")]
        public IActionResult Get(Guid id)
        {
            var tag = _tags.GetTagById(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TagDto>(tag));
        }

        [HttpGet("ReadByCourseId/{id}")]
        public IActionResult GetByCourseId(Guid courseId)
        {
            var tags = _tags.GetTagsByCourseId(courseId);
            if (tags.Count() == 0)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<TagDto>>(tags));
        }

        [HttpPost("Create")]
        public IActionResult Post(TagDto tag)
        {
            if (ModelState.IsValid)
            {
                var _tag = _mapper.Map<Tag>(tag);
                var item = _tags.CreateTag(_tag);
                return Created("", item);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update")]
        public IActionResult Put(TagDto tag)
        {
            if (ModelState.IsValid)
            {
                var _tag = _mapper.Map<Tag>(tag);
                return StatusCode((int)HttpStatusCode.NoContent, _tags.UpdateTag(_tag));
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _tags.Delete(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}
