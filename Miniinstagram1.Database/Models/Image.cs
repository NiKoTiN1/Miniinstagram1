using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniinstagram1.Database
{
    public class Image
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Path { get; set; }
        public virtual ApplicationUser User { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public DateTime UploadDate { get; set; }
        [Required]
        public Category category { get; set; } = Category.Other;
    }
}
