using Db.Benchmark.Domain.Enums;

namespace Db.Benchmark.Domain.Models.Orders;

/// <summary>
/// Платеж заказа
/// </summary>
public sealed record OrderPayment
{
	/// <summary>
	/// Способ оплаты
	/// </summary>
	public required PaymentTypes Type { get; set; }

	/// <summary>
	/// Сумма платежа
	/// </summary>
	public decimal Sum { get; private set; }

	/// <summary>
	/// Дата платежа
	/// </summary>
	public DateTime? Payed { get; private set; }
	/// <summary>
	/// Оплачено
	/// </summary>
	public bool IsPayed { get; private set; } = false;

	public void UpdateSum(Order order)
	{
		Sum = order.Sum;
	}

	public void SetIsPayed()
	{
		Payed = DateTime.Now;
		IsPayed = true;
	}

	/// <summary>
	/// Тип оплаты изменен
	/// </summary>
	public void SetIsPayed(PaymentTypes paymentTypes)
	{
		Type = paymentTypes;
		Payed = DateTime.Now;
		IsPayed = true;
	}

}