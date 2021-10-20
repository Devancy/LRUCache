using System;
using LRUCache.LUR;

namespace LRUCache
{
    class Program
    {
        private static readonly string displayFormat = "{0,-25} {1,-30} {2,-30}";
        static void Main(string[] args)
        {
            var maxSize = 3;
            var cache = new LRUCache<int, string>(maxSize);
            cache.Put(1, "A");
            cache.Put(2, "B");
            cache.Put(3, "C");

            Console.WriteLine($"Original collection: {cache}");
            Console.WriteLine();
            Console.WriteLine(string.Format(displayFormat, "Action", "Actual result", "Expected result"));
            Console.WriteLine(string.Format(displayFormat, string.Empty.PadRight(25, '-'), string.Empty.PadRight(30, '-'), string.Empty.PadRight(30, '-')));

            Console.WriteLine(string.Format(displayFormat, "GetMaxSize()", cache.GetMaxSize(), maxSize));

            cache.Put(4, "D");
            Console.WriteLine(string.Format(displayFormat, $"Put(4, \"D\")", cache, "[{4-D}, {2-B}, {3-C}]"));

            cache.Get(3);
            Console.WriteLine(string.Format(displayFormat, $"Get(3)", cache, "[{3-C}, {4-D}, {2-B}]"));

            cache.Remove(1);
            Console.WriteLine(string.Format(displayFormat, $"Remove(1)", cache, "[{3-C}, {4-D}, {2-B}]"));

            cache.Remove(4);
            Console.WriteLine(string.Format(displayFormat, $"Remove(4)", cache, "[{3-C}, {2-B}"));

            cache.Put(5, "E");
            Console.WriteLine(string.Format(displayFormat, $"Put(5, \"E\")", cache, "[{5-E}, {3-C}, {2-B}"));

            cache.Put(5, "Five");
            Console.WriteLine(string.Format(displayFormat, $"Put(5, \"Five\")", cache, "[{5-Five}, {3-C}, {2-B}"));

            Console.ReadKey();
        }

        //// 1.0
        //public static IList<int> Reverse(IList<int> list)
        //{
        //    int n = list.Count;
        //    for (int i = 0; i < n / 2; i++)
        //    {
        //        int temp = list[i];
        //        list[i] = list[n - i - 1];
        //        list[n - i - 1] = temp;
        //    }

        //    return list;
        //}

        //// 1.1
        //public static IList<int> Reverse2(IList<int> list)
        //{
        //    var newList = new List<int>();
        //    for (int i = list.Count - 1; i >= 0; i--)
        //    {
        //        newList.Add(list[i]);
        //    }

        //    return newList;
        //}
    }
}
