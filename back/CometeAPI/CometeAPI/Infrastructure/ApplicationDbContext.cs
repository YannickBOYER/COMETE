using CometeAPI.Domain.models;
using Microsoft.EntityFrameworkCore;

public abstract class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=localhost;Database=comete;User=root;Password=comete;",
            new MySqlServerVersion(new Version(8, 0, 21)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Utilisateur>()
            .ToTable("Utilisateurs");

        modelBuilder.Entity<Folder>()
            .ToTable("Folders");

        modelBuilder.Entity<Report>()
            .ToTable("Reports");

        modelBuilder.Entity<FolderTag>()
            .ToTable("Folder_tags")
            .HasKey(ft => new { ft.FolderId, ft.TagId });

        modelBuilder.Entity<Report>()
            .Property(r => r.FolderId)
            .HasColumnName("folder_id");

        modelBuilder.Entity<Report>()
            .HasOne(r => r.Folder)
            .WithMany(f => f.Reports)
            .HasForeignKey(r => r.FolderId)
            .IsRequired();

        modelBuilder.Entity<FolderTag>()
            .HasOne(ft => ft.Folder)
            .WithMany(f => f.FolderTags)
            .HasForeignKey(ft => ft.FolderId);

        modelBuilder.Entity<FolderTag>()
            .HasOne(ft => ft.Tag)
            .WithMany(t => t.FolderTags)
            .HasForeignKey(ft => ft.TagId);

        base.OnModelCreating(modelBuilder);
    }

}
