

using DomainLayer.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersintenceLayer.Data.Configurations
{
    public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.Property(O => O.Price).HasColumnType("decimal(8,2)");

            builder.OwnsOne(O1 => O1.Prouduct);

        }
    }
}
