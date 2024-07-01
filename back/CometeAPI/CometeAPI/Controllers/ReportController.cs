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

    [HttpPost]
    public async Task<ActionResult<ReportResponseDTO>> create([FromBody] ReportRequestDTO requestDTO)
    {
        try
        {
            Report response = await _reportService.save(_reportMapper.verifyRequest(requestDTO));
            return Created(nameof(ReportResponseDTO), _reportMapper.toDTO(response));
        }
        catch (Exception ex) { 
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReportResponseDTO>> getById(long id)
    {
        try
        {
            Report response = await _reportService.findById(id);
            return Ok(_reportMapper.toDTO(response));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("GenerateResume")]
    public async Task<ActionResult<string>> resumePrompt([FromBody] ReportResumePromptRequestDTO request)
    {
        try
        {
            string response = await _reportService.getResume(request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}