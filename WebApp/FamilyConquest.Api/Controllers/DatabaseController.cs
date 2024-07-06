using Microsoft.AspNetCore.Mvc;

namespace FamilyConquest.Controllers
{
    [ApiController]
    [Route("api/db")]
    public class DatabaseController(IConfiguration config) : ControllerBase
    {
        private readonly IConfiguration _config = config;

        [HttpGet]
        public FileResult DownloadDb()
        {
            var dbPath = _config["DatabasePath"];
            if (string.IsNullOrWhiteSpace(dbPath))
            {
                return EmptyFile();
            }

            var fileBytes = System.IO.File.ReadAllBytes(dbPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "FamilyConquest.db");
        }

        private FileContentResult EmptyFile()
        {
            return File([], System.Net.Mime.MediaTypeNames.Application.Octet, "FamilyConquest.db");
        }
    }
}
