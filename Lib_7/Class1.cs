using System;

namespace Lib_7
{
    public class Calculation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matr"></param>
        /// <returns></returns>
        public static int[] Min(int[,] matr)
        {
            int[] mas=new int[matr.GetLength(0)];
            for(int i=0; i<matr.GetLength(0); i++)
            {
                int min = 100;
                for(int j=0;j<matr.GetLength(1); j++)
                {
                    if (matr[i,j] < min)
                    {
                        min= matr[i,j];
                    }
                }
                mas[i] = min;
            }
            return mas;
        }
    }
}
