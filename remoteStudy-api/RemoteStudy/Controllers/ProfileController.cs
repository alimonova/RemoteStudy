using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    [Route("[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly CurrentUserInfo _info;
        private readonly IProfileService _profiles;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _environment;

        public ProfileController(IProfileService profiles, IMapper mapper, CurrentUserInfo info, IHostingEnvironment environment)
        {
            _profiles = profiles;
            _mapper = mapper;
            _info = info;
            _environment = environment;
        }

        [HttpGet("ReadByUserId/{id}")]
        public IActionResult GetByUserId(Guid id)
        {
            var profiles = _profiles.GetProfileByUserId(id);
            return Ok(_mapper.Map<ProfileDto>(profiles));
        }

        [HttpGet("ReadById/{id}")]
        public IActionResult GetById(Guid id)
        {
            var profiles = _profiles.GetProfileById(id);
            return Ok(_mapper.Map<ProfileDto>(profiles));
        }


        [Authorize]
        [HttpGet("ReadMyInfo")]
        public IActionResult GetMyInfo()
        {
            var profile = _profiles.GetMyInfo();
            return Ok(_mapper.Map<ProfileDto>(profile));
        }
    }
}
