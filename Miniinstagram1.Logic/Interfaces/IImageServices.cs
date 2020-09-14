using Miniinstagram1.Database;
using Miniinstagram1.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Miniinstagram1.Logic.Interfaces
{
    public interface IImageServices
    {
        Task<bool> Add(ImageViewModel vm, string rootPath, Guid userId);
        Image Get(string id);

        ICollection<Image> GetAll();

        Task<bool> Delete(Image item);

        Task<bool> Update(Image item);
    }
}
