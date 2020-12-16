using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1_Matrix
{
    class Program
    {
        static public int matrixSize = 100;
        static public SqrMatrix matrix1;
        static public SqrMatrix matrix2;

        static void Main(string[] args)
        {
            
            matrix1 = new SqrMatrix(matrixSize);
            matrix2 = new SqrMatrix(matrixSize);

            matrix1.Generate();
            matrix2.Generate();

            Multiply();

            

            Console.ReadKey();
        }

        //---------------------------------------------------------------------
        public static async void Multiply()
        {
            Task<int>[] tasks = new Task<int>[matrixSize * matrixSize];

            // заполняем результирующую матрицу
            // цикл по каждому ряду первой матрицы
            for (int matrix1_row = 0; matrix1_row < matrixSize; matrix1_row++)
            {
                // цикл по каждому столбцу второй матрицы  
                for (int matrix2_col = 0; matrix2_col < matrixSize; matrix2_col++)
                {
                    // вычисляем скалярное произведение двух векторов  
                    // в отдельных потоках
                    tasks[matrix1_row * matrixSize + matrix2_col] = ScalarProductAsync(matrix1_row, matrix2_col);
                }
            }

            // Ждем всех
            await Task.WhenAll(tasks);
            Console.WriteLine("Готово!");
        }


        //---------------------------------------------------------------------
        static Task<int> ScalarProductAsync(int matrix1_row, int matrix2_col)
        {
            int result = 0;

            return Task.Run(() =>
            {
                for (int matrix1_col = 0; matrix1_col < matrixSize; matrix1_col++)
                {
                    result +=
                      matrix1.matrix[matrix1_row, matrix1_col] *
                      matrix2.matrix[matrix1_col, matrix2_col];
                }

                Console.WriteLine($"[{matrix1_row}][{matrix2_col}] = {result}");
                return result;
            });
        }

    }
}