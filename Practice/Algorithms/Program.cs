using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Sets.PermuteSimple("123");

            Console.WriteLine(Strings.CompareNoLib("abcd", "abcd"));
            Console.WriteLine(Strings.CompareNoLib("abc", "abcd"));
        }
    }
}
