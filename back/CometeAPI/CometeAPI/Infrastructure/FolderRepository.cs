using CometeAPI.Application.DTO.@in;
using CometeAPI.Domain.exception;
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

    private async Task<Folder> findById(long id)
    {
        Folder? folder = await Folders.FindAsync(id);
        if (folder != null)
        {
            return folder;
        }
        else
        {
            throw new FolderNotFoundException();
        }
    }

    public async Task delete(long id)
    {
        Folder folder = await findById(id);
        Folders.Remove(folder);
        await SaveChangesAsync();
    }

    public async Task<bool> exists(long id)
    {
        Folder folder = await findById(id);
        return await Folders.ContainsAsync(folder);
    }

    public async Task<Folder> update(FolderUpdateRequestDTO requestDTO)
    {
        Folder folder = await findById(requestDTO.Id);
        if (string.IsNullOrWhiteSpace(folder.Name))
        {
            folder.Name = requestDTO.Name;
        }
        await SaveChangesAsync();
        return folder;
    }
}