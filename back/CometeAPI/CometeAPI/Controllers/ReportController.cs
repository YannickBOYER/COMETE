using CometeAPI.Application;
using CometeAPI.Application.DTO.@in;
using CometeAPI.Application.DTO.@out;
using CometeAPI.Application.mappers;
using CometeAPI.Domain.models;
using Microsoft.AspNetCore.Mvc;

namespace CometeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase
{
    private readonly ReportService _reportService;
    private readonly ReportMapper _reportMapper;

    public ReportController(ReportService reportService, ReportMapper reportMapper)
    {
        _reportService = reportService;
        _reportMapper = reportMapper;
    }

    [HttpPost("generate")]
    public async Task<ActionResult<ReportResponseDTO>> Generate([FromBody] ReportRequestDTO request)
    {
        try
        {
            Report response = await _reportService.generate(_reportMapper.verifyRequest(request));
            return Created(nameof(ReportResponseDTO), _reportMapper.toDTO(response));
        }
        catch (Exception ex) { 
            return BadRequest(ex.Message);
        }
    }
}