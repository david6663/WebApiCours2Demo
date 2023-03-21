using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperChatsWebAPI.Data;
using SuperChatsWebAPI.Models;

namespace SuperChatsWebAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class VillagersController : ControllerBase
    {
        UserManager<User> UserManager;
        private readonly SuperChatsContext _context;

        public VillagersController(UserManager<User> userManager, SuperChatsContext context)
        {
            this.UserManager = userManager;
            _context = context;
        }

        // GET: api/Villagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Villager>>> GetVillager()
        {
            return await _context.Villager.ToListAsync();
        }

        // GET: api/Villagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Villager>> GetVillager(int id)
        {
            var villager = await _context.Villager.FindAsync(id);

            if (villager == null)
            {
                return NotFound();
            }

            return villager;
        }

        // PUT: api/Villagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVillager(int id, Villager villager)
        {
            if (id != villager.Id)
            {
                return BadRequest();
            }

            _context.Entry(villager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VillagerExists(id))
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

        // POST: api/Villagers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Villager>> PostVillager(Villager villager)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = await UserManager.FindByIdAsync(userId);
            villager.UserFriends = new List<User>();
            if(user!=null)villager.UserFriends.Add(user);
            //villager.SesChats = new List<Cat>();

            _context.Villager.Add(villager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVillager", new { id = villager.Id }, villager);
        }

        // DELETE: api/Villagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVillager(int id)
        {
            var villager = await _context.Villager.FindAsync(id);
            if (villager == null)
            {
                return NotFound();
            }

            _context.Villager.Remove(villager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VillagerExists(int id)
        {
            return _context.Villager.Any(e => e.Id == id);
        }
    }
}
