using CometeAPI.Application.DTO.@in;
using CometeAPI.Domain.models;

namespace CometeAPI.Domain.repositories;

public interface IFolderRepository
{
    public Task<List<Folder>> findAllByIdUtilisateur(long idUtilisateur);

    public Task<Folder> create(FolderCreateRequestDTO requestDTO);

    public Task delete(long id);

    public Task<bool> exists(long id);

    public Task<Folder> update(FolderUpdateRequestDTO requestDTO);
}