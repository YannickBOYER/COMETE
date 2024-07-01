using CometeAPI.Application.DTO.@in;
using CometeAPI.Application.DTO.@out;
using CometeAPI.Domain.models;
using CometeAPI.Domain.repositories;

namespace CometeAPI.Application;

public class FolderService
{
    private readonly IFolderRepository _folderRepository;
    private readonly IReportRepository _reportReporitory;
    public FolderService(IFolderRepository folderRepository, IReportRepository reportReporitory)
    {
        _folderRepository = folderRepository;
        _reportReporitory = reportReporitory;
    }

    public async Task<List<Folder>> findAllByUtilisateur(long idUtilisateur)
    {
        return await _folderRepository.findAllByIdUtilisateur(idUtilisateur);
    }

    public async Task<List<ReportResponseDTO>> getReports(long id)
    {
        List<Report> reports = await _reportReporitory.findAllByFolder(id);
        return reports.Select(report => new ReportResponseDTO
        {
            Id = report.Id,
            Name = report.Name,
            Content = report.Content
        }).ToList(); ;
    }

    public async Task<Folder> save(FolderCreateRequestDTO requestDTO) {
        return await _folderRepository.create(requestDTO);
    }
}