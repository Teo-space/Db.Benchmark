using Db.Benchmark.Domain.Enums;

namespace Db.Benchmark.Domain.Models.Payments;

/// <summary>
/// Способ оплаты
/// </summary>
public class PaymentType
{
	/// <summary>
	/// Id типа оплаты
	/// </summary>
	public required PaymentTypes PaymentTypeId { get; set; }
	/// <summary>
	/// наименование типа оплаты
	/// </summary>
	public required string Name { get; set; }

	public static PaymentType Create(PaymentTypes paymentTypes)
	{
		return new PaymentType
		{
			PaymentTypeId = paymentTypes,
			Name = paymentTypes.Name,
		};
	}
}