using CometeAPI.Domain.models;
using CometeAPI.Domain.repositories;

namespace CometeAPI.Infrastructure;

public class ReportRepository : IReportRepository
{
    public Report save(string name, string content)
    {
        // TODO : implémenter la sauvegarde en base de données
        return new Report(1, name, content);
    }
}