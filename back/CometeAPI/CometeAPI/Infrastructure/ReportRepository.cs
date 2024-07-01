using CometeAPI.Application.DTO.@in;
using CometeAPI.Domain.models;
using CometeAPI.Domain.repositories;
using Microsoft.EntityFrameworkCore;

namespace CometeAPI.Infrastructure;

public class ReportRepository : ApplicationDbContext, IReportRepository
{
    public DbSet<Report> Reports { get; set; }
    public async Task<Report> save(ReportRequestDTO requestDTO)
    {
        try
        {
            Report report = new Report { 
                Name = requestDTO.FileName,
                Content = requestDTO.Text,
                FolderId = requestDTO.IdFolder,
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

    public async Task<Report> findById(long id)
    {
        Report? report = await Reports.FindAsync(id);
        if(report != null)
        {
            return report;
        }
        else
        {
            throw new NotImplementedException();
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