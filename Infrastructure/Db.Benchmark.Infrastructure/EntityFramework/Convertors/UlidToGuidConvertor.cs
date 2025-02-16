using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace Db.Benchmark.Infrastructure.EntityFramework.Convertors;

internal class UlidToGuidConvertor : ValueConverter<Ulid, Guid>
{
	public UlidToGuidConvertor() : base(UlidToGuid, GuidToUlid)
	{

	}
	public UlidToGuidConvertor(
		Expression<Func<Ulid, Guid>> convertToProviderExpression,
		Expression<Func<Guid, Ulid>> convertFromProviderExpression,
		ConverterMappingHints mappingHints = null)
		: base(convertToProviderExpression, convertFromProviderExpression, mappingHints)
	{

	}

	static Expression<Func<Ulid, Guid>> UlidToGuid = x => x.ToGuid();

	static Expression<Func<Guid, Ulid>> GuidToUlid = x => new Ulid(x);
}
