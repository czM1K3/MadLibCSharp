using System;
using System.Collections.Generic;

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
    }
}
