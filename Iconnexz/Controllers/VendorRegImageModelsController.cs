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
        public class VendorRegImageModelsController : ControllerBase
        {
            private readonly ApplicationDbContext _context;
            private readonly IWebHostEnvironment _webHostEnvironment;

            public VendorRegImageModelsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
            {
                _context = context;
                _webHostEnvironment = webHostEnvironment;
            }


            [HttpGet]
            public async Task<ActionResult<IEnumerable<VendorRegImageModel>>> GetVendorRegImage()
            {
                return await _context.VendorRegImage.ToListAsync();
            }


            [HttpGet("{id}")]
            public async Task<ActionResult<VendorRegImageModel>> GetVendorRegImageModel(int id)
            {
                var vendorRegImageModel = await _context.VendorRegImage.FindAsync(id);

                if (vendorRegImageModel == null)
                {
                    return NotFound();
                }

                return vendorRegImageModel;
            }


            [HttpPut("{id}")]
            public async Task<IActionResult> PutVendorRegImageModel(int id, VendorRegImageModel vendorRegImageModel)
            {
                if (id != vendorRegImageModel.VendorRegImageId)
                {
                    return BadRequest();
                }

                _context.Entry(vendorRegImageModel).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorRegImageModelExists(id))
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
            public async Task<ActionResult<VendorRegImageModel>> SaveImage(IFormFile fileObj, IFormFile fileObj2)
            {
                VendorRegImageModel VendorReg = new VendorRegImageModel();

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
                        VendorReg.VendorRegImage = memoryStream.ToArray();
                    }
                    using (var memoryStream = new MemoryStream())
                    {
                        await fileObj2.CopyToAsync(memoryStream);
                        VendorReg.ThumbnailImage = memoryStream.ToArray();
                    }


                    VendorReg.VendorRegImageFilePath = cloudDomain + "/UploadImages/" + fileObj.FileName;
                    VendorReg.ThumbnailImageFilePath = cloudDomain + "/UploadImages/" + fileObj2.FileName;

                    _context.VendorRegImage.Add(VendorReg);
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
            public async Task<ActionResult<VendorRegImageModel>> DeleteVendorRegImageModel(int id)
            {
                var vendorRegImageModel = await _context.VendorRegImage.FindAsync(id);
                if (vendorRegImageModel == null)
                {
                    return NotFound();
                }

                _context.VendorRegImage.Remove(vendorRegImageModel);
                await _context.SaveChangesAsync();

                return vendorRegImageModel;
            }

            private bool VendorRegImageModelExists(int id)
            {
                return _context.VendorRegImage.Any(e => e.VendorRegImageId == id);
            }
        }
    }

}
