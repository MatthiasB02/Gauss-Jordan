using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauss_Jordan
{
    class Utils
    {

        public static void printGauss(Gauss gauss)
        {
            for(int row = 0; row < gauss.matrix.GetLength(0); row++)
            {
                for(int col = 0; col < gauss.matrix.GetLength(1); col++)
                {
                    Console.Write($"{gauss.matrix[row, col]}\t");
                }
                Console.Write($"| {gauss.solution[row]} \n");
            }
            Console.WriteLine("---------------------------------------------");
        }
        
    }
}
