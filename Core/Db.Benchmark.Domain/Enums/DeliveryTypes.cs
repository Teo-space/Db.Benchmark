namespace Db.Benchmark.Domain.Enums;

/// <summary>
/// Типы доставок
/// </summary>
public sealed record DeliveryTypes(int Value, string Name) : BaseEnum<DeliveryTypes>(Value, Name)
{
	public new static IReadOnlyCollection<DeliveryTypes> Enums => [StorePickup, CourierDelivery];

	/// <summary>
	/// Самовывоз из магазина
	/// </summary>
	public static readonly DeliveryTypes StorePickup = new DeliveryTypes(1, "Самовывоз из магазина");
	/// <summary>
	/// Доставка курьером
	/// </summary>
	public static readonly DeliveryTypes CourierDelivery = new DeliveryTypes(2, "Доставка курьером");
}