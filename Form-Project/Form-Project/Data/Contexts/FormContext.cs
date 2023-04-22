using Form_Project.Data.Configurations;
using Form_Project.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Form_Project.Data.Contexts
{
    public class FormContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Form> Forms { get; set; }
        public DbSet<Field> Fields { get; set; }
        public FormContext(DbContextOptions<FormContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FormConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
