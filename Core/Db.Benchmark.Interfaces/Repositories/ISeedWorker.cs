namespace Db.Benchmark.Interfaces.Repositories;

public interface ISeedWorker : IDisposable, IAsyncDisposable
{
	public Task DoWorkAsync();
}
