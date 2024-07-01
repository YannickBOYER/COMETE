using CometeAPI.Application.DTO.@in;
using CometeAPI.Application.Service;
using CometeAPI.Domain.models;
using CometeAPI.Domain.repositories;
using System.Runtime.InteropServices;

namespace CometeAPI.Application;

public class ReportService
{
    private readonly OpenAiService _openAiService;
    private readonly IReportRepository _reportReporitory;

    public ReportService(OpenAiService openAiService, IReportRepository reportReporitory)
    {
        _openAiService = openAiService;
        _reportReporitory = reportReporitory;
    }

    public async Task<Report> save(ReportRequestDTO requestDTO)
    {
        Report newReport = await _reportReporitory.save(requestDTO);
        return newReport;
    }

    public async Task<string> getResume(ReportResumePromptRequestDTO requestDTO)
    {
        return await _openAiService.GetResumeAsync(requestDTO.Prompt, requestDTO.Instructions);
    }

    public async Task<Report> findById(long id)
    {
        return await _reportReporitory.findById(id);
    }
}