using Eisenhower_Web_API.Context;
using Eisenhower_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Eisenhower_Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserDbContext _context;
        public UserController(UserDbContext context) => _context = context;

        // Create

        [HttpPost]

        public async Task<IActionResult> CreateUserAsync(UserModel user)
        {
            await _context.Users.InsertOneAsync(user);
            return CreatedAtAction(nameof(CreateUserAsync), new { id = user.Id }, user);
        }

        // Read all users

        [HttpGet]

        public async Task<ActionResult<List<UserModel>>> GetUsersAsync() => Ok(await _context.Users.Find(_ => true).ToListAsync());

        // Read one user

        [HttpGet("{id}")] 

        public async Task<ActionResult<UserModel>> GetOneUserAsync(int id)
        {
            var user = await _context.Users.Find(u => u.Id == id).FirstOrDefaultAsync();

            if(user == null) return NotFound();

            return Ok(user);
        }

        // Update

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUserAsync(int id, UserModel updatedUser)
        {
            var result = await _context.Users.ReplaceOneAsync(u => u.Id == id, updatedUser);

            if(result.ModifiedCount == 0) return NotFound();

            return NoContent();
        }

        // Delete

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var result = await _context.Users.DeleteOneAsync(u => u.Id == id);

            if (result.DeletedCount == 0) return NotFound();    

            return NoContent();
        }

    }
}
