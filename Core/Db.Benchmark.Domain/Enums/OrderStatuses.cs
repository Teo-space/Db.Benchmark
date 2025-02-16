namespace Db.Benchmark.Domain.Enums;

/// <summary>
/// Статус заказа
/// </summary>
public sealed record OrderStatuses(int Value, string Name) : BaseEnum<OrderStatuses>(Value, Name)
{
	public new static IReadOnlyCollection<OrderStatuses> Enums 
		=> [Pending, Assembling, DeliveryPending, Delivering, Delivered, Finished, Canceled];

	/// <summary>
	/// Ожидает
	/// </summary>
	public static readonly OrderStatuses Pending = new OrderStatuses(0, "Ожидает");
	/// <summary>
	/// Сборка
	/// </summary>
	public static readonly OrderStatuses Assembling = new OrderStatuses(1001, "Сборка");
	/// <summary>
	/// Передан в доставку
	/// </summary>
	public static readonly OrderStatuses DeliveryPending = new OrderStatuses(2000, "Передан в доставку");
	/// <summary>
	/// В процессе доставки
	/// </summary>
	public static readonly OrderStatuses Delivering = new OrderStatuses(2001, "В процессе доставки");
	/// <summary>
	/// Доставлен
	/// </summary>
	public static readonly OrderStatuses Delivered = new OrderStatuses(2002, "Доставлен");
	/// <summary>
	/// Завершен
	/// </summary>
	public static readonly OrderStatuses Finished = new OrderStatuses(5000, "Завершен");
	/// <summary>
	/// Отменен
	/// </summary>
	public static readonly OrderStatuses Canceled = new OrderStatuses(10000, "Отменен");

}