using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using UploadFileWithCloudinaryASPNetCore.Models;

namespace UploadFileWithCloudinaryASPNetCore.Controllers
{
    [Route("api/")]
    public class UploadController : Controller
    {
        private Cloudinary cloudinary;

        public UploadController()
        {
            Account account = new Account(
            "dinhnt",
            "398171900000388",
            "D7jrhAOU62b-rbFqHtmldwIPVzUz6U");
            cloudinary = new Cloudinary(account);
            cloudinary.Api.Secure = true;
        }

        // POST: api/upload-file
        [HttpPost]
        [Route("upload-file")]
        public IActionResult UploadFileWithCloudinary(List<IFormFile> files)
        {
            var link = "";
            try
            {
                int i = 1;
               // var photo = HttpContext.Request.Form.Files;
                foreach (var item in files)
                {
                    var image = item.OpenReadStream();
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(String.Format("{0}_{1}", "dinhnt", i), image),
                        UseFilename = true,
                    };
                    var uploadResult = cloudinary.Upload(uploadParams);

                    link += uploadResult.SecureUrl.ToString() + " - ";

                    if (link == "")
                    {
                        return Ok(new Message(0, "Thêm ảnh thất bại", uploadResult.Error.ToString()));
                    }
                    i++;
                }
            }
            catch
            {
                return Ok(new Message(0, "Thêm ảnh thất bại", null));
            }
            return Ok(new Message(1, "Thêm ảnh thành công", link));
        }
    }
}

