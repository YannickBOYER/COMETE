using CometeAPI.Application;
using CometeAPI.Application.DTO.@out;
using CometeAPI.Application.mappers;
using CometeAPI.Domain.models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CometeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FolderController : ControllerBase
{
    private readonly FolderService _folderService;
    public FolderController(FolderService folderService)
    {
        _folderService = folderService;
    }
    
    [HttpGet("")]
    public async Task<ActionResult<Folder>> index([FromQuery] long idUtilisateur)
    {
        try
        {
            List<Folder> folders = await _folderService.findAllByUtilisateur(idUtilisateur);
            return Ok(folders);
        }
        catch (Exception ex) { 
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}/reports")]
    public async Task<ActionResult<List<ReportResponseDTO>>> getReports(long id) { 
        try
        {
            List<ReportResponseDTO> reports = await _folderService.getReports(id);
            return Ok(reports);
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}