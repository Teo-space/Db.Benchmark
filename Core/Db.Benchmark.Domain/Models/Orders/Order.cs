using Db.Benchmark.Domain.Enums;
using Db.Benchmark.Domain.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Benchmark.Domain.Models.Orders;

public sealed record Order
{
	/// <summary>
	/// ID Заказа
	/// </summary>
	public long OrderId { get; private set; }

	/// <summary>
	/// Статус заказа
	/// </summary>
	public OrderStatuses StatusId { get; private set; }
	public OrderStatus Status { get; private set; }

	/// <summary>
	/// Даты создания, изменения и готовности
	/// </summary>
	public OrderDate Date { get; private set; }
	/// <summary>
	/// Информация о клиенте
	/// </summary>
	public OrderClient Client { get; private set; }
	/// <summary>
	/// Информация о доставке
	/// </summary>
	public OrderDelivery Delivery { get; private set; }
	/// <summary>
	/// Оплата
	/// </summary>
	public OrderPayment Payment { get; private set; }
	/// <summary>
	/// Позиции заказа
	/// </summary>
	public HashSet<OrderPosition> Positions { get; set; } = new HashSet<OrderPosition>();

	/// <summary>
	/// Сумма
	/// </summary>
	[NotMapped]
	public decimal Sum => Positions.Sum(p => p.Sum);


	public static Order Create(OrderClient client, OrderDelivery delivery, OrderPayment payment)
	{
		return new Order
		{
			//OrderId = Ulid.NewUlid(),
			OrderId = 0L,
			StatusId = OrderStatuses.Pending,

			Client = client,
			Delivery = delivery,
			Payment = payment,

			Date = new OrderDate()
			{
				Created = DateTime.Now,
				Modified = DateTime.Now,
				Finished = default,
			}
		};
	}

	public OrderPosition Add(Product product, int quantity)
	{
		var orderPosition = OrderPosition.Create(this, product, quantity);

		this.Positions.Add(orderPosition);
		this.Payment.UpdateSum(this);

		return orderPosition;
	}

}
