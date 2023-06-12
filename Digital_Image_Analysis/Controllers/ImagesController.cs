
using Digital_Image_Analysis.Data;
using Digital_Image_Analysis.Helpers;
using Digital_Image_Analysis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Digital_Image_Analysis.Controllers
{
    public class ImagesController : Controller
    {
        private readonly AppDbContext _context;

        public ImagesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var images = await _context.Images.ToListAsync();
            return View(images);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var image = new Image
                {
                    FileName = file.FileName,
                    UploadDate = DateTime.Now,
                    Size = (int)file.Length
                };

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    image.ImageData = memoryStream.ToArray();
                }

                _context.Images.Add(image);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }



        public IActionResult ViewImage(Guid id)
        {
            var image = _context.Images.FirstOrDefault(img => img.Id == id);
            if (image == null)
            {
                return NotFound();
            }
            var key = new byte[] { 0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF, 0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10 };
            var iv = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10 };

            var encryptedImageData = EncryptionHelper.EncryptImageData(image.ImageData, key, iv);
            ViewBag.id=image.Id;
            ViewBag.Image = encryptedImageData;
            return View();
        }
        



    }
}
