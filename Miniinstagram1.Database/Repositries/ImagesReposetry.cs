using Miniinstagram1.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Miniinstagram1.Database.Repositries
{
    public class ImagesReposetry : BaseReposetry<Image>, IImagesReposetry
    {
        public ImagesReposetry(DatabaseContext context):base(context)
        {

        }
    }
}
