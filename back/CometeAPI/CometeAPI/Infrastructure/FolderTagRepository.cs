using CometeAPI.Domain.exception;
using CometeAPI.Domain.models;
using CometeAPI.Domain.repositories;
using Microsoft.EntityFrameworkCore;

namespace CometeAPI.Infrastructure;

public class FolderTagRepository : ApplicationDbContext, IFolderTagReporitory
{
    public DbSet<FolderTag> FolderTags { get; set; }

    public async Task<FolderTag> save(FolderTag folderTag)
    {
        try
        {
            await FolderTags.AddAsync(folderTag);
            await SaveChangesAsync();
            return folderTag;

        } catch (Exception ex) {
            throw;
        }
    }

    public List<Folder> findFolderByTagId(long tagId)
    {
        List<Folder> folders = FolderTags
                         .Where(ft => ft.TagId == tagId)
                         .Select(ft => ft.Folder)
                         .ToList();
        return folders;
    }

    public async Task delete(long folderId, long tagId)
    {
       FolderTag folderTag = findByIds(folderId, tagId);
       FolderTags.Remove(folderTag);
       await SaveChangesAsync();
    }

    private FolderTag findByIds(long folderId, long tagId)
    {
        FolderTag? folderTag = FolderTags.Where(ft => ft.FolderId == folderId && ft.TagId == tagId).FirstOrDefault();
        if (folderTag != null)
        {
            return folderTag;
        }
        else
        {
            throw new FolderTagNotFoundException();
        }
    }
}