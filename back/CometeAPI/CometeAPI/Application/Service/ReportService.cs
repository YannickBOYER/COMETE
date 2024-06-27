using CometeAPI.Application.DTO.@in;
using CometeAPI.Application.Service;
using CometeAPI.Domain.models;
using CometeAPI.Domain.repositories;

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

    public async Task<Report> generate(ReportRequestDTO request)
    {
        string content = await _openAiService.GetResumeAsync(request.Text, request.InstructionSupplementaire);
        Report newReport = _reportReporitory.save(request.FileName, content);
        return newReport;
    }
}