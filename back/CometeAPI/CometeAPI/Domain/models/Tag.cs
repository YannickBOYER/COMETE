using System.ComponentModel.DataAnnotations.Schema;

namespace CometeAPI.Domain.models;

public class Tag
{
    public long Id { get; set; }
    public string Name { get; set; }

    public ICollection<FolderTag> FolderTags { get; set; }
}