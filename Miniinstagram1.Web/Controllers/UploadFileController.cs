using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Miniinstagram1.Database;
using System;
using Miniinstagram1.Logic;
using Miniinstagram1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;

namespace Miniinstagram1.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UploadFileController : Controller
    {
        DatabaseContext _context;
        IHostingEnvironment _appEnvironment;

        public UploadFileController(DatabaseContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            return Ok(_context.Images.ToList());
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddFile([FromForm] ImageViewModel vm)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault(a => a.Type == "UserId");
            if(userIdClaim == null)
            {
                return Unauthorized();
            }
            return await ImageServices.Add(vm, _context, _appEnvironment, new Guid(userIdClaim.Value));
        }
    }
}
