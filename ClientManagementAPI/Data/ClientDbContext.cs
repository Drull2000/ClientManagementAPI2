using ClientManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientManagementAPI.Data;

public class ClientDbContext(DbContextOptions<ClientDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients => Set<Client>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(client => client.Id);
            entity.Property(client => client.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(client => client.LastName).HasMaxLength(100).IsRequired();
            entity.Property(client => client.Email).HasMaxLength(320).IsRequired();
            entity.Property(client => client.Phone).HasMaxLength(30);
            entity.Property(client => client.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            entity.HasIndex(client => client.Email).IsUnique();
        });
    }
}
