using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gauss_Jordan
{
    class Gauss
    {

        public float[,] matrix;
        public float[] solution;   

        public Gauss(float[,] matrix, float[] solution)
        {
            this.matrix = matrix;
            this.solution = solution;
        }

        public void gauss()
        {
            for(int col = 0; col < matrix.GetLength(1)-1; col++)
            {
                checkMatrix(col,col);
                for(int row = col+1; row < matrix.GetLength(0); row++)
                {
                    float factor1 = matrix[col, col];
                    float factor2 = matrix[row, col];

                    for(int colinRow = 0; colinRow < matrix.GetLength(1); colinRow++)
                    {
                        matrix[row, colinRow] = (matrix[row, colinRow] * factor1) - (matrix[col, colinRow] * factor2);
                    }
                    solution[row] = (solution[row] * factor1) - (solution[col] * factor2);
                }
            }
        }

        public void gauss_jordan()
        {
            gauss();
            Console.WriteLine("Gauss:");
            print();

            for(int col = matrix.GetLength(1)-1; col > 0; col--)
            {
                
                float factor2 = matrix[col, col];
                
                for(int colInRow = 0;colInRow < matrix.GetLength(1); colInRow++)
                {
                    matrix[col, colInRow] /= factor2;                    
                }
                solution[col] /= factor2;

                for(int row = col-1; row >= 0; row--)
                {

                    float factor1 = matrix[row, col];

                    for(int colInRow = matrix.GetLength(1)-1; colInRow >= 0; colInRow--)
                    {
                        matrix[row, colInRow] = (matrix[row,colInRow]) - (matrix[col, colInRow]*factor1);
                    }
                    solution[row] = (solution[row]) - (solution[col] * factor1);
                }
            }
        }

        private void checkMatrix(int r,int c)
        {
            if(matrix[r,c] == 0)
            {
                for(int row = 1; row < matrix.GetLength(0); row++)
                {
                    if(matrix[row,c] != 0)
                    {
                        swapRow(r, row);
                        return;
                    }
                }
                //Could not find a row
                Utils.displayAlert("Can't solve this.");
            }
        }

        private void swapRow(int rowInd1,int rowInd2)
        {
            float temp;
            for(int col = 0; col < matrix.GetLength(1); col++)
            {
                temp = matrix[rowInd1, col];
                matrix[rowInd1, col] = matrix[rowInd2, col];
                matrix[rowInd2, col] = temp;

            }
            temp = solution[rowInd1];
            solution[rowInd1] = solution[rowInd2];
            solution[rowInd2] = temp;
        }

        public void print()
        {
            Utils.printGauss(this);
        }

    }

}
