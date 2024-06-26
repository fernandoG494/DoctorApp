using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly ApplicationDBContext _db;

        public UserController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _db.Users.ToListAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _db.Users.FindAsync(id);
            return Ok(usuario);
        }

        [HttpPost("registro")]
        public async Task<ActionResult<Usuario>> Register(RegisterDto registerDto)
        {
            if (await UserExist(registerDto.Username)) {
                return BadRequest("User already registered");
            }

            using var hmac = new HMACSHA512();
            var user = new Usuario
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return user;
        }

        private async Task<bool> UserExist(string username)
        {
            return await _db.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

    }
}
