using Db.Benchmark.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Db.Benchmark.Infrastructure.Repositories;

internal class BaseRepository<T>(T dbContext) : IBaseRepository, IDisposable, IAsyncDisposable
	where T : DbContext
{
	protected T DbContext { get; private set; } = dbContext;

	public void Dispose() => DbContext?.Dispose();
	public ValueTask DisposeAsync() => DbContext.DisposeAsync();

	public bool CreateIfNotExists() => DbContext.Database.EnsureCreated();
	public Task<bool> CreateIfNotExistsAsync() => DbContext.Database.EnsureCreatedAsync();

	public bool Save() => DbContext.SaveChanges() > 0;
	public async Task<bool> SaveAsync() => (await DbContext.SaveChangesAsync()) > 0;
	public bool Save(int entities) => DbContext.SaveChanges() > entities;
	public async Task<bool> SaveAsync(int entities) => (await DbContext.SaveChangesAsync()) > entities;
}
