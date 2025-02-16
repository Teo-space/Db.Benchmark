using Db.Benchmark.Domain.Enums;
using Db.Benchmark.Domain.Models.Deliveries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Benchmark.Infrastructure.EntityFramework.EntityConfiguration.Deliveries;

public class DeliveryStatusEfConfig : IEntityTypeConfiguration<DeliveryStatus>
{
	public void Configure(EntityTypeBuilder<DeliveryStatus> builder)
	{
		builder.HasKey(x => x.DeliveryStatusId);

		builder.Property(x => x.DeliveryStatusId)
			.ValueGeneratedNever()
			.HasConversion(status => status.Value, (int statusId) => DeliveryStatuses.From(statusId));

		builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
	}
}
