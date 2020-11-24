using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MadLib
{
    public static class Tools
    {        
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items) action(item);
        }

        public static void ForEach<T>(this IEnumerable<T> items, Action<T, int> action)
        {
            int index = 0;
            foreach (var item in items) action(item, index++);
        }

        public static void ForEachIf<T>(this IEnumerable<T> items, Action<T> action, Func<T, bool> condition)
        {
            foreach (var item in items) if (condition(item)) action(item);
        }

        public static void ForEachIf<T>(this IEnumerable<T> items, Action<T, int> action, Func<T, int, bool> condition)
        {
            int index = 0;
            foreach (var item in items) if (condition(item, index)) action(item, index++);
        }

        public static T[] ForEachW<T>(this T[] arr, Func<T> action)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = action();
            }
            return arr;
        }

        public static T[,] ForEachW<T>(this T[,] arr, Func<T> action)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = action();
                }
            }
            return arr;
        }

        public static IEnumerable<T> Concat<T>(this IEnumerable<T> items, T item)
        {
            foreach (var i in items)
            {
                yield return i;
            }
            yield return item;
        }

        public static IEnumerable<T> Concat<T>(this T item, IEnumerable<T> items)
        {
            yield return item;
            foreach (var i in items)
            {
                yield return i;
            }
        }

        public static IEnumerable<T> ConcatOne<T>(this T item1, T item2)
        {
            yield return item1;
            yield return item2;
        }

        public static void Swap(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }
        
        public static void Swap<T>(ref T a, ref T b)
        {
            T help = a;
            a = b;
            b = help;
        }

        public static void SwapIndexInArray<T>(this T[] arr, int i1, int i2)
        {
            T help = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = help;
        }

        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
