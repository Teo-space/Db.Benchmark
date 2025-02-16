using Db.Benchmark.Domain.Enums;

namespace Db.Benchmark.Domain.Models.Orders;

public sealed record OrderStatus
{
	/// <summary>
	/// ID статуса заказа
	/// </summary>
	public required OrderStatuses OrderStatusId { get; set; }
	/// <summary>
	/// Наименование статуса
	/// </summary>
	public required string Name { get; set; }

	public List<Order> Orders { get; set; } = new List<Order>();

	public static OrderStatus Create(OrderStatuses orderStatuses)
	{
		return new OrderStatus
		{
			OrderStatusId = orderStatuses,
			Name = orderStatuses.Name,
		};
	}
}
