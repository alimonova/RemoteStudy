using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RemoteStudy.Dto;
using RemoteStudy.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RemoteStudy.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenSettings _appSettings;
        private readonly RemoteStudyContext _context;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager, IMapper mapper, IOptions<TokenSettings> applicationSettings, RemoteStudyContext context)
        {
            _context = context;
            _userManager = userManager;
            _appSettings = applicationSettings.Value;
            _mapper = mapper;
        }

        [HttpGet("Claims")]
        public IActionResult GetClaims()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var claim = claims.First(x => x.Type == "UserID");
            return Ok(claim);
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Register([FromBody] UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { Email = model.Email, Id = Guid.NewGuid(), UserName = Guid.NewGuid().ToString() };
                var result = await _userManager.CreateAsync(user, model.Password);
                _context.SaveChanges();
                var profile = new Models.Profile { UserId = user.Id, FirstName = model.FirstName, LastName = model.LastName, Pobatkovi = model.Pobatkovi, Phone = model.Phone };
                _context.Profiles.Add(profile);
                _context.Users.Find(user.Id).Profile = profile;
                _context.SaveChanges();
                
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                var test = _context.Roles;
                var userRole = (model.IsTeacher) ? "Teacher" : "Student";

                await _userManager.AddToRoleAsync(user, userRole);
                return Created("", "Пользователь успешно создан.");
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("Students")]
        public async Task<IActionResult> GetStudents()
        {
            var users = await _userManager.GetUsersInRoleAsync("Student");
            var _users = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(_users);
        }

        [HttpGet("Teachers")]
        public async Task<IActionResult> GetTeachers()
        {
            var users = await _userManager.GetUsersInRoleAsync("Teacher");
            var _users = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(_users);
        }

        [HttpPost("Authorization")]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthorization model)
        {
            var user = await this._userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect!" });
            }

            var roleId = _context.UserRoles.First(x => x.UserId == user.Id).RoleId;
            var role = _context.Roles.First(x => x.Id == roleId).Name;

            var claims = new List<Claim>();
            claims.Add(new Claim("UserID", user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, role));


            if (await this._userManager.CheckPasswordAsync(user, model.Password))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySp$cialPassw0rd"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "https://localhost:5000",
                    audience: "https://localhost:5000",
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new
                {
                    Token = tokenString,
                    ExpiresIn = token.ValidTo,
                    Email = user.Email,
                    Id = user.Id
                });
            }

            return Unauthorized();
        }

        [HttpGet("Role/{email}")]
        public async Task<IActionResult> GetRoleByEmail(string email)
        {
            IList<string> roles = new List<string> { "Роль не определена" };
            var users = _context.Users.Where(x => x.Email == email);
            if (users.Count() != 0)
            {
                roles = await _userManager.GetRolesAsync(users.First());
            }
            else
            {
                return BadRequest(new { message = "No user with such email!" });
            }

            return Ok(roles);
        }
    }
}
