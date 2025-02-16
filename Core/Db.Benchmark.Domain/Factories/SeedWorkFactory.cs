using Db.Benchmark.Domain.Enums;
using Db.Benchmark.Domain.Models.Deliveries;
using Db.Benchmark.Domain.Models.Orders;
using Db.Benchmark.Domain.Models.Payments;
using Db.Benchmark.Domain.Models.Products;

namespace Db.Benchmark.Domain.Factories;

public static class SeedWorkFactory
{
	public static IReadOnlyCollection<DeliveryStatus> GetDeliveryStatuses()
	{
		return [
			DeliveryStatus.Create(DeliveryStatuses.Pending),
			DeliveryStatus.Create(DeliveryStatuses.InWork),
			DeliveryStatus.Create(DeliveryStatuses.Delivering),
			DeliveryStatus.Create(DeliveryStatuses.Issued),
			DeliveryStatus.Create(DeliveryStatuses.Canceled),
		];
	}

	public static IReadOnlyCollection<DeliveryType> GetDeliveryTypes()
	{
		return [
			DeliveryType.Create(DeliveryTypes.StorePickup, 0, 0),
			DeliveryType.Create(DeliveryTypes.CourierDelivery, 300, 1500),
		];
	}

	public static IReadOnlyCollection<OrderStatus> GetOrderStatuses()
	{
		return [
			OrderStatus.Create(OrderStatuses.Pending),
			OrderStatus.Create(OrderStatuses.Assembling),
			OrderStatus.Create(OrderStatuses.DeliveryPending),
			OrderStatus.Create(OrderStatuses.Delivering),
			OrderStatus.Create(OrderStatuses.Delivered),
			OrderStatus.Create(OrderStatuses.Finished),
			OrderStatus.Create(OrderStatuses.Canceled),
		];
	}

	public static IReadOnlyCollection<PaymentType> GetPaymentTypes()
	{
		return [
			PaymentType.Create(PaymentTypes.CardInOffice),
			PaymentType.Create(PaymentTypes.CardToCourier),
			PaymentType.Create(PaymentTypes.CashInOffice),
			PaymentType.Create(PaymentTypes.CashToCourier),
		];
	}

	public static IReadOnlyCollection<Maker> GetMakers()
	{
		return [
			new Maker
			{
				MakerId = 1,
				Name = "Samsung"
			}
		];
	}

	public static IReadOnlyCollection<ProductType> GetProductTypes()
	{
		return new ProductType[]
		{
			new ProductType
			{
				ProductTypeId = 1,
				Name = "Смартфоны",
				Description = "Смартфоны",
			},
			new ProductType
			{
				ProductTypeId = 2,
				Name = "Аксесуары для смартфонов",
				Description = "Аксесуары для смартфонов",
			},
		};
	}

	public static IReadOnlyCollection<Product> GetProducts(Maker maker, ProductType productType)
	{
		return new Product[]
		{
			new Product
			{
				ProductId = 1,
				MakerId = maker.MakerId,
				ProductTypeId = productType.ProductTypeId,
				Name = "Galaxy S24 Ultra",
				Description = "Смартфон",
				Price = 130_000
			},
			new Product
			{
				ProductId = 2,
				MakerId = maker.MakerId,
				ProductTypeId = productType.ProductTypeId,
				Name = "Galaxy S24",
				Description = "Смартфон",
				Price = 90_000
			},
		};
	}


}
