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
}