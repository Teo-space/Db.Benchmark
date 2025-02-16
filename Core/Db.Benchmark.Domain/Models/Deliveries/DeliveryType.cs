using Db.Benchmark.Domain.Enums;

namespace Db.Benchmark.Domain.Models.Deliveries;

/// <summary>
/// тип доставки
/// </summary>
public class DeliveryType
{
	/// <summary>
	/// ID типа доставки
	/// </summary>
	public required DeliveryTypes DeliveryTypeId { get; set; }

	/// <summary>
	/// наименование
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// Цена
	/// </summary>
	public required decimal Price { get; set; }

	/// <summary>
	/// Доставка бесплатно с суммы заказа
	/// </summary>
	public required decimal DeliveryFreeOrder { get; set; }

	public static DeliveryType Create(DeliveryTypes deliveryTypes, decimal price, decimal deliveryFreeOrder)
	{
		return new DeliveryType
		{
			DeliveryTypeId = deliveryTypes,
			Name = deliveryTypes.Name,
			Price = price,
			DeliveryFreeOrder = deliveryFreeOrder
		};
	}
}