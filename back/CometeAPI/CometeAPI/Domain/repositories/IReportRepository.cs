using CometeAPI.Domain.models;

namespace CometeAPI.Domain.repositories;

public interface IReportRepository
{
    public Report save(string name, string content);
}