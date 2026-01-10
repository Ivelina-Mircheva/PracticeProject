using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PracticeProject.ViewModels.Projects;

namespace PracticeProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //delete connection project -> task
            builder.Entity<Project>()
                .HasMany(t => t.Tasks)
                .WithOne(p => p.Project)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            //delete connection user -> task
            builder.Entity<User>()
                .HasMany(t => t.Tasks)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<PracticeProject.ViewModels.Projects.ProjectViewModel> ProjectViewModel { get; set; } = default!;
    }
}
