namespace Db.Benchmark.Domain.Enums;

/// <summary>
/// Способы оплаты
/// </summary>
public sealed record PaymentTypes(int Value, string Name) : BaseEnum<PaymentTypes>(Value, Name)
{
	public new static IReadOnlyCollection<PaymentTypes> Enums
		=> [CashInOffice, CashInOffice, CardInOffice, CardToCourier];

	/// <summary>
	/// Наличными в офисе
	/// </summary>
	public static readonly PaymentTypes CashInOffice = new PaymentTypes(100, "Наличными в офисе");
	/// <summary>
	/// Наличными курьеру
	/// </summary>
	public static readonly PaymentTypes CashToCourier = new PaymentTypes(200, "Наличными курьеру");
	/// <summary>
	/// Картой в офисе
	/// </summary>
	public static readonly PaymentTypes CardInOffice = new PaymentTypes(300, "Картой в офисе");
	/// <summary>
	/// Картой курьеру
	/// </summary>
	public static readonly PaymentTypes CardToCourier = new PaymentTypes(400, "Картой курьеру");

}