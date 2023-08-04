using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Model;
namespace EmployeeManagementSystem
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships and constraints if needed
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Salaries)
                .WithOne(s => s.Employee)
                .HasForeignKey(s => s.EmpID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Attachments)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmpID);
        }
    }
    
}
