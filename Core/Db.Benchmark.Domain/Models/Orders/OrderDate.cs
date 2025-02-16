using System.Data.SqlTypes;

namespace Db.Benchmark.Domain.Models.Orders;

/// <summary>
/// Даты создания, изменения и готовности
/// </summary>
public sealed record OrderDate
{
	/// <summary>
	/// Дата создания
	/// </summary>
	public required DateTime Created { get; set; }
	/// <summary>
	/// Дата изменения
	/// </summary>
	public required DateTime Modified { get; set; }
	/// <summary>
	/// дата завершения
	/// </summary>
	public required DateTime? Finished { get; set; }
}