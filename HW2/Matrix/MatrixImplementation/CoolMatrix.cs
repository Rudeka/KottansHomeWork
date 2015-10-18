using System;
using System.CodeDom;

namespace MatrixImplementation
{
    public class CoolMatrix
    {
        private int[,] arr;
        private Size matrixSize;
        private bool isSquare;
        
        public CoolMatrix(int[,] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }
            this.arr = arr;
            matrixSize = new Size(arr.GetLength(0), arr.GetLength(1));
            isSquare = matrixSize.IsSquare;
        }
        
        public object Size => matrixSize;
        public bool IsSquare => isSquare;

        public static implicit operator CoolMatrix (int[,] size)
        {
            return new CoolMatrix(size);
        }

        public override string ToString()
        {

            string stringMatrix = "";
            for (int i = 0; i <arr.Length/2; i++)
                {
                    var s1 = arr.GetValue(i,0);
                    var s2 = arr.GetValue(i, 1);
                    stringMatrix += String.Format("[{0}, " + "{1}]", s1, s2);
                    if (i < arr.GetLength(1)-1)
                    {
                        stringMatrix += Environment.NewLine;
                    }
                }

            return stringMatrix;
        }
    }
}
