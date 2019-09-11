using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.DWS.Controllers
{
    [Route("api/[controller]")]
    public class FileUploadController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateMediaItem([FromForm]IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }
            return Json(result.ToString());
        }
    }
}