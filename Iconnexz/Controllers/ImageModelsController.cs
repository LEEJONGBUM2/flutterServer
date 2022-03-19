using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Iconnexz.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Iconnexz.Authentication;

namespace Iconnexz.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ImageModelsController : ControllerBase
   {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageModelsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageModel>>> GetAllImage()
        {
            return (await _context.Image.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ImageModel>> GetImage(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var ImageModel = await _context.Image
                .FirstOrDefaultAsync(m => m.ImageId == id);
            if(ImageModel == null)
            {
                return NotFound();
            }
            return (ImageModel);
        }

        [HttpPost]
        public async Task<ActionResult<ImageModel>> SaveImage(IFormFile fileObj, string title)
        {
            ImageModel Image = new ImageModel();

            if(fileObj.Length > 0)
            {
                string cloudDomain = "https://172.30.1.10:45455";
                string uploadPath = _webHostEnvironment.WebRootPath + "\\UploadImages\\";
                Console.WriteLine(uploadPath);

                if(!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string filePath = uploadPath + fileObj.FileName;

                Console.WriteLine(filePath);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await fileObj.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                }

                using (var memoryStream = new MemoryStream())
                {
                    await fileObj.CopyToAsync(memoryStream);
                    Image.Image = memoryStream.ToArray();
                }

                Image.Title = title;
                Image.ImageFilePath = cloudDomain + "/UploadImages/" + fileObj.FileName;
                _context.Image.Add(Image);
                await _context.SaveChangesAsync();

                return Ok("Image Saved");
            }
            return BadRequest("Add Image Failed");
        }
   }
}
