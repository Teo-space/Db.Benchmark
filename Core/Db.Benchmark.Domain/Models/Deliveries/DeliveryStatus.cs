using Db.Benchmark.Domain.Enums;

namespace Db.Benchmark.Domain.Models.Deliveries;

/// <summary>
/// Статусы доставки
/// </summary>
public class DeliveryStatus
{
	/// <summary>
	/// ID статуса доставки
	/// </summary>
	public required DeliveryStatuses DeliveryStatusId { get; set; }
	/// <summary>
	/// Наименование статуса доставки
	/// </summary>
	public required string Name { get; set; }

	public static DeliveryStatus Create(DeliveryStatuses deliveryStatuses)
	{
		return new DeliveryStatus
		{
			DeliveryStatusId = deliveryStatuses,
			Name = deliveryStatuses.Name,
		};
	}
}