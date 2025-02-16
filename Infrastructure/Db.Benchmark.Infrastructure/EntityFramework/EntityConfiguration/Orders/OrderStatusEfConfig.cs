using Db.Benchmark.Domain.Enums;
using Db.Benchmark.Domain.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Benchmark.Infrastructure.EntityFramework.EntityConfiguration.Orders;

public class OrderStatusEfConfig : IEntityTypeConfiguration<OrderStatus>
{
	public void Configure(EntityTypeBuilder<OrderStatus> builder)
	{
		builder.HasKey(x => x.OrderStatusId);

		builder.Property(x => x.OrderStatusId)
			.HasConversion(status => status.Value, (int statusId) => OrderStatuses.From(statusId));

		builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
	}
}