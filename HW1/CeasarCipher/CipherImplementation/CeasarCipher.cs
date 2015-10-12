using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherImplementation
{
    public class CeasarCipher
    {
        private int key;
        private CipherOperation cipherOperation;
        
        public CeasarCipher(int offset)
        {
            key = offset;
        }

        public string Encrypt(string wordToEncrypt)
        {
            cipherOperation = new CipherOperation(key, wordToEncrypt);
            return cipherOperation.RunCipher();
        }

        public string Decrypt(string wordToDecrypt)
        {
            cipherOperation = new CipherOperation(-key, wordToDecrypt);
            return cipherOperation.RunCipher();

        }
    }
}
