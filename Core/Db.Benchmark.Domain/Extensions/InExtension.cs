public static class InExtension
{
	public static bool In<T>(this T value, params T[] values) => values.Contains(value);
	public static bool NotIn<T>(this T value, params T[] values) => values.Contains(value) == false;

}
