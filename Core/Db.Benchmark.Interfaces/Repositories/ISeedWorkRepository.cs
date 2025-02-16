using Db.Benchmark.Domain.Models.Deliveries;
using Db.Benchmark.Domain.Models.Orders;
using Db.Benchmark.Domain.Models.Payments;
using Db.Benchmark.Domain.Models.Products;

namespace Db.Benchmark.Interfaces.Repositories;

public interface ISeedWorkRepository : IBaseRepository
{
	Task<bool> AddAsync(IReadOnlyCollection<DeliveryStatus> deliveryStatuses);
	Task<bool> AddAsync(IReadOnlyCollection<DeliveryType> deliveryTypes);
	Task<bool> AddAsync(IReadOnlyCollection<OrderStatus> orderStatuses);
	Task<bool> AddAsync(IReadOnlyCollection<PaymentType> paymentTypes);
	Task<bool> AddAsync(IReadOnlyCollection<Maker> makers);
	Task<bool> AddAsync(IReadOnlyCollection<ProductType> productTypes);
	Task<bool> AddAsync(IReadOnlyCollection<Product> products);

}
