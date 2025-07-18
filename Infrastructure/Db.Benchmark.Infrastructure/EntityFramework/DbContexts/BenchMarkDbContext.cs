using Db.Benchmark.Domain.Models.Deliveries;
using Db.Benchmark.Domain.Models.Orders;
using Db.Benchmark.Domain.Models.Payments;
using Db.Benchmark.Domain.Models.Products;
using Db.Benchmark.Infrastructure.EntityFramework.Convertors;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Db.Benchmark.Infrastructure.EntityFramework.DbContexts;

internal class BenchMarkDbContext(DbContextOptions<DbContext> options) : DbContext(options)
{
	public DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
	public DbSet<DeliveryType> DeliveryTypes { get; set; }

	public DbSet<Order> Orders { get; set; }
	public DbSet<OrderPosition> OrderPositions { get; set; }
	public DbSet<OrderStatus> OrderStatuses { get; set; }

	public DbSet<PaymentType> PaymentTypes { get; set; }

	public DbSet<Maker> Makers { get; set; }
	public DbSet<ProductType> ProductTypes { get; set; }
	public DbSet<Product> Products { get; set; }

#if DEBUG
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.EnableDetailedErrors();
		optionsBuilder.EnableSensitiveDataLogging();

		optionsBuilder.LogTo((string text) => print(text, ConsoleColor.DarkGray),
			minimumLevel: Microsoft.Extensions.Logging.LogLevel.Information);
	}
#endif

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		//configurationBuilder.Properties<Ulid>().HaveConversion<UlidToGuidConvertor>();
		configurationBuilder.Properties<Ulid>().HaveConversion<UlidToStringConvertor>();
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}