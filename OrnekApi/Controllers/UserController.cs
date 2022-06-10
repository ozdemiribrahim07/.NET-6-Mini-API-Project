using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrnekApi.Models;

namespace OrnekApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }


        private static List<User> users = new List<User>
            {
                new User
                {
                    UserId = 1,
                    UserName = "ozdemiribrahim",
                    Email = "ozdemiribrahim07@gmail.com",
                    Password = "ornekapi"

                },

                new User
                {
                    UserId = 2,
                    UserName = "username1",
                    Email = "username@gmail.com",
                    Password = "username"

                }
            };

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return BadRequest("Kullanıcı Bulunamadı..");
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return Ok(await _context.Users.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult<List<User>>> Add(User user)
        {
           _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<User>>> Update(User update)
        {
            var user = await _context.Users.FindAsync(update.UserId);
            if (user == null)
            {
                return BadRequest("Kullanıcı Bulunamadı..");
            }

            user.UserName = update.UserName;
            user.Email = update.Email;
            user.Password = update.Password;

            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return BadRequest("Kullanıcı Bulunamadı..");
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }






    }
}
