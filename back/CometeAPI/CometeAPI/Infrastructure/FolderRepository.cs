using CometeAPI.Application.DTO.@in;
using CometeAPI.Domain.models;
using CometeAPI.Domain.repositories;
using Microsoft.EntityFrameworkCore;

namespace CometeAPI.Infrastructure;

public class FolderRepository : ApplicationDbContext, IFolderRepository
{
    public DbSet<Folder> Folders { get; set; }

    public async Task<List<Folder>> findAllByIdUtilisateur(long idUtilisateur)
    {
        List<Folder> folders = await Folders
               .Where(f => f.UtilisateurId == idUtilisateur)
               .ToListAsync();

        return folders;
    }

    public async Task<Folder> create(FolderCreateRequestDTO requestDTO)
    {
        try
        {
            Folder folder = new Folder()
            {
                Name = requestDTO.Name,
                UtilisateurId = requestDTO.IdUtilisateur,
            };
            Folders.Add(folder);
            await SaveChangesAsync();
            return folder;
        }
        catch (Exception)
        {
            throw;
        }
    }
}