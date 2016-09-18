using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MaxPathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Program().Result());
            Console.ReadLine();
        }
        public int Result()
        {
            int[] res = new int []{0};
            int[] list;
            using (StreamReader sr  = new StreamReader("path.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    list = Array.ConvertAll(line.Split(' '), s => int.Parse(s));

                    for (int i = 1; i < list.Length-1; i++) list[i] +=  Math.Max(res[i - 1],res[i]);

                    list[0] += res[0];
                    list[list.Length - 1] += res[res.Length-1];

                    res = list;
                }
            }
            return res.Max();
        }
    }
}
