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
        public class VendorAccountImageModelsController : ControllerBase
        {
            private readonly ApplicationDbContext _context;
            private readonly IWebHostEnvironment _webHostEnvironment;

            public VendorAccountImageModelsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
            {
                _context = context;
                _webHostEnvironment = webHostEnvironment;
            }


            [HttpGet]
            public async Task<ActionResult<IEnumerable<VendorAccountImageModel>>> GetVendorAccountImage()
            {
                return await _context.VendorAccountImage.ToListAsync();
            }


            [HttpGet("{id}")]
            public async Task<ActionResult<VendorAccountImageModel>> GetVendorAccountImageModel(int id)
            {
                var vendorAccountImageModel = await _context.VendorAccountImage.FindAsync(id);

                if (vendorAccountImageModel == null)
                {
                    return NotFound();
                }

                return vendorAccountImageModel;
            }


            [HttpPut("{id}")]
            public async Task<IActionResult> PutVendorAccountImageModel(int id, VendorAccountImageModel vendorAccountImageModel)
            {
                if (id != vendorAccountImageModel.VendorAccountImageId)
                {
                    return BadRequest();
                }

                _context.Entry(vendorAccountImageModel).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorAccountImageModelExists(id))
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
            public async Task<ActionResult<VendorAccountImageModel>> SaveImage(IFormFile fileObj, IFormFile fileObj2)
            {
                VendorAccountImageModel VendorAccount = new VendorAccountImageModel();

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
                        VendorAccount.VendorAccountImage = memoryStream.ToArray();
                    }
                    using (var memoryStream = new MemoryStream())
                    {
                        await fileObj2.CopyToAsync(memoryStream);
                        VendorAccount.ThumbnailImage = memoryStream.ToArray();
                    }


                    VendorAccount.VendorAccountImageFilePath = cloudDomain + "/UploadImages/" + fileObj.FileName;
                    VendorAccount.ThumbnailImageFilePath = cloudDomain + "/UploadImages/" + fileObj2.FileName;

                    _context.VendorAccountImage.Add(VendorAccount);
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
            public async Task<ActionResult<VendorAccountImageModel>> DeleteVendorAccountImageModel(int id)
            {
                var vendorAccountImageModel = await _context.VendorAccountImage.FindAsync(id);
                if (vendorAccountImageModel == null)
                {
                    return NotFound();
                }

                _context.VendorAccountImage.Remove(vendorAccountImageModel);
                await _context.SaveChangesAsync();

                return vendorAccountImageModel;
            }

            private bool VendorAccountImageModelExists(int id)
            {
                return _context.VendorAccountImage.Any(e => e.VendorAccountImageId == id);
            }
        }
    }

}
