using CometeAPI.Application;
using CometeAPI.Application.DTO.@in;
using CometeAPI.Domain.exception;
using CometeAPI.Domain.models;
using CometeAPI.Domain.repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

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
            throw new ReportNotFoundException();
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

    public async Task delete(long id)
    {
        Report report = await findById(id);
        Reports.Remove(report);
        await SaveChangesAsync();
    }

    public async Task<bool> exists(long id)
    {
        Report report = await findById(id);
        return await Reports.ContainsAsync(report);
    }

    public async Task<Report> update(ReportUpdateRequestDTO requestDTO)
    {
        Report report = await findById(requestDTO.Id);
        if (!string.IsNullOrWhiteSpace(requestDTO.Name))
        {
            report.Name = requestDTO.Name;
        }
        if (!string.IsNullOrWhiteSpace(requestDTO.Content))
        {
            report.Content = requestDTO.Content;
        }
        await SaveChangesAsync();
        return report;
    }
}