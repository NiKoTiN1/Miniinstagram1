using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Miniinstagram1.Database
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Image> Images { get; set; }
    }
}