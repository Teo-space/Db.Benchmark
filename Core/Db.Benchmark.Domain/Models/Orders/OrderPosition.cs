using Db.Benchmark.Domain.Models.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Benchmark.Domain.Models.Orders;

/// <summary>
/// позиция заказа
/// </summary>
public sealed record OrderPosition
{
	/// <summary>
	/// ID позиции заказа
	/// </summary>
	public long OrderPositionId { get; private set; }

	/// <summary>
	/// ID заказа
	/// </summary>
	public long OrderId { get; private set; }
	public Order Order { get; private set; }

	/// <summary>
	/// Ид. продукта
	/// </summary>
	public int ProductId { get; private set; }

	/// <summary>
	/// Ид. типа продукта
	/// </summary>
	public int ProductTypeId { get; private set; }

	/// <summary>
	/// количество
	/// </summary>
	public int Quanity { get; private set; }
	/// <summary>
	/// Цена
	/// </summary>
	public decimal Price { get; private set; }
	/// <summary>
	/// Сумма
	/// </summary>
	[NotMapped]
	public decimal Sum => Quanity * Price;


	public static OrderPosition Create(Order order, Product product, int quantity)
	{
		return new OrderPosition
		{
			//OrderPositionId = Ulid.NewUlid(),
			OrderPositionId = 0L,
			OrderId = order.OrderId,

			ProductId = product.ProductId,
			ProductTypeId = product.ProductTypeId,
			Price = product.Price,
			Quanity = quantity,
		};
	}
}