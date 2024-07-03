using CometeAPI.Application.DTO.@in.Tag;
using CometeAPI.Domain.models;
using CometeAPI.Domain.repositories;

namespace CometeAPI.Application;

public class TagService
{
    private readonly ITagRepository _tagRepository;
    private readonly IFolderTagReporitory _folderTagReporitory;
    public TagService(ITagRepository tagRepository, IFolderTagReporitory folderTagReporitory) { 
        _tagRepository = tagRepository;
        _folderTagReporitory = folderTagReporitory;
    }

    public async Task<Tag> create(Tag tag)
    {
        return await _tagRepository.save(tag);
    }

    public async Task delete(long id)
    {
        await _tagRepository.delete(id);
    }

    public async Task<List<Tag>> findAll()
    {
        return await _tagRepository.findAll();
    }

    public async Task<FolderTag> linkFolder(FolderTag folderTag)
    {
        return await _folderTagReporitory.save(folderTag);
    }

    public List<Folder> findFolderByTagId(long tagId)
    {
        return _folderTagReporitory.findFolderByTagId(tagId);
    }

    public async Task unlink(FolderTag folderTag)
    {
        await _folderTagReporitory.delete(folderTag.FolderId, folderTag.TagId);
    }
}