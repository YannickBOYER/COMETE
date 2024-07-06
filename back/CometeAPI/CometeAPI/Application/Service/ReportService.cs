using CometeAPI.Application.DTO.@in.Report;
using CometeAPI.Application.Service;
using CometeAPI.Domain.exception;
using CometeAPI.Domain.models;
using CometeAPI.Domain.repositories;

namespace CometeAPI.Application;

public class ReportService
{
    private readonly OpenAiService _openAiService;
    private readonly IReportRepository _reportReporitory;
    private readonly FolderService _folderService;

    public ReportService(OpenAiService openAiService, IReportRepository reportReporitory, FolderService folderService)
    {
        _openAiService = openAiService;
        _reportReporitory = reportReporitory;
        _folderService = folderService;
    }

    public async Task<Report> save(Report report)
    {
        if (await _folderService.exists(report.FolderId))
        {
            Report newReport = await _reportReporitory.save(report);
            return newReport;
        }
        else
        {
            throw new FolderNotFoundException();
        } 
    }

    public async Task<string> getResume(ReportResumePromptRequestDTO requestDTO)
    {
        return await _openAiService.GetResumeAsync(requestDTO.Prompt, requestDTO.Instructions);
    }

    public async Task<Report> findById(long id)
    {
        return await _reportReporitory.findById(id);
    }

    public async Task delete(long id)
    {
        await _reportReporitory.delete(id);
    }

    private async Task<bool> exists(long id)
    {
        return await _reportReporitory.exists(id);
    }

    public async Task<Report> update(Report report)
    {
        if (await exists(report.Id))
        {
            return await _reportReporitory.update(report);
        }
        else
        {
            throw new ReportNotFoundException();
        }
    }
}