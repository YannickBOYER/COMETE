using CometeAPI.Application;
using CometeAPI.Application.DTO.@in;
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
    private readonly FolderMapper _folderMapper;
    public FolderController(FolderService folderService, FolderMapper folderMapper)
    {
        _folderService = folderService;
        _folderMapper = folderMapper;
    }
    
    [HttpGet("")]
    public async Task<ActionResult<List<FolderResponseDTO>>> index([FromQuery] long idUtilisateur)
    {
        try
        {
            List<Folder> folders = await _folderService.findAllByUtilisateur(idUtilisateur);
            List<FolderResponseDTO> foldersDTO = folders.Select(folder => _folderMapper.toDTO(folder)).ToList();
            return Ok(foldersDTO);
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

    [HttpPost]
    public async Task<ActionResult<FolderResponseDTO>> save([FromBody] FolderCreateRequestDTO requestDTO)
    {
        try
        {
            Folder folder = await _folderService.save(requestDTO);
            return Ok(_folderMapper.toDTO(folder));
        }
        catch (Exception ex) { 
            return BadRequest(ex.Message);
        }
    }
}