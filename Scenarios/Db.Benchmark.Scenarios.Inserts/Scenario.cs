using Db.Benchmark.Domain.Extensions;
using Db.Benchmark.Domain.Factories;
using Db.Benchmark.Domain.Models.Orders;
using Db.Benchmark.Infrastructure.Factories;
using Db.Benchmark.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Db.Benchmark.Scenarios.Inserts;

public class Scenario(DbContextOptions<DbContext> Options)
{
	private readonly Stopwatch stopwatch = new Stopwatch();
	private readonly List<long> ordersBatchResults = new List<long>();
	private readonly List<long> ordersSinglesResults = new List<long>();

	public async Task ExecuteAsync(int repeats, int ordersBatchSize, int ordersSinglesCount)
	{
		if(repeats < 100)		throw new ArgumentOutOfRangeException("Min value for repeats is 100");
		if(repeats % 100 != 0)	throw new ArgumentOutOfRangeException("The number of repeats should be a multiple of 100.");

		for (int runNumber = 0; runNumber < repeats; runNumber++)
		{
			using IBenchMarkRepository benchMarkRepository = RepositoryFactory.GetBenchMarkRepository(Options);
			await SinglesStep(runNumber, ordersSinglesCount, benchMarkRepository);
			await BatchStep(runNumber, ordersBatchSize, benchMarkRepository);
		}

		LogResults();
	}

	private static IReadOnlyCollection<Order> GetOrders(int count)
	{
		List<Order> orders = new List<Order>();

		for (int i = 0; i < count; i++)
		{
			orders.Add(OrderFactory.Create());
		}

		return orders;
	}

	private async Task BatchStep(int runNumber, int ordersBatchSize, IBenchMarkRepository benchMarkRepository)
	{
		var orders = GetOrders(ordersBatchSize);
		stopwatch.Reset(); stopwatch.Start();
		await benchMarkRepository.BulkAddOrdersAsync(orders);
		stopwatch.Stop();
		ordersBatchResults.Add(stopwatch.ElapsedMilliseconds);
		print($@"Run:	{runNumber},	BatchSize:	{ordersBatchSize}.	Elapsed:	{stopwatch.ElapsedMilliseconds}",
			ConsoleColor.DarkRed);
	}

	private async Task SinglesStep(int runNumber, int ordersSinglesCount, IBenchMarkRepository benchMarkRepository)
	{
		var orders = GetOrders(ordersSinglesCount);
		stopwatch.Reset(); stopwatch.Start();

		foreach (var order in orders)
		{
			await benchMarkRepository.AddOrderAsync(order);
		}
		stopwatch.Stop();

		ordersSinglesResults.Add(stopwatch.ElapsedMilliseconds);
		print($@"Run:	{runNumber},	SinglesCount:	{ordersSinglesCount}.	Elapsed:	{stopwatch.ElapsedMilliseconds}",
			ConsoleColor.DarkGreen);
	}

	private void LogResults()
	{
		if (ordersBatchResults.Any())
		{
			int ordersBatchResultsCount = ordersBatchResults.Count;
			int ordersBatchResultsCount94Percentile = (int)(ordersBatchResultsCount * 0.94);
			IReadOnlyCollection<long> ordersBatchResults94Percentile = ordersBatchResults
				.OrderBy(x => x)
				.Skip((ordersBatchResultsCount - ordersBatchResultsCount94Percentile) / 2)
				.Take(ordersBatchResultsCount94Percentile)
				.ToArray();


			print($@"[Db.Benchmark.Scenarios.Inserts] 
OrdersBatchResults 
Total: {ordersBatchResults94Percentile.Select(x => (double)x).Sum()/1000D} sec
Min : {ordersBatchResults94Percentile.Min()} msec
Max : {ordersBatchResults94Percentile.Max()} msec
Average : {ordersBatchResults94Percentile.Average()} msec
Median : {ordersBatchResults94Percentile.Median()} msec
", ConsoleColor.Magenta);
		}

		if (ordersSinglesResults.Any())
		{
			int ordersSinglesResultsCount = ordersSinglesResults.Count;
			int ordersSinglesResultsCount94Percentile = (int)(ordersSinglesResults.Count * 0.94);
			IReadOnlyCollection<long> ordersSinglesResults94Percentile = ordersSinglesResults
				.OrderBy(x => x)
				.Skip((ordersSinglesResultsCount - ordersSinglesResultsCount94Percentile) / 2)
				.Take(ordersSinglesResultsCount94Percentile)
				.ToArray();

			print($@"[Db.Benchmark.Scenarios.Inserts] 
OrdersSinglesResults 
Total: {ordersSinglesResults94Percentile.Select(x => (double)x).Sum() / 1000D} sec
Min : {ordersSinglesResults94Percentile.Min()} msec
Max : {ordersSinglesResults94Percentile.Max()} msec
Average : {ordersSinglesResults94Percentile.Average()} msec
Median : {ordersSinglesResults94Percentile.Median()} msec
", ConsoleColor.Magenta);
		}
	}
}
