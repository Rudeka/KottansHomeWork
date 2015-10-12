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

        public CipherOperation(int key, string stringToOperate)
        {
            this.key = key;
            this.stringToOperate = stringToOperate;
        }

        public string RunCipher()
        {
            Exception nullException;
            Exception outOfRangExeption;

            if (stringToOperate == null)
            {
                throw nullException = new ArgumentNullException();
            }

            else
            {
                char[] charWord = stringToOperate.ToCharArray();
                for (var i = 0; i < charWord.Length; i++)
                {
                    var currentLetterCode = (int) charWord[i];
                    
                    if (currentLetterCode > '~')
                    {
                        throw outOfRangExeption = new ArgumentOutOfRangeException();
                    }

                    if (currentLetterCode == '~' )
                    {
                        
                        if (key > 0)
                        {
                            charWord[i] = (char)(' ' + key);
                        }
                    }

                    else if (currentLetterCode == '!')
                    {
                        if (key < 0)
                        {
                            charWord[i] = (char)(127 + key);
                        }
                    }

                    else
                    {
                        charWord[i] = (char)(currentLetterCode + key);
                    }
                }
                return new String(charWord);
            }
        }
    }
}

