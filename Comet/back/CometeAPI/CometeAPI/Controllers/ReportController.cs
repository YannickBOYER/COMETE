using Microsoft.AspNetCore.Mvc;

namespace CometeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{
    [HttpGet("generate")]
    public async Task<IActionResult> Generate()
    {
        /*if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        var text = await _fileService.ExtractTextAsync(file);
        var response = await _fileService.ProcessTextWithOpenAIAsync(text);*/
        return Ok();
    }
}