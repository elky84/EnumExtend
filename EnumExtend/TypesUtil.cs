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
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }

        public static Nullable<T> FromName<T>(string name) where T : struct
        {
            name = name.ToUpper();
            foreach (T e in (T[])Enum.GetValues(typeof(T)))
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
