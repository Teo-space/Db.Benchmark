using Db.Benchmark.Domain.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Benchmark.Infrastructure.EntityFramework.EntityConfiguration.Orders;

public class OrderPositionEfConfig : IEntityTypeConfiguration<OrderPosition>
{
	public void Configure(EntityTypeBuilder<OrderPosition> builder)
	{
		builder.HasKey(x => x.OrderPositionId);
		builder.HasIndex(x => new
		{
			x.OrderId,
			x.ProductId,
		}).IsUnique();

		builder.Property(x => x.OrderPositionId).IsRequired();//.ValueGeneratedNever();//.HasMaxLength(26);
		builder.Property(x => x.OrderId).IsRequired();//.ValueGeneratedNever();//.HasMaxLength(26);

		builder.Property(x => x.ProductId).IsRequired();//.HasMaxLength(26);
		builder.Property(x => x.ProductTypeId).IsRequired();//.HasMaxLength(26);

		builder.Property(x => x.Quanity).IsRequired();
		builder.Property(x => x.Price).IsRequired().HasPrecision(15, 6);

	}
}
