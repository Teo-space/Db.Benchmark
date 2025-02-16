using Db.Benchmark.Infrastructure.Factories;
using Db.Benchmark.Interfaces;
using Db.Benchmark.Interfaces.Repositories;
using Db.Benchmark.Scenarios.Inserts;
using Microsoft.EntityFrameworkCore;

print("Start", ConsoleColor.DarkRed);

/// <summary>
/// Сценарий для первоначального заполнения бд большим количеством данных.
/// замеряем время массовых вставок
/// замеряем время вставок по одной строке
/// замеряем деградацию производительности вставок при увеличении объема данных
/// </summary>

int repeats = 1000;//Количество повторений вставки
int ordersBatchSize = 100000;//Количество объектов для Batch вставки
int ordersSinglesCount = 100;//Количество объектов для поштучной вставки

//var options = new DbContextOptionsBuilder<DbContext>().UseSqlite("DataSource=file::memory:?cache=shared").Options;
//var options = new DbContextOptionsBuilder<DbContext>().UseSqlite("Data Source=Test.db").Options;
DbContextOptions<DbContext> options = new DbContextOptionsBuilder<DbContext>()
	.UseSqlServer($@"Server=192.168.0.105;
Database={DataBaseNames.Benchmark};
User Id=UserDB;
password=3P33c7u7S6;
TrustServerCertificate=True;
Trusted_Connection=True;
Integrated Security=False;
MultipleActiveResultSets=True;").Options;

using (ISeedWorker seedWorker = SeedWorkerFactory.GetSeedWorker(options))
{
	await seedWorker.DoWorkAsync();
}

Scenario scenario = new Scenario(options);
await scenario.ExecuteAsync(repeats, ordersBatchSize, ordersSinglesCount);
