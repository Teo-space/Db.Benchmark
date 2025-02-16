using Db.Benchmark.Domain.Factories;
using Db.Benchmark.Infrastructure.Factories;
using Db.Benchmark.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

print("Start", ConsoleColor.DarkRed);

DbContextOptions<DbContext> options = new DbContextOptionsBuilder<DbContext>().UseSqlite("Data Source=Test.db").Options;

using IBenchMarkRepository benchMarkRepository = RepositoryFactory.GetBenchMarkRepository(options);
using ISeedWorker seedWorker = SeedWorkerFactory.GetSeedWorker(options);
await seedWorker.DoWorkAsync();
{
	var order = OrderFactory.Create();

	await benchMarkRepository.AddOrderAsync(order);
}