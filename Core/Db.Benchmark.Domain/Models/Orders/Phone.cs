namespace Db.Benchmark.Domain.Models.Orders;

public record struct Phone(long Value)
{
	public static implicit operator long(Phone phone) => phone.Value;
	public static implicit operator string(Phone phone) => string.Format("{0:+#### (###) ###-####}", phone.Value);

	public override string ToString() => string.Format("{0:+#### (###) ###-####}", Value);
}