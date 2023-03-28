using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        public async Task<ActionResult<Picture>> GetPicture(string size, int id)
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

            Match m = Regex.Match(size, "lg|md|sm");
            if (!m.Success)
            {
                return BadRequest();
            }

            byte[] bytes = System.IO.File.ReadAllBytes("C:\\Users\\David\\Desktop\\Git school\\prog api\\C03\\WebApiCours2Demo\\S15_Images_AngularForms\\SuperChats\\SuperChatsWebAPI\\wwwRoot\\Images\\" + size + "\\" + picture.FileName);
            //byte[] bytes = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/" + size + "/" + picture.FileName);

            return File(bytes, picture.MimeType);
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

        //// POST: api/Pictures
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Picture>> PostPicture(Picture picture)
        //{
        //    if (_context.Picture == null)
        //    {
        //        return Problem("Entity set 'SuperChatsContext.Picture'  is null.");
        //    }
        //    _context.Picture.Add(picture);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetPicture", new { id = picture.Id }, picture);
        //}

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

            System.IO.File.Delete("C:\\Users\\David\\Desktop\\Git school\\prog api\\C03\\WebApiCours2Demo\\S15_Images_AngularForms\\SuperChats\\SuperChatsWebAPI\\wwwRoot\\Images\\lg\\" + picture.FileName);
            System.IO.File.Delete("C:\\Users\\David\\Desktop\\Git school\\prog api\\C03\\WebApiCours2Demo\\S15_Images_AngularForms\\SuperChats\\SuperChatsWebAPI\\wwwRoot\\Images\\md\\" + picture.FileName);
            System.IO.File.Delete("C:\\Users\\David\\Desktop\\Git school\\prog api\\C03\\WebApiCours2Demo\\S15_Images_AngularForms\\SuperChats\\SuperChatsWebAPI\\wwwRoot\\Images\\sm\\" + picture.FileName);

            _context.Picture.Remove(picture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PictureExists(int id)
        {
            return (_context.Picture?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<ActionResult<Picture>> PostPictureAngular()
        {
            try
            {
                IFormCollection formCollection = await Request.ReadFormAsync();
                IFormFile file = formCollection.Files.GetFile("image");
                Image image = Image.Load(file.OpenReadStream());

                Picture picture = new Picture();
                picture.FileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                picture.MimeType = file.ContentType;

                image.Save("C:\\Users\\David\\Desktop\\Git school\\prog api\\C03\\WebApiCours2Demo\\S15_Images_AngularForms\\SuperChats\\SuperChatsWebAPI\\wwwRoot\\Images\\lg\\" + picture.FileName);

                //image.Save(Directory.GetCurrentDirectory() + "/images/originale/" + picture.FileName);


                image.Mutate(i =>
                    i.Resize(new ResizeOptions()
                    {
                        Mode = ResizeMode.Min,
                        Size = new Size() { Height = 720 }
                    })
                    );
                image.Save("C:\\Users\\David\\Desktop\\Git school\\prog api\\C03\\WebApiCours2Demo\\S15_Images_AngularForms\\SuperChats\\SuperChatsWebAPI\\wwwRoot\\Images\\md\\" + picture.FileName);
                image.Mutate(i =>
                    i.Resize(new ResizeOptions()
                    {
                        Mode = ResizeMode.Min,
                        Size = new Size() { Height = 320 }
                    })
                    );
                image.Save("C:\\Users\\David\\Desktop\\Git school\\prog api\\C03\\WebApiCours2Demo\\S15_Images_AngularForms\\SuperChats\\SuperChatsWebAPI\\wwwRoot\\Images\\sm\\" + picture.FileName);


                _context.Picture.Add(picture);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { }
            return Ok();
        }
    }
}
