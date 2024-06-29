using CometeAPI.Domain.models;

namespace CometeAPI.Domain.repositories;

public interface IReportRepository
{
    public Task<Report> save(string name, string content, long folderId);

    public Task<List<Report>> findAllByFolder(long idFolder);
}