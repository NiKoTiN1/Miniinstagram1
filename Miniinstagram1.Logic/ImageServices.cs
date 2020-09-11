using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Miniinstagram1.Database;
using Miniinstagram1.ViewModels;

namespace Miniinstagram1.Logic
{
    public static class ImageServices
    {
        public static async Task<IActionResult> Add(
            ImageViewModel vm,
            DatabaseContext context,
            IHostingEnvironment appEnvironment,
            Guid userId)
        {
            if (vm.File != null)
            {
                string path = "/Images/" + vm.File.FileName + '_' + vm.Category + '_' + userId;

                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create, FileAccess.Write))
                {
                    await vm.File.CopyToAsync(fileStream);
                }
                Image image = new Image()
                {
                    Id = Guid.NewGuid(),
                    Path = path,
                    category = vm.Category,
                    UploadDate = DateTime.Now,
                    UserId = userId.ToString(),
                };
                context.Images.Add(image);
                context.SaveChanges();
                return new OkResult();
            }
            else
                return new BadRequestResult();
        }
    }
}
