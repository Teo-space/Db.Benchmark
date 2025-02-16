using Db.Benchmark.Domain.Models.Orders;
using Db.Benchmark.Infrastructure.EntityFramework.DbContexts;
using Db.Benchmark.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Z.BulkOperations;

namespace Db.Benchmark.Infrastructure.Repositories;

internal class BenchMarkRepository(DbContextOptions<DbContext> options) 
	: BaseRepository<BenchMarkDbContext>(new BenchMarkDbContext(options)), IBenchMarkRepository
{
	public Task<Order> GetOrderAsync(long orderId)
	{
		return DbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == orderId);
	}

	public async Task<IReadOnlyCollection<Order>> GetOrdersAsync(IReadOnlyCollection<long> orderIds)
	{
		return await DbContext.Orders.Where(x => orderIds.Contains(x.OrderId)).ToArrayAsync();
	}

	public async Task<IReadOnlyCollection<OrderPosition>> GetOrderOrderPositionsAsync(long orderId)
	{
		return await DbContext.OrderPositions.Where(x => x.OrderId == orderId).ToArrayAsync();
	}

	public async Task<bool> AddOrderAsync(Order order)
	{
		DbContext.Orders.Add(order);
		return await DbContext.SaveChangesAsync() > 0;
	}

	public async Task BulkAddOrdersAsync(IReadOnlyCollection<Order> orders)
	{
		await DbContext.BulkInsertAsync(orders, new BulkOperationOptions<Order>
		{
			IncludeGraph = true
		});
	}

	public async Task AddOrdersAsync(IReadOnlyCollection<Order> orders)
	{
		DbContext.Orders.AddRange(orders);
		await DbContext.BulkSaveChangesAsync();

		//DbContext.Orders.AddRange(orders);
		//await DbContext.SaveChangesAsync();
	}

	public async Task<bool> AddOrderPositionsAsync(IReadOnlyCollection<OrderPosition> orderPositions)
	{
		DbContext.OrderPositions.AddRange(orderPositions);
		return await DbContext.SaveChangesAsync() > 0;
	}

	public async Task<bool> Update(Order order)
	{
		DbContext.Orders.Update(order);

		return await DbContext.SaveChangesAsync() > 0;
	}
}
