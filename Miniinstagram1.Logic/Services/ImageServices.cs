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
using Miniinstagram1.Database.Repositries;
using Miniinstagram1.Logic.Interfaces;
using Miniinstagram1.ViewModels;

namespace Miniinstagram1.Logic
{
    public class ImageServices: IImageServices
    {
        public ImageServices(ImagesReposetry reposetry)
        {
            _reposetry = reposetry;
        }
        ImagesReposetry _reposetry;
        public async Task<bool> Add(
            ImageViewModel vm,
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
                _reposetry.Create(image);
                return true;
            }
            else
                return false;
        }

        public Image Get(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Image> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Image item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Image item)
        {
            throw new NotImplementedException();
        }
    }
}
