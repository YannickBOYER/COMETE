using CometeAPI.Application.DTO.@in.Tag;
using CometeAPI.Domain.models;

namespace CometeAPI.Domain.repositories;

public interface ITagRepository
{
    public Task<Tag> save(Tag tag);
    public Task delete(long id);
    public Task<List<Tag>> findAll();
    public Task<bool> exists(long id);
}