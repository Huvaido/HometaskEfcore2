using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

using Domain;
using Microsoft.EntityFrameworkCore;


public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<StudentGroup> StudentGroups { get; set; }
    public DbSet<Adress> Adresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentGroup>().HasKey(sg => new { sg.StudentId, sg.GroupId });

        // modelBuilder.Entity<Student>()
        //     .Property(s => s.Address)
        //     .HasMaxLength(200)
        //     .IsRequired();

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Groups)
            .WithOne(g => g.Course)
            .HasForeignKey(g => g.CourseId);

        modelBuilder.Entity<Adress>()
            .HasOne(a => a.Student)
            .WithOne(s => s.Address)
            .HasForeignKey<Adress>(a => a.StudentId);

        modelBuilder.Entity<StudentGroup>()
            .HasOne(sg => sg.Group)
            .WithMany(g => g.StudentGroups)
            .HasForeignKey(sg => sg.GroupId);

        modelBuilder.Entity<StudentGroup>()
            .HasOne(sg => sg.Student)
            .WithMany(s => s.StudentGroups)
            .HasForeignKey(sg => sg.StudentId);
    }
}


