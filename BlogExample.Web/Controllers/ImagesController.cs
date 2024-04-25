using BlogExample.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net;

namespace BlogExample.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile formFile)
        {
            // Call repository 
            var imageUrl = await imageRepository.UploadAsync(formFile);

            if (imageUrl == null) 
            {
                return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
            }

            return new JsonResult(new { link = imageUrl });
        }
    }
}
