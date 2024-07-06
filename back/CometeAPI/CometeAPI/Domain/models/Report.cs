using System.ComponentModel.DataAnnotations.Schema;

namespace CometeAPI.Domain.models;

public class Report
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Content { get; set; }

    [Column("folder_id")]
    public long FolderId { get; set; }

    // Propri�t� de navigation vers le Folder
    public virtual Folder Folder { get; set; }
}
