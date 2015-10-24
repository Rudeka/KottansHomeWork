using System;
using System.CodeDom;
using System.Collections.Generic;

namespace MatrixImplementation
{
    public class CoolMatrix : IEquatable<CoolMatrix>
    {

#region Equality members
        public bool Equals(CoolMatrix other)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (this[i, j] != other[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CoolMatrix)obj);
        }

        public override int GetHashCode()
        {
            return (arr != null ? arr.GetHashCode() : 0);
        }

        public static bool operator ==(CoolMatrix left, CoolMatrix right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CoolMatrix left, CoolMatrix right)
        {
            return !Equals(left, right);
        }
        #endregion

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

        public int[,] ElementsOfMatrix => arr;
        public object Size => matrixSize;
        public bool IsSquare => isSquare;

        public static implicit operator CoolMatrix (int[,] size)
        {
            return new CoolMatrix(size);
        }

        public int this[int index0, int index1]
        {
            get
            {
                if (index0 > arr.GetUpperBound(0)||
                    index1 > arr.GetUpperBound(1))
                {
                    throw new IndexOutOfRangeException();
                }
                return arr[index0, index1];
            }
        }

        public override string ToString()
        {
            string stringMatrix = "";
            bool symbol = false;
            for (int i = 0; i <arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (!symbol)
                    {
                        stringMatrix += $"[{arr[i, j]}, ";
                            symbol = true;
                    }
                    else
                    {
                        stringMatrix += $"{arr[i, j]}]";
                            symbol = false;
                    }
                }

                if (i < arr.GetUpperBound(0))
                { 
                stringMatrix += Environment.NewLine;
                }
            }
            return stringMatrix;
        }

        public static CoolMatrix operator *(CoolMatrix matrix, int multiplier)
        {
            for (int i = 0; i < matrix.arr.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.arr.GetLength(1); j++)
                {
                    matrix.arr[i, j] *= multiplier;
                }
            }

            return matrix;
        }

        public static CoolMatrix operator +(CoolMatrix matrixA,
            CoolMatrix matrixB)
        {
            if (matrixA.matrixSize == matrixB.matrixSize)
            {
                for (int i = 0; i < matrixA.arr.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixA.arr.GetLength(1); j++)
                    {
                        matrixA.arr[i, j] += matrixB.arr[i, j];
                    }
                }
                CoolMatrix matrixC = new CoolMatrix(matrixA.arr);
                return matrixC;
            }

            throw new ArgumentException();
        }

        public CoolMatrix Transpose()
        {
            var matrixRows = matrixSize.Height;
            var matrixColumns = matrixSize.Width;
            int[,] newArr = new int[matrixRows,matrixColumns];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    newArr[j, i] += arr[i, j];
                }
            }
            return new CoolMatrix(newArr);
        }
    }
}

