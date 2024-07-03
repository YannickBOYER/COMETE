using CometeAPI.Application.DTO.@in.Tag;
using CometeAPI.Application.DTO.@out;
using CometeAPI.Domain.models;

namespace CometeAPI.Application.mappers;

public class FolderTagMapper
{
    public FolderTag toEntity(FolderTagCreationRequestDTO dto) {
        if (dto.FolderId != null && dto.TagId != null)
        {
            return new FolderTag()
            {
                FolderId = (long)dto.FolderId,
                TagId = (long)dto.TagId,
            };

        }
        throw new Exception("Liaison impossible");
    }

    public FolderTagResponseDTO toDTO(FolderTag folderTag)
    {
        return new FolderTagResponseDTO() { 
            FolderId = (long)folderTag.FolderId,
            TagId = (long)folderTag.TagId,
        };
    }
}