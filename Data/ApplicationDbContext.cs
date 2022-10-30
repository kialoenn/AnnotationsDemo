using AnnotationsDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnnotationsDemo.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Student>().HasKey(table => new
        {
            table.StudentNumber,
            table.School
        });

        // GETDATE() in SQL Server
        builder.Entity<Student>()
            .Property(s => s.DateCreated)
            .HasDefaultValueSql("DATE('now')");
    }


    public DbSet<Student>? Students { get; set; }
}
