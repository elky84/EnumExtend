using System;
using System.Collections.Generic;

namespace EnumExtend
{
    public static class TypesUtil
    {
        public static int Code<T>(this T e) where T : struct
        {
            return (int)(object)e;
        }

        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");

            var arr = (T[])Enum.GetValues(src.GetType());
            var j = Array.IndexOf<T>(arr, src) + 1;
            return (arr.Length == j) ? arr[0] : arr[j];
        }

        public static T? FromName<T>(string name) where T : struct
        {
            name = name.ToUpper();
            foreach (var e in (T[])Enum.GetValues(typeof(T)))
            {
                if (e.ToString().ToUpper() == name)
                {
                    return e;
                }
            }

            return null;
        }

        public static IEnumerable<T> ToEnumerable<T>() where T : struct
        {
            return (T[])Enum.GetValues(typeof(T));
        }
    }
}
