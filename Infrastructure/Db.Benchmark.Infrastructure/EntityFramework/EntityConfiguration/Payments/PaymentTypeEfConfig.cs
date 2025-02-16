using Db.Benchmark.Domain.Enums;
using Db.Benchmark.Domain.Models.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Benchmark.Infrastructure.EntityFramework.EntityConfiguration.Payments;

public class PaymentTypeEfConfig : IEntityTypeConfiguration<PaymentType>
{
	public void Configure(EntityTypeBuilder<PaymentType> builder)
	{
		builder.HasKey(x => x.PaymentTypeId);

		builder.Property(x => x.PaymentTypeId).IsRequired()
			.HasConversion(status => status.Value, (int statusId) => PaymentTypes.From(statusId));

		builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
	}
}
