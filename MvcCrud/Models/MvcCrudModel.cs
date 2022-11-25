using System.Data.Entity;

namespace MvcCrud.Models
{
    public partial class MvcCrudModel : DbContext
    {
        public MvcCrudModel() : base("name=MvcCrud")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Units)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}