using CometeAPI.Application.DTO.@in.Folder;
using CometeAPI.Domain.models;

namespace CometeAPI.Domain.repositories;

public interface IFolderRepository
{
    public Task<List<Folder>> findAllByIdUtilisateur(long idUtilisateur);

    public Task<Folder> create(Folder folder);

    public Task delete(long id);

    public Task<bool> exists(long id);

    public Task<Folder> update(Folder folder);
}