namespace Db.Benchmark.Domain.Models.Products;

/// <summary>
/// Товар
/// </summary>
public class Product
{
	/// <summary> 
	/// Ид. продукта 
	/// </summary>
	public required int ProductId { get; set; }

	/// <summary> 
	/// Ид. типа продукта 
	/// </summary>
	public required int ProductTypeId { get; set; }
	public ProductType ProductType { get; set; }

	public required int MakerId { get; set; }
	public Maker Maker { get; set; }

	/// <summary> 
	/// наименование 
	/// </summary>
	public required string Name { get; set; }

	/// <summary> 
	/// Описание 
	/// </summary>
	public required string Description { get; set; }

	/// <summary> 
	/// Описание 
	/// </summary>
	public required decimal Price { get; set; }
}