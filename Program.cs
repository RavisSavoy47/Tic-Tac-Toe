using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {                                                   /*0  1  2*/
            int[,] array2DInitExample = new int[3, 3] {/*0*/{ 1, 2, 3 }, 
                                                       /*1*/{ 4, 5, 6 }, 
                                                       /*2*/{ 7, 8, 9 } };
            int[,] array2DInitExample2 = { { 1, 2, 3 }, 
                                           { 4, 5, 6 }, 
                                           { 7, 8, 9 }, 
                                           { 10, 11, 12 } };

            //for(int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //        Console.WriteLine(array2DInitExample[i,j]);
            //}

            void SumOfArrays(int[,] arr)
            {
                
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    int sum = 0;
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        sum += arr[i, j];
                    }

                    Console.WriteLine(sum);
                }
            }

            SumOfArrays(array2DInitExample);
        }
    }
}
