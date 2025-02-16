namespace Db.Benchmark.Domain.Extensions;

public static class MedianExtension
{
	public static double Median(this IEnumerable<int> enumerable)
	{
		int count = enumerable.Count();

		if (count == 0)
		{
			return 0;
		}
		else if (count == 1)
		{
			return enumerable.First();
		}
		else if (count == 3)
		{
			return enumerable.Skip((count / 2) - 1).First();
		}
		else if (count % 2 == 1 && count > 3)
		{
			return enumerable.Skip((count / 2) - 1).Take(3).Average();
		}
		else if (count % 2 == 0)
		{
			var array = enumerable.Skip((count / 2) - 1).Take(2).ToArray();

			return ((array[0] + array[1]) / 2);
		}

		return enumerable.Average();
	}

	public static double Median(this IEnumerable<long> enumerable)
	{
		int count = enumerable.Count();

		if (count == 0)
		{
			return 0;
		}
		else if (count == 1)
		{
			return enumerable.First();
		}
		else if (count == 3)
		{
			return enumerable.Skip((count / 2) - 1).First();
		}
		else if (count % 2 == 1 && count > 3)
		{
			return enumerable.Skip((count / 2) - 1).Take(3).Average();
		}
		else if (count % 2 == 0)
		{
			var array = enumerable.Skip((count / 2) - 1).Take(2).ToArray();

			return ((array[0] + array[1]) / 2);
		}

		return enumerable.Average();
	}

	public static double Median(this IEnumerable<float> enumerable)
	{
		int count = enumerable.Count();

		if (count == 0)
		{
			return 0;
		}
		else if (count == 1)
		{
			return enumerable.First();
		}
		else if (count == 3)
		{
			return enumerable.Skip((count / 2) - 1).First();
		}
		else if (count % 2 == 1 && count > 3)
		{
			return enumerable.Skip((count / 2) - 1).Take(3).Average();
		}
		else if (count % 2 == 0)
		{
			var array = enumerable.Skip((count / 2) - 1).Take(2).ToArray();

			return ((array[0] + array[1]) / 2);
		}

		return enumerable.Average();
	}

	public static double Median(this IEnumerable<double> enumerable)
	{
		int count = enumerable.Count();

		if (count == 0)
		{
			return 0;
		}
		else if (count == 1)
		{
			return enumerable.First();
		}
		else if (count == 3)
		{
			return enumerable.Skip((count / 2) - 1).First();
		}
		else if (count % 2 == 1 && count > 3)
		{
			return enumerable.Skip((count / 2) - 1).Take(3).Average();
		}
		else if (count % 2 == 0)
		{
			var array = enumerable.Skip((count / 2) - 1).Take(2).ToArray();

			return ((array[0] + array[1]) / 2);
		}

		return enumerable.Average();
	}

	public static decimal Median(this IEnumerable<decimal> enumerable)
	{
		int count = enumerable.Count();

		if (count == 0)
		{
			return 0;
		}
		else if (count == 1)
		{
			return enumerable.First();
		}
		else if (count == 3)
		{
			return enumerable.Skip((count / 2) - 1).First();
		}
		else if (count % 2 == 1 && count > 3)
		{
			return enumerable.Skip((count / 2) - 1).Take(3).Average();
		}
		else if (count % 2 == 0)
		{
			var array = enumerable.Skip((count / 2) - 1).Take(2).ToArray();

			return ((array[0] + array[1]) / 2);
		}

		return enumerable.Average();
	}
}
