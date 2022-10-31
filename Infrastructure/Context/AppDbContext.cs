using Microsoft.EntityFrameworkCore;
using MonqLab_test_task.Infrastructure.DAO;

namespace MonqLab_test_task.Infrastructure.Context;

/// <summary>
/// Инициализатор БД
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EmailDataEntity>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<EmailDataEntity>()
            .Property(x => x.Recipient)
            .IsRequired();
        modelBuilder.Entity<EmailDataEntity>()
            .Property(x => x.CreatedAt)
            .IsRequired();
        modelBuilder.Entity<EmailDataEntity>()
            .Property(x => x.Result)
            .IsRequired();
    }

    public virtual DbSet<EmailDataEntity> EmailData { get; set; }
}