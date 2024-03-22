using MediatorApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediatorApi.Context;

public class MediatrDBContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=HTO\\SQLEXPRESS;Database=Advenced;Integrated Security=True;TrustServerCertificate=True");
    }

    public DbSet<User> Users { get; set; }
}
