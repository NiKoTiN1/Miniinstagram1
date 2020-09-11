using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Miniinstagram1.Database;

namespace Miniinstagram1.ViewModels
{
    public class ImageViewModel
    {
        [Required]
        public IFormFile File { get; set; }
        [Required]
        public Category Category { get; set; }
    }
}
