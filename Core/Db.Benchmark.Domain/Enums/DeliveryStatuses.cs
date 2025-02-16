
namespace Db.Benchmark.Domain.Enums;

/// <summary>
/// Статусы доставки
/// </summary>
public sealed record DeliveryStatuses(int Value, string Name) : BaseEnum<DeliveryStatuses>(Value, Name)
{
	public new static IReadOnlyCollection<DeliveryStatuses> Enums => [Pending, InWork, Delivering, Issued, Canceled];

	/// <summary>
	/// Ожидает
	/// </summary>
	public static readonly DeliveryStatuses Pending = new DeliveryStatuses(0, "Ожидает");
	/// <summary>
	/// Взят в работу
	/// </summary>
	public static readonly DeliveryStatuses InWork = new DeliveryStatuses(100, "Взят в работу");
	/// <summary>
	/// В процессе доставки
	/// </summary>
	public static readonly DeliveryStatuses Delivering = new DeliveryStatuses(200, "В процессе доставки");
	/// <summary>
	/// Доставлен
	/// </summary>
	public static readonly DeliveryStatuses Issued = new DeliveryStatuses(1000, "Доставлен");
	/// <summary>
	/// Отменен
	/// </summary>
	public static readonly DeliveryStatuses Canceled = new DeliveryStatuses(10000, "Отменен");

}