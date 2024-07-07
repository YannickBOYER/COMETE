using CometeAPI.Application.DTO.@in.Tag;
using CometeAPI.Application.DTO.@out;
using CometeAPI.Domain.exception;
using CometeAPI.Domain.models;

namespace CometeAPI.Application.mappers;

public class FolderTagMapper
{
    public FolderTag toEntity(long tagId, long? folderId)
    {
        if (folderId != null)
        {
            return new FolderTag()
            {
                FolderId = (long)folderId,
                TagId = tagId,
            };

        }
        throw new FolderTagLinkException();
    }

    public FolderTagResponseDTO toDTO(FolderTag folderTag)
    {
        return new FolderTagResponseDTO()
        {
            FolderId = folderTag.FolderId,
            TagId = folderTag.TagId,
        };
    }
}