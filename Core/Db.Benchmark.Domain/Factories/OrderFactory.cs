using Db.Benchmark.Domain.Enums;
using Db.Benchmark.Domain.Models.Orders;

namespace Db.Benchmark.Domain.Factories;

public static class OrderFactory
{
	static IReadOnlyList<Phone> Phones { get; set; } = 
		Enumerable.Range(0, 1000_000)
		.Select(x => new Phone(+7_987_000_0000L + x))
		.ToList();

	static readonly Random Random = new Random();

	public static Order Create()
	{
		var orderClient = new OrderClient
		{
			Phone = Phones[Random.Next(0, Phones.Count)],//new Phone(+7_987_123_4567L),
			Email = "john.breadly@gmail.com",
			Name = "John",
			Patronymic = "Steavensen",
			SurName = "Breadly",
		};

		var orderDelivery = new OrderDelivery
		{
			Type = DeliveryTypes.StorePickup,
			Address = new OrderDeliveryAddress
			{
				City = "Moscow",
				Street = "Lenina",
				House = "123",
				Apartment = "65",
				Entrance = "5",
				Floor = "5",
			}
		};

		var orderPayment = new OrderPayment
		{
			Type = PaymentTypes.CardToCourier,
		};

		var order = Order.Create(orderClient, orderDelivery, orderPayment);

		return order;
	}
}
