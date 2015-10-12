using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace CipherImplementation
{
    class Program
    {
        static void Main(string[] args)
        {

            CeasarCipher cipher = new CeasarCipher(2);

            Console.Write(cipher.Encrypt("abcd"));
            Console.WriteLine();
            Console.Write(cipher.Decrypt(cipher.Encrypt("abcd")));
            Console.ReadLine();
        }
        
    }
}
