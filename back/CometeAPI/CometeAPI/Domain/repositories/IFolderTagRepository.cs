using CometeAPI.Domain.models;

namespace CometeAPI.Domain.repositories;

public interface IFolderTagReporitory
{
    public Task<FolderTag> save(FolderTag folderTag);

    public List<Folder> findFolderByTagId(long tagId);
    public Task delete(long folderId, long tagId);
}