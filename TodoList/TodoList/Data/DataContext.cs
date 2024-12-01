using Microsoft.EntityFrameworkCore;
using TodoList.Models;
using Taks = TodoList.Models.Task;

namespace TodoList.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects{ get; set; }
        public DbSet<Taks> Tasks { get; set; }
        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasOne(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Taks>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<History>()
                .HasOne(h => h.TaskModified)
                .WithMany(t => t.Histories)
                .HasForeignKey(h => h.TaskId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
