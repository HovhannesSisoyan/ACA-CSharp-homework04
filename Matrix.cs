using System;

namespace homework4
{
    // Probably it makes sense to have static Matrix class and use it's methods in class level as utility functions
    static class Matrix
    {
        public static void ToString(int rowsCount, int columnsCount, int[] matrix)
        {
            for (int i = 0; i  < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    Console.Write($"{matrix[i * columnsCount + j]} ");
                }
                Console.WriteLine();
            }
        }
        static int[] Add (int[] matrix1, int[] matrix2)
        {
            if (matrix1.Length != matrix2.Length)
            {
                return null;
            }
            else
            {
                int[] res = new int[matrix1.Length];
                for (int i = 0; i < matrix1.Length; i++)
                {
                   res[i] = matrix1[i] + matrix2[i]; 
                }
                return res;
            }
        }
        static int[] ScalarMult(int[] matrix, int scalar)
        {
            int[] res = new int[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                res[i] = scalar * matrix[i];
            }
            return res;
        }
        public static int[] MultMatrix(int row1, int column1, int[] matrix1, int row2, int column2, int[] matrix2)
        {
            if (row1 != column2)
            {
                return null;
            }
            else
            {
                int[] res = new int[row1 * column2];
                for (int i = 0; i < row1; i++)
                {
                    for (int j = 0; j < column2; j++)
                    {
                        res[i * column2 + j] = mul(matrix1[(i * column1)..((i + 1) * column1)], getJthColumn(matrix2, j, row2, column2));
                    }
                }
                return res;
            }
            #region helper functions for matrix multiplication
            int mul(int[] a, int[] b)
            {
                int res = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    res = res + a[i] * b[i];
                }
                return res;
            }
            int[] getJthColumn(int[] a, int j, int row, int column)
            {
                int[] res = new int[row];
                int k = 0;
                for (int i = j; i < a.Length; i += column, k++)
                {
                    res[k] = a[i];
                }
                return res;
            }
            # endregion
        }
    } 
}

