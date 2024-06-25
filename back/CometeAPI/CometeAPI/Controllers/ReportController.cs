using CometeAPI.Application;
using CometeAPI.Application.DTO.@in;
using CometeAPI.Domain.models;
using Microsoft.AspNetCore.Mvc;

namespace CometeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{
    private readonly ReportService _reportService;

    public ReportController(ReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> Generate([FromBody] ReportRequestDTO request)
    {
        try
        {
            Report response = await _reportService.generate(request);
            return Ok(response);
        }
        catch (Exception ex) { 
            return BadRequest(ex.Message);
        }
    }
}