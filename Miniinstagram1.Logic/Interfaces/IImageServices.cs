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
        ICollection<Image> GetAll();
    }
}
