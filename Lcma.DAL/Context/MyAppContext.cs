using Lcma.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Lcma.DAL.Context
{
    public class MyAppContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }

        static MyAppContext() => Database.SetInitializer(new Seeder());

        public MyAppContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Remove<PluralizingTableNameConvention>();
            builder.Configurations.Add(new EmployeeConfig());
            builder.Configurations.Add(new ProjectConfig());
        }
    }

    class EmployeeConfig : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfig()
        {
            ToTable("Employee");
            HasKey(e => e.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.Id).IsRequired();
            Property(e => e.FirstName).IsRequired().HasMaxLength(40);
            Property(e => e.LastName).IsRequired().HasMaxLength(40);
            Property(e => e.MiddleName).HasMaxLength(40);
            Property(e => e.Email).HasMaxLength(50);
        }
    }

    class ProjectConfig : EntityTypeConfiguration<Project>
    {
        public ProjectConfig()
        {
            ToTable("Project");
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasOptional(p => p.Manager).WithMany().HasForeignKey(p => p.ManagerId);
            Property(p => p.Performer).IsRequired().HasMaxLength(50);
            Property(p => p.Title).IsRequired().HasMaxLength(100);
            Property(p => p.Customer).IsRequired().HasMaxLength(100);
            Property(p => p.Comment).HasMaxLength(100);
            Property(p => p.CreatedAt).IsRequired();
            Property(p => p.DateStart).IsRequired();
            Property(p => p.DateEnd).IsOptional();
            HasMany(p => p.Employees)
                .WithMany(e => e.Projects)
                .Map(ep =>
                {
                    ep.MapLeftKey("ProjectId");
                    ep.MapRightKey("EmployeeId");
                    ep.ToTable("ProjectEmployee");
                });
        }
    }
}
