using CometeAPI.Domain;
using CometeAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CometeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{
    private readonly OpenAiService _openAiService;

    public ReportController(OpenAiService openAiService)
    {
        _openAiService = openAiService;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> Generate([FromBody] ReportRequest request)
    {
        if (string.IsNullOrEmpty(request.Text))
        {
            return BadRequest("Pas de texte à résumer.");
        }

        var completion = await _openAiService.GetResumeAsync(request.Text);
        return Ok(completion);
    }
}