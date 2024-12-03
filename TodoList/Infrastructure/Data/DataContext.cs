using Domain.Entities;
using Domain.Entities.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento: Project -> User
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Owner) // Renomeado para refletir o nome correto da propriedade na entidade
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento: TaskItem -> Project
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Project)
                .WithMany(p => p.TaskItem)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento: History -> TaskItem
            modelBuilder.Entity<History>()
                .HasOne(h => h.TaskItem)
                .WithMany(t => t.Histories)
                .HasForeignKey(h => h.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento: History -> User (quem modificou)
            modelBuilder.Entity<History>()
                .HasOne(h => h.ModifiedUser)
                .WithMany()
                .HasForeignKey(h => h.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurações adicionais
            base.OnModelCreating(modelBuilder);
        }
    }
}
