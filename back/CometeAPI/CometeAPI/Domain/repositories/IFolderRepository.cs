using CometeAPI.Domain.models;

namespace CometeAPI.Domain.repositories;

public interface IFolderRepository
{
    public Task<List<Folder>> findAllByIdUtilisateur(long idUtilisateur);
}