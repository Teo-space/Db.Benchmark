using Db.Benchmark.Domain.Enums;
using Db.Benchmark.Domain.Models.Deliveries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Benchmark.Infrastructure.EntityFramework.EntityConfiguration.Deliveries;

public class DeliveryTypeEfConfig : IEntityTypeConfiguration<DeliveryType>
{
	public void Configure(EntityTypeBuilder<DeliveryType> builder)
	{
		builder.HasKey(x => x.DeliveryTypeId);

		builder.Property(x => x.DeliveryTypeId)
			.ValueGeneratedNever()
			.HasConversion(status => status.Value, (int statusId) => DeliveryTypes.From(statusId));

		builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

		builder.Property(x => x.Price).IsRequired().HasPrecision(15, 6);
	}
}
