using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration;
public partial class ModelConfiguration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.Property(b => b.Id).HasColumnName("ID").IsRequired();
            builder.Property(b => b.ModelId).HasColumnName("ModelId").IsRequired();
            builder.Property(b => b.ModelYear).HasColumnName("ModelYear").IsRequired();
            builder.Property(b => b.CarState).HasColumnName("State").IsRequired();
            builder.Property(b => b.Plate).HasColumnName("Plate").IsRequired();
            builder.Property(b => b.Kilometer).HasColumnName("Kilometer").IsRequired();
            builder.Property(b => b.MinFindexScore).HasColumnName("MinFindexScore").IsRequired();
            builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");
            builder.HasOne(b => b.Model);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
