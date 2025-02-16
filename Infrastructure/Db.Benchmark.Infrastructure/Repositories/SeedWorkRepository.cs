using Db.Benchmark.Domain.Models.Deliveries;
using Db.Benchmark.Domain.Models.Orders;
using Db.Benchmark.Domain.Models.Payments;
using Db.Benchmark.Domain.Models.Products;
using Db.Benchmark.Infrastructure.EntityFramework.DbContexts;
using Db.Benchmark.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Db.Benchmark.Infrastructure.Repositories;

internal class SeedWorkRepository(DbContextOptions<DbContext> options) 
	: BaseRepository<BenchMarkDbContext>(new BenchMarkDbContext(options)), ISeedWorkRepository
{

	public async Task<bool> AddAsync(IReadOnlyCollection<DeliveryStatus> deliveryStatuses)
	{
		DbContext.DeliveryStatuses.AddRange(deliveryStatuses);
		return await DbContext.SaveChangesAsync() > 0;
	}

	public async Task<bool> AddAsync(IReadOnlyCollection<DeliveryType> deliveryTypes)
	{
		DbContext.DeliveryTypes.AddRange(deliveryTypes);
		return await DbContext.SaveChangesAsync() > 0;
	}

	public async Task<bool> AddAsync(IReadOnlyCollection<OrderStatus> orderStatuses)
	{
		DbContext.OrderStatuses.AddRange(orderStatuses);
		return await DbContext.SaveChangesAsync() > 0;
	}

	public async Task<bool> AddAsync(IReadOnlyCollection<PaymentType> paymentTypes)
	{
		DbContext.PaymentTypes.AddRange(paymentTypes);
		return await DbContext.SaveChangesAsync() > 0;
	}

	public async Task<bool> AddAsync(IReadOnlyCollection<Maker> makers)
	{
		DbContext.Makers.AddRange(makers);
		return await DbContext.SaveChangesAsync() > 0;
	}

	public async Task<bool> AddAsync(IReadOnlyCollection<ProductType> productTypes)
	{
		DbContext.ProductTypes.AddRange(productTypes);
		return await DbContext.SaveChangesAsync() > 0;
	}

	public async Task<bool> AddAsync(IReadOnlyCollection<Product> products)
	{
		DbContext.Products.AddRange(products);
		return await DbContext.SaveChangesAsync() > 0;
	}

}
