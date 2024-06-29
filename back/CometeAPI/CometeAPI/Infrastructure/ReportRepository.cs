using CometeAPI.Domain.models;
using CometeAPI.Domain.repositories;
using Microsoft.EntityFrameworkCore;

namespace CometeAPI.Infrastructure;

public class ReportRepository : ApplicationDbContext, IReportRepository
{
    public DbSet<Report> Reports { get; set; }
    public async Task<Report> save(string name, string content, long folderId)
    {
        try
        {
            Report report = new Report { 
                Name = name,
                Content = content,
                FolderId = folderId,
            };
            Reports.Add(report);
            await SaveChangesAsync();
            return report;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<List<Report>> findAllByFolder(long folderId)
    {
        List<Report> reports = await Reports
            .Include(r => r.Folder)
            .Where(r => r.Folder.Id == folderId)
            .ToListAsync();

        return reports;
    }
}