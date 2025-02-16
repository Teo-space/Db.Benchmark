namespace Db.Benchmark.Domain.Models.Orders;

/// <summary>
/// Покупатель заказа
/// </summary>
public sealed record OrderClient
{
	/// <summary>
	/// Номер телефона
	/// </summary>
	public required Phone Phone { get; set; }
	/// <summary>
	/// адрес эл. почты
	/// </summary>
	public string Email { get; set; }
	/// <summary>
	/// Имя
	/// </summary>
	public required string Name { get; set; }
	/// <summary>
	/// Фамилия
	/// </summary>
	public required string SurName { get; set; }
	/// <summary>
	/// Отчество
	/// </summary>
	public required string Patronymic { get; set; }
}