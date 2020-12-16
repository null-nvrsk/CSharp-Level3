using System;

namespace _1_Matrix
{
    class SqrMatrix
    {
        public int[,] matrix;
        public SqrMatrix(int size)
        {
            matrix = new int[size, size];
        }

        //---------------------------------------------------------------------

        public void Generate()
        {
            Random rand = new Random();

            int size = matrix.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = rand.Next(0, 11);
                }
            }
        }

        //---------------------------------------------------------------------
        public void Print()
        {
            int size = matrix.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + ", ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("---------------------------------");
        }

    }


    
}