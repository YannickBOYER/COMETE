using CometeAPI.Application.DTO.@in.Folder;
using CometeAPI.Application.DTO.@out;
using CometeAPI.Domain.models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CometeAPI.Application.mappers;

public class FolderMapper
{
    public FolderResponseDTO toDTO(Folder folder)
    {
        return new FolderResponseDTO()
        {
            Id = folder.Id,
            Name = folder.Name,
        };
    }

    public Folder toEntity(FolderCreateRequestDTO dto)
    {
        if (!string.IsNullOrWhiteSpace(dto.Name))
        {
            return new Folder()
            {
                Name = dto.Name,
                UtilisateurId = dto.IdUtilisateur,
            };
        }
        else
        {
            throw new ArgumentNullException(nameof(Folder.Name));
        }
    }

    public Folder toEntity(FolderUpdateRequestDTO dto)
    {
        if (!string.IsNullOrWhiteSpace(dto.Name))
        {
            return new Folder()
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }
        else
        {
            throw new ArgumentNullException(nameof(Folder.Name));
        }
    }
}