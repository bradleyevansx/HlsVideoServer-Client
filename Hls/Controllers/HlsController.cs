using Microsoft.AspNetCore.Mvc;
using System.IO;

[Route("api/[controller]")]
[ApiController]
public class HLSController : ControllerBase
{
    private readonly string _videoPath = "Videos";

    [HttpGet("{videoName}/{fileName}")]
    public IActionResult Get(string videoName, string fileName)
    {
        var videoFolderPath = Path.Combine(_videoPath, videoName);

        if (!Directory.Exists(videoFolderPath))
        {
            return NotFound();
        }

        var manifestPath = Path.Combine(videoFolderPath, $"{fileName}");

        if (!System.IO.File.Exists(manifestPath))
        {
            return NotFound();
        }

        var fileStream = new FileStream(manifestPath, FileMode.Open, FileAccess.Read);
        return File(fileStream, "application/vnd.apple.mpegurl");
    }

    [HttpGet("{videoName}/{segment}.ts")]
    public IActionResult GetSegment(string videoName, string segment)
    {
        var videoFolderPath = Path.Combine(_videoPath, videoName);

        if (!Directory.Exists(videoFolderPath))
        {
            return NotFound();
        }

        var segmentPath = Path.Combine(videoFolderPath, $"{segment}.ts");

        if (!System.IO.File.Exists(segmentPath))
        {
            return NotFound();
        }

        var fileStream = new FileStream(segmentPath, FileMode.Open, FileAccess.Read);
        return File(fileStream, "video/MP2T");
    }
    
    
}
