using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperChatsWebAPI.Data;
using SuperChatsWebAPI.Models;

namespace SuperChatsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly SuperChatsContext _context;

        public PicturesController(SuperChatsContext context)
        {
            _context = context;
        }

        // GET: api/Pictures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Picture>>> GetPicture()
        {
          if (_context.Picture == null)
          {
              return NotFound();
          }
            return await _context.Picture.ToListAsync();
        }

        // GET: api/Pictures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Picture>> GetPicture(int id)
        {
          if (_context.Picture == null)
          {
              return NotFound();
          }
            var picture = await _context.Picture.FindAsync(id);

            if (picture == null)
            {
                return NotFound();
            }

            return picture;
        }

        // PUT: api/Pictures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPicture(int id, Picture picture)
        {
            if (id != picture.Id)
            {
                return BadRequest();
            }

            _context.Entry(picture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PictureExists(id))
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

        // POST: api/Pictures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Picture>> PostPicture(/*Picture picture*/)
        {
          //if (_context.Picture == null)
          //{
          //    return Problem("Entity set 'SuperChatsContext.Picture'  is null.");
          //}
          //  _context.Picture.Add(picture);
          //  await _context.SaveChangesAsync();

          //  return CreatedAtAction("GetPicture", new { id = picture.Id }, picture);
          try
            {
                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile file = formCollection.Files.GetFile("image");
                Image image = Image.Load(file.OpenReadStream());

                Picture picture =new Picture();
                picture.FileName=Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
                picture.MimeType = file.ContentType;

                image.Save(Directory.GetCurrentDirectory()+"/wwwroot/" + picture.FileName);

                _context.Picture.Add(picture);
                await _context.SaveChangesAsync();
            }
            catch (Exception e) { }
            return Ok();
        }

        // DELETE: api/Pictures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePicture(int id)
        {
            if (_context.Picture == null)
            {
                return NotFound();
            }
            var picture = await _context.Picture.FindAsync(id);
            if (picture == null)
            {
                return NotFound();
            }

            _context.Picture.Remove(picture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PictureExists(int id)
        {
            return (_context.Picture?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
