namespace Db.Benchmark.Domain.Models.Products;

/// <summary>
/// Тип товара
/// типы товара могут требовать приготовления 'NeedCooking'
/// Такие типы товара формируют 'Cooking' при их заказе
/// </summary>
public sealed record ProductType
{
	/// <summary>
	/// Ид. типа продукта
	/// </summary>
	public required int ProductTypeId { get; init; }

	/// <summary>
	/// наименование
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// Описание
	/// </summary>
	public required string Description { get; set; }

	/// <summary>
	/// Продукты данного типа
	/// </summary>
	public List<Product> Products { get; private set; } = new List<Product>();
}