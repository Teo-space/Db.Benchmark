using Db.Benchmark.Infrastructure.Repositories;
using Db.Benchmark.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Db.Benchmark.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddTransient<IBenchMarkRepository, BenchMarkRepository>();


		return services;
	}
}
