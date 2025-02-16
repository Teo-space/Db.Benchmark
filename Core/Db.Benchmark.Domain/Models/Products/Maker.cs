namespace Db.Benchmark.Domain.Models.Products;

public sealed record Maker
{
	/// <summary>
	/// Ид. производителя
	/// </summary>
	public required int MakerId { get; init; }

	/// <summary>
	/// наименование
	/// </summary>
	public required string Name { get; set; }
}
