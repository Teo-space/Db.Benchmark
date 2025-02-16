namespace Db.Benchmark.Domain.Enums;

public abstract record BaseEnum<T>(int Value, string Name) where T : BaseEnum<T>
{
	public static implicit operator int(BaseEnum<T> baseEnum) => baseEnum.Value;
	public static implicit operator string(BaseEnum<T> baseEnum) => baseEnum.Name;

	public static IReadOnlyCollection<T> Enums => [];

	public static IReadOnlyCollection<int> Values => Enums.Select(x => x.Value).ToArray();
	public static IReadOnlyCollection<string> Names => Enums.Select(x => x.Name).ToArray();
	public static T From(int statusId) => Enums.First(x => x.Value == statusId);
}
