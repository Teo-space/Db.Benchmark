namespace Snowflake;

public record struct SnowflakeId(long Value)
{
    public long Value { get; init; } = Value;

    public static SnowflakeId Generate() => new SnowflakeId
    {
        Value = SnowflakeGenerator.Generate(),
    };

    public static implicit operator long(SnowflakeId snowflakeId) => snowflakeId.Value;
    public static implicit operator string(SnowflakeId snowflakeId) => snowflakeId.Value.ToString();

}
