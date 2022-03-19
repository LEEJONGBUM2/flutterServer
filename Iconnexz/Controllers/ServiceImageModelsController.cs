using Iconnexz.Authentication;
using Iconnexz.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Iconnexz.Controllers
{
    namespace Iconnexz.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ServiceImageModelsController : ControllerBase
        {
            private readonly ApplicationDbContext _context;
            private readonly IWebHostEnvironment _webHostEnvironment;

            public ServiceImageModelsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
            {
                _context = context;
                _webHostEnvironment = webHostEnvironment;
            }


            [HttpGet]
            public async Task<ActionResult<IEnumerable<ServiceImageModel>>> GetServiceImage()
            {
                return await _context.ServiceImage.ToListAsync();
            }


            [HttpGet("{id}")]
            public async Task<ActionResult<ServiceImageModel>> GetServiceImageModel(int id)
            {
                var serviceImageModel = await _context.ServiceImage.FindAsync(id);

                if (serviceImageModel == null)
                {
                    return NotFound();
                }

                return serviceImageModel;
            }


            [HttpPut("{id}")]
            public async Task<IActionResult> PutServiceImageModel(int id, ServiceImageModel serviceImageModel)
            {
                if (id != serviceImageModel.ServiceImageId)
                {
                    return BadRequest();
                }

                _context.Entry(serviceImageModel).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceImageModelExists(id))
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

            [HttpPost]
            public async Task<ActionResult<ServiceImageModel>> SaveImage(IFormFile fileObj, IFormFile fileObj2)
            {
                ServiceImageModel Service = new ServiceImageModel();

                if (fileObj.Length > 0)
                {
                    string cloudDomain = "https://172.30.1.10:45455";
                    string uploadPath = _webHostEnvironment.WebRootPath + "\\UploadImages\\";
                    Console.WriteLine(uploadPath);

                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    string filePath = uploadPath + fileObj.FileName;
                    string filePath2 = uploadPath + fileObj2.FileName;

                    Console.WriteLine(filePath, filePath2);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await fileObj.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                    }

                    using (var fileStream = new FileStream(filePath2, FileMode.Create))
                    {
                        await fileObj2.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                    }

                    using (var memoryStream = new MemoryStream())
                    {
                        await fileObj.CopyToAsync(memoryStream);
                        Service.ServiceImage = memoryStream.ToArray();
                    }
                    using (var memoryStream = new MemoryStream())
                    {
                        await fileObj2.CopyToAsync(memoryStream);
                        Service.ThumbnailImage = memoryStream.ToArray();
                    }


                    Service.ServiceImageFilePath = cloudDomain + "/UploadImages/" + fileObj.FileName;
                    Service.ThumbnailImageFilePath = cloudDomain + "/UploadImages/" + fileObj2.FileName;

                    _context.ServiceImage.Add(Service);
                    await _context.SaveChangesAsync();

                    return Ok("Image Saved");
                }
                return BadRequest("Add Image Failed");

            }

            /*[HttpPost]
            public async Task<ActionResult<UserIndividualModel>> PostUserIndividualModel(UserIndividualModel userIndividualModel)
            {
                _context.UserIndividual.Add(userIndividualModel);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUserIndividualModel", new { id = userIndividualModel.UserId }, userIndividualModel);
            }*/


            [HttpDelete("{id}")]
            public async Task<ActionResult<ServiceImageModel>> DeleteServiceImageModel(int id)
            {
                var serviceImageModel = await _context.ServiceImage.FindAsync(id);
                if (serviceImageModel == null)
                {
                    return NotFound();
                }

                _context.ServiceImage.Remove(serviceImageModel);
                await _context.SaveChangesAsync();

                return serviceImageModel;
            }

            private bool ServiceImageModelExists(int id)
            {
                return _context.ServiceImage.Any(e => e.ServiceImageId == id);
            }
        }
    }

}
