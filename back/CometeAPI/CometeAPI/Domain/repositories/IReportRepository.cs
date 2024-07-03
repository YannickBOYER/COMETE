using CometeAPI.Application.DTO.@in.Report;
using CometeAPI.Domain.models;

namespace CometeAPI.Domain.repositories;

public interface IReportRepository
{
    public Task<Report> save(ReportRequestDTO requestDTO);

    public Task<List<Report>> findAllByFolder(long idFolder);

    public Task<Report> findById(long id);

    public Task delete(long id);

    public Task<bool> exists(long id);

    public Task<Report> update(ReportUpdateRequestDTO requestDTO);
}