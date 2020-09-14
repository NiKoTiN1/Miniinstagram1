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
        IHostingEnvironment _appEnvironment;
        ImageServices _imageService;

        public UploadFileController(IHostingEnvironment appEnvironment, ImageServices imageService)
        {
            _appEnvironment = appEnvironment;
            _imageService = imageService;
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
            var imageAddingResult = await _imageService.Add(vm, _appEnvironment.WebRootPath, new Guid(userIdClaim.Value));
            return imageAddingResult ? (IActionResult)Ok() : BadRequest();
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var Images = _imageService.GetAll();
            return Images.Count != 0 ? (IActionResult)Ok(Images) : BadRequest();
        }
    }
}
