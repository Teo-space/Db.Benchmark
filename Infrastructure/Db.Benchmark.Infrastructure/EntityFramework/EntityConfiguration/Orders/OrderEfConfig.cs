using Db.Benchmark.Domain.Enums;
using Db.Benchmark.Domain.Models.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Db.Benchmark.Infrastructure.EntityFramework.EntityConfiguration.Orders;

public class OrderEfConfig : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		int o = 0;

		builder.HasKey(x => x.OrderId);

		builder.Property(x => x.OrderId).HasColumnOrder(o++);//.ValueGeneratedNever();//.HasMaxLength(26);

		builder.HasIndex(x => x.StatusId);
		builder.Property(x => x.StatusId)
			.HasConversion(status => status.Value, (int statusId) => OrderStatuses.From(statusId))
			.HasColumnOrder(o++)
			.IsRequired()
			.IsConcurrencyToken();

		builder.HasOne(x => x.Status).WithMany(x => x.Orders)
			.HasForeignKey(x => x.StatusId).HasPrincipalKey(x => x.OrderStatusId);


		builder.ComplexProperty(x => x.Date, date =>
		{
			date.IsRequired();
			date.Property(x => x.Created).HasColumnOrder(o++).IsRequired().HasColumnType("datetime");
			date.Property(x => x.Modified).HasColumnOrder(o++).IsRequired().HasColumnType("datetime");
			date.Property(x => x.Finished).HasColumnOrder(o++).HasColumnType("datetime");
		});

		builder.ComplexProperty(x => x.Client, client =>
		{
			client.IsRequired();

			client.Property(x => x.Phone).HasColumnOrder(o++).IsRequired()
				.HasConversion((Phone phone) => phone.Value, (long phone) => new Phone(phone));

			client.Property(x => x.Email).HasColumnOrder(o++).HasMaxLength(100);
			client.Property(x => x.Name).HasColumnOrder(o++).IsRequired().HasMaxLength(100);
			client.Property(x => x.SurName).HasColumnOrder(o++).IsRequired().HasMaxLength(100);
			client.Property(x => x.Patronymic).HasColumnOrder(o++).IsRequired().HasMaxLength(100);
		});

		builder.ComplexProperty(x => x.Delivery, delivery =>
		{
			delivery.IsRequired();

			delivery.Property(x => x.Type).HasColumnOrder(o++).IsRequired()
			.HasConversion(status => status.Value, (int statusId) => DeliveryTypes.From(statusId));

			delivery.Property(x => x.Status).HasColumnOrder(o++).IsRequired()
			.HasConversion(status => status.Value, (int statusId) => DeliveryStatuses.From(statusId));

			delivery.Property(x => x.Start).HasColumnOrder(o++).HasColumnType("datetime");
			delivery.Property(x => x.End).HasColumnOrder(o++).HasColumnType("datetime");

			delivery.ComplexProperty(x => x.Address, address =>
			{
				address.IsRequired();

				address.Property(x => x.City).HasColumnOrder(o++).IsRequired().HasMaxLength(100);
				address.Property(x => x.Street).HasColumnOrder(o++).IsRequired().HasMaxLength(100);
				address.Property(x => x.House).HasColumnOrder(o++).IsRequired().HasMaxLength(100);
				address.Property(x => x.Apartment).HasColumnOrder(o++).IsRequired().HasMaxLength(100);

				address.Property(x => x.Entrance).HasColumnOrder(o++).HasMaxLength(100);
				address.Property(x => x.Floor).HasColumnOrder(o++).HasMaxLength(100);
			});
		});

		builder.ComplexProperty(x => x.Payment, payment =>
		{
			payment.IsRequired();

			payment.Property(x => x.Type).HasColumnOrder(o++).IsRequired()
			.HasConversion(status => status.Value, (int statusId) => PaymentTypes.From(statusId));

			payment.Property(x => x.Sum).HasColumnOrder(o++).IsRequired();
			payment.Property(x => x.Payed).HasColumnOrder(o++).HasColumnType("datetime");
			payment.Property(x => x.IsPayed).HasColumnOrder(o++).IsRequired().HasPrecision(15, 6);
		});

	}
}
