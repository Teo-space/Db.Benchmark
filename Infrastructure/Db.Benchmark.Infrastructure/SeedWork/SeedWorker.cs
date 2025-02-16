using Db.Benchmark.Domain.Factories;
using Db.Benchmark.Interfaces.Repositories;

namespace Db.Benchmark.Infrastructure.SeedWork;

public class SeedWorker(ISeedWorkRepository seedWorkRepository) : ISeedWorker
{
	public void Dispose() => seedWorkRepository?.Dispose();
	public ValueTask DisposeAsync() => seedWorkRepository.DisposeAsync();

	public async Task DoWorkAsync()
	{
		if (seedWorkRepository.CreateIfNotExists())
		{
			print("SeedWork Start", ConsoleColor.DarkRed);

			var deliveryStatuses = SeedWorkFactory.GetDeliveryStatuses();
			await seedWorkRepository.AddAsync(deliveryStatuses);

			var deliveryTypes = SeedWorkFactory.GetDeliveryTypes();
			await seedWorkRepository.AddAsync(deliveryTypes);

			var orderStatuses = SeedWorkFactory.GetOrderStatuses();
			await seedWorkRepository.AddAsync(orderStatuses);

			var paymentTypes = SeedWorkFactory.GetPaymentTypes();
			await seedWorkRepository.AddAsync(paymentTypes);

			var productTypes = SeedWorkFactory.GetProductTypes();
			await seedWorkRepository.AddAsync(productTypes);

			var makers = SeedWorkFactory.GetMakers();
			await seedWorkRepository.AddAsync(makers);

			var makerSamsung = makers.First(x => x.Name == "Samsung");
			var productTypesSmartPhone = productTypes.First(x => x.Name == "Смартфоны");

			var products = SeedWorkFactory.GetProducts(makerSamsung, productTypesSmartPhone);
			await seedWorkRepository.AddAsync(products);

			print("SeedWork End", ConsoleColor.DarkRed);
		}
	}
}
