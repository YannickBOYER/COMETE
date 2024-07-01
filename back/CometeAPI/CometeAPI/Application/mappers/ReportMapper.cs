using CometeAPI.Application.DTO.@in;
using CometeAPI.Application.DTO.@out;
using CometeAPI.Domain.exception;
using CometeAPI.Domain.models;

namespace CometeAPI.Application.mappers;

public class ReportMapper
{
    public ReportResponseDTO toDTO(Report report)
    {
        ReportResponseDTO dto = new ReportResponseDTO();
        dto.Id = report.Id;
        dto.Name = report.Name;
        dto.Content = report.Content;
        return dto;
    }

    public ReportRequestDTO verifyRequest(ReportRequestDTO reportRequestDTO)
    {
        reportRequestDTO.FileName = verifyFileName(reportRequestDTO.FileName);
        reportRequestDTO.Text = verifyContent(reportRequestDTO.Text);
        return reportRequestDTO;
    }

    private string verifyContent(string? content)
    {
        if (string.IsNullOrEmpty(content))
        {
            throw new Exception("Pas de texte à résumer.");
        }
        if (content.Length > 1200)
        {
            throw new PromptTooLongException();
        }
        return content;
    }

    private string verifyFileName(string? fileName)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            return "Nouveau compte rendu";
        }
        return fileName;
    }
}