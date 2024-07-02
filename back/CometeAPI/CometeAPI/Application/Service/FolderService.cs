using CometeAPI.Application.DTO.@in;
using CometeAPI.Application.DTO.@out;
using CometeAPI.Domain.exception;
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

    public async Task delete(long id)
    {
        List<Report> reports = await _reportReporitory.findAllByFolder(id);
        if (reports.Count > 0) {
            throw new FolderNotEmptyException();
        }
        await _folderRepository.delete(id);
    }

    public async Task<bool> exists(long id) {
        return await _folderRepository.exists(id);
    }

    public async Task<Folder> update(FolderUpdateRequestDTO requestDTO)
    {
        if (await _folderRepository.exists(requestDTO.Id))
        {
            return await _folderRepository.update(requestDTO);
        }
        else
        {
            throw new FolderNotFoundException();
        }
    }
}