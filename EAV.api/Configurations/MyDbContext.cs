using EAV.api.Entities.Base;
using EAV.api.Entities.EAV;
using Microsoft.EntityFrameworkCore;

namespace EAV.api.Configurations
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<AttributeValType>();

            modelBuilder.Entity<CustomEntity>(opt =>
            {
                opt.ToTable("CustomEntities");
                opt.HasKey(e => e.Id);

                opt.Property(e => e.Name).IsRequired();

                opt.OwnsMany(e => e.Attributes, a =>
                {
                    a.WithOwner();

                    a.ToTable("CustomAttributes");
                    a.Property<Guid>("Id");
                    a.HasKey("Id");

                    a.Property(a => a.Name).IsRequired();
                    a.Property(a => a.ValueType).IsRequired().HasConversion<string>();

                    a.OwnsMany(a => a.Values, v =>
                    {
                        v.WithOwner();

                        v.ToTable("CustomValues");
                        v.Property<Guid>("Id");
                        v.HasKey("Id");

                        v.Property(v => v.ValueData).IsRequired();
                    });
                });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}