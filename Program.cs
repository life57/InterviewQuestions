using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "1101";

            Task<int> t = new Task<int>(() => BinaryToDecimal(s1));
            t.Start();

            while (!t.IsCompleted)
            {
                Thread.Sleep(100);
                    Console.Write(".");
            }

            Console.WriteLine();
            Console.WriteLine(t.Result);

            Console.WriteLine();

            RandomNofK(100, 100);
            Console.WriteLine();
        }

        public static int BinaryToDecimal(string s)
        {
            Thread.Sleep(2000);
            return s.ToCharArray().Select((x, i) => (x == '1' ? 1 : 0) * (int)Math.Pow(2, s.Length - i - 1)).Sum();
        }
        private static void RandomNofK(int n, int k)
        {
            Random random = new Random();

            var list = new List<int>();
            var res = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(i);
            }

            for (int i = 0; i < k; i++)
            {
                int x = random.Next(0, list.Count);
                res.Add(list[x]);
                list.RemoveAt(x);
            }

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
}
