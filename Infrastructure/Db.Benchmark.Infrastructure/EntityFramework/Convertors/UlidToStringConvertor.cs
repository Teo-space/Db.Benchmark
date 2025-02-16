using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace Db.Benchmark.Infrastructure.EntityFramework.Convertors;

internal class UlidToStringConvertor : ValueConverter<Ulid, string>
{
	public UlidToStringConvertor() : base(UlidToGuid, GuidToUlid)
	{

	}
	public UlidToStringConvertor(
		Expression<Func<Ulid, string>> convertToProviderExpression,
		Expression<Func<string, Ulid>> convertFromProviderExpression,
		ConverterMappingHints mappingHints = null)
		: base(convertToProviderExpression, convertFromProviderExpression, mappingHints)
	{

	}

	static Expression<Func<Ulid, string>> UlidToGuid = (Ulid ulid) => ulid.ToString();

	static Expression<Func<string, Ulid>> GuidToUlid = (string ulid) => Ulid.Parse(ulid);
}
