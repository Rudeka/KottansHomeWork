using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherImplementation
{
    public class CipherOperation
    {
        private int key;
        private string stringToOperate;
        private char[] alphabet = Enumerable.Range('a', 26).Select(x => (char) x).ToArray();

        public CipherOperation(int key, string stringToOperate)
        {
            this.key = key;
            this.stringToOperate = stringToOperate;
        }

        public string RunCipher()
        {
            //try { 
            char[] charWord = stringToOperate.ToCharArray();

            for (var i = 0; i < charWord.Length; i++)
            {
                var currentLetterCode = (int)charWord[i];
                charWord[i] = (char)(currentLetterCode + key);
            }
            
            return new String(charWord);
            //}
        }
    }
}
