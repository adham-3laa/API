
using DomainLayer.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersintenceLayer.Data.Configurations
{
    public class DelivaryMethodConfigurations : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.ToTable("DeliveryMethods");
            builder.Property(D => D.Price).HasColumnType("decimal(8,2)");
            builder.Property(D => D.ShortName).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(D => D.Description).HasColumnType("varchar").HasMaxLength(100);            
            builder.Property(D => D.DelivaryTime).HasColumnType("varchar").HasMaxLength(50);            
        }
    }
}
