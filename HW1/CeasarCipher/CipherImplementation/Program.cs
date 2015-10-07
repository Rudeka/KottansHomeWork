using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = Enumerable.Range('a', 26).Select(x => (char) x).ToArray();
            foreach (var letter in alphabet)
            {
             Console.Write(letter);   
            }
            Console.ReadLine();
        }
    }
}
