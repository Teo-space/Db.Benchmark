using Db.Benchmark.Domain.Models.Orders;
using NUlid;

namespace Db.Benchmark.Interfaces.Repositories;

public interface IBenchMarkRepository : IBaseRepository
{
	public Task<Order> GetOrderAsync(long orderId);
	public Task<IReadOnlyCollection<Order>> GetOrdersAsync(IReadOnlyCollection<long> orderIds);

	public Task<IReadOnlyCollection<OrderPosition>> GetOrderOrderPositionsAsync(long orderId);

	public Task<bool> AddOrderAsync(Order order);

	public Task BulkAddOrdersAsync(IReadOnlyCollection<Order> orders);

	public Task AddOrdersAsync(IReadOnlyCollection<Order> orders);

	public Task<bool> AddOrderPositionsAsync(IReadOnlyCollection<OrderPosition> orderPositions);
	public Task<bool> Update(Order order);
}
