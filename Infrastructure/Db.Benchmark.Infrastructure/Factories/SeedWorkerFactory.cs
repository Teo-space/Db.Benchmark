using Db.Benchmark.Infrastructure.Repositories;
using Db.Benchmark.Infrastructure.SeedWork;
using Db.Benchmark.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Db.Benchmark.Infrastructure.Factories;

public static class SeedWorkerFactory
{
	public static ISeedWorker GetSeedWorker(DbContextOptions<DbContext> options)
	{
		ISeedWorkRepository seedWorkRepository = new SeedWorkRepository(options);

		return new SeedWorker(seedWorkRepository);
	}

}
