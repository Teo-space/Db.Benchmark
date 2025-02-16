namespace Db.Benchmark.Interfaces.Repositories;

public interface IBaseRepository : IDisposable, IAsyncDisposable
{
	public bool CreateIfNotExists();
	public Task<bool> CreateIfNotExistsAsync();

	public bool Save();
	public Task<bool> SaveAsync();
	public bool Save(int entities);
	public Task<bool> SaveAsync(int entities);
}
