using System.Security.Cryptography;
using System.Text;

namespace MyFinancialTracker.api.Utils;

static class EnumerableUtils
{
    public static Boolean Contains<T>(IEnumerable<T> list, T value, string key)
    {
        T? result = list.FirstOrDefault((listItem) => { return GetValue<T>(listItem, key).Equals(GetValue<T>(value, key)); });
        return result != null;
    }

    public static double CalcDifference<T>(T _old, T _new, string key)
    {
        double o = (double)GetValue<T>(_old, key);
        double n = (double)GetValue<T>(_new, key);
        double result = ((n - o) / Math.Abs(o)) * 100;
        return result;
    }

    private static object GetValue<T>(T item, string key)
    {
        var variable = item.GetType().GetProperty(key).GetValue(item, null);
        return variable;
    }
}