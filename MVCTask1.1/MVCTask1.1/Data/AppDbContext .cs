using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVCTask1._1.Models;

namespace MVCTask1._1.Data;


public class AppDbContext : DbContext
{
    private object optionsBuilder;

    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Group>()
            .HasOne(g => g.Teacher)
            .WithMany(t => t.Groups)
            .HasForeignKey(g => g.TeacherId);

        
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Group)
            .WithMany(g => g.Students)
        .HasForeignKey(s => s.GroupId);

        
    }
}
