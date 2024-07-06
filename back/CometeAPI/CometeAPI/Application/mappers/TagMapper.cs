using CometeAPI.Application.DTO.@in.Tag;
using CometeAPI.Application.DTO.@out;
using CometeAPI.Domain.models;

namespace CometeAPI.Application.mappers;

public class TagMapper
{
    public Tag toEntity(TagCreationRequestDTO dto)
    {
        if (!string.IsNullOrWhiteSpace(dto.Name))
        {
            return new Tag()
            {
                Name = dto.Name,
            };

        }
        throw new ArgumentNullException(nameof(dto.Name));
    }

    public TagResponseDTO toDTO(Tag tag)
    {
        return new TagResponseDTO()
        {
            Id = tag.Id,
            Name = tag.Name,
        };
    }
}