using CometeAPI.Application.DTO.@in;
using CometeAPI.Domain.models;

namespace CometeAPI.Domain.repositories;

public interface IReportRepository
{
    public Task<Report> save(ReportRequestDTO requestDTO);

    public Task<List<Report>> findAllByFolder(long idFolder);

    public Task<Report> findById(long id);
}