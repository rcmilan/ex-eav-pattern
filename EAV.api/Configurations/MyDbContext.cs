using EAV.api.Entities.Base;
using EAV.api.Entities.EAV;
using Microsoft.EntityFrameworkCore;

namespace EAV.api.Configurations
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<AttributeValueType>();

            modelBuilder.Entity<CustomEntity>(opt =>
            {
                opt.ToTable("CustomEntities");
                opt.HasKey(e => e.Id);

                opt.OwnsMany(e => e.Attributes, a =>
                {
                    a.WithOwner().HasForeignKey("EntityId");
                    a.HasIndex("EntityId");
                    a.ToTable("CustomAttributes");
                    a.Property<Guid>("Id");
                    a.Property(a => a.Name).IsRequired();
                    a.Property(a => a.ValueType).IsRequired().HasConversion<string>();

                    a.OwnsMany(a => a.Values, v =>
                    {
                        v.WithOwner().HasForeignKey("AttributeId");
                        v.HasIndex("AttributeId");
                        v.ToTable("CustomValues");
                        v.Property<Guid>("Id");
                        v.Property(v => v.ValueData).IsRequired();
                    });
                });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
