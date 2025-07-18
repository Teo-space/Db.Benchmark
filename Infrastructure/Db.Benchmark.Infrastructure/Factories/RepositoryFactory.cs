using Db.Benchmark.Infrastructure.Repositories;
using Db.Benchmark.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Db.Benchmark.Infrastructure.Factories;

public static class RepositoryFactory
{
	public static IBenchMarkRepository GetBenchMarkRepository(DbContextOptions<DbContext> options)
	{
		return new BenchMarkRepository(options);
	}
}
