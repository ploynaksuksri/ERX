using System;
using System.Linq;
using System.Collections.Generic;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetFriendships();
        }

        private static void GetFriendships()
        {
            var friendships = new List<Tuple<int, int>>();
            friendships.Add(Tuple.Create(1, 2));
            friendships.Add(Tuple.Create(1, 3));
            friendships.Add(Tuple.Create(3, 1));
            friendships.Add(Tuple.Create(1, 2));
            friendships.Add(Tuple.Create(9, 9));

            var result = new Dictionary<int, List<int>>();
            foreach (var record in friendships)
            {
                Process(result, record.Item1, record.Item2);
                Process(result, record.Item2, record.Item1);
            }
            foreach (var record in result)
            {
                var x = "";
                record.Value.ForEach(e => x += e.ToString());
                Console.WriteLine($"{record.Key}, {x}");
            }
        }

        private static void Process(Dictionary<int, List<int>> dict, int left, int right)
        {
            if (dict.TryGetValue(left, out List<int> found))
            {
                if (!found.Exists(e => e == right))
                    found.Add(right);
            }
            else
            {
                dict.Add(left, new List<int>() { right });
            }
        }
    }
}