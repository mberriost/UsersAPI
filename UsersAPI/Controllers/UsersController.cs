using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;

namespace UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersApiContext _context;

        public UsersController(UsersApiContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<User>>> UsersList()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPost("create")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            user.CreatedDate = DateTime.Now; //get created date
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, user);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateUser(int id, User user)
        {
            var findUser = await _context.Users.FindAsync(id); //verify the user exists

            if (findUser != null)
            {
                //update the new values
                findUser.FirstName = user.FirstName;
                findUser.LastName = user.LastName;
                findUser.Email = user.Email;
                findUser.Username = user.Username;

                await _context.SaveChangesAsync();
                return Ok(findUser);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id); //verify the user exists

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
