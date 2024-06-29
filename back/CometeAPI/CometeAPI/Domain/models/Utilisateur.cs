namespace CometeAPI.Domain.models;

public class Utilisateur
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    // Propriété de navigation vers les Folders
    public virtual ICollection<Folder> Folders { get; set; }
}
