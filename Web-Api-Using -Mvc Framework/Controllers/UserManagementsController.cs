using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_Using__Mvc_Framework;
using Web_Api_Using__Mvc_Framework.Data;

namespace Web_Api_Using__Mvc_Framework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementsController : ControllerBase
    {
        private readonly WebApiDbContext _context;

        public UserManagementsController(WebApiDbContext context)
        {
            _context = context;
        }

        // GET: api/UserManagements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserManagement>>> GetUserManagement()
        {
            return await _context.UserManagements.ToListAsync();
        }

        // GET: api/UserManagements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserManagement>> GetUserManagement(int id)
        {
            var userManagement = await _context.UserManagements.FindAsync(id);

            if (userManagement == null)
            {
                return NotFound();
            }

            return userManagement;
        }

        // PUT: api/UserManagements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserManagement(int id, UserManagement userManagement)
        {
            if (id != userManagement.Id)
            {
                return BadRequest();
            }

            _context.Entry(userManagement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserManagementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserManagements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserManagement>> PostUserManagement(UserManagement userManagement)
        {
            _context.UserManagements.Add(userManagement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserManagement", new { id = userManagement.Id }, userManagement);
        }

        // DELETE: api/UserManagements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserManagement(int id)
        {
            var userManagement = await _context.UserManagements.FindAsync(id);
            if (userManagement == null)
            {
                return NotFound();
            }

            _context.UserManagements.Remove(userManagement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserManagementExists(int id)
        {
            return _context.UserManagements.Any(e => e.Id == id);
        }
    }
}
