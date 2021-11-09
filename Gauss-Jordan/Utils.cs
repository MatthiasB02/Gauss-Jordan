using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Windows.Forms;

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

        public static void displayAlert(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static Tuple<float[,],float[]> gaussFromFile(string path)
        {
            float[,] matrix = null;
            float[] solution = null;

            using (FileStream s = File.OpenRead(path))
            {
                StreamReader sr = new StreamReader(s);
                string line;
                int count = 0;
                int dim = -1;
                while((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();

                    string[] parts;
                    if(count == 0)
                    {
                        dim = Convert.ToInt32(line);
                        matrix = new float[dim, dim];
                        solution = new float[dim];
                    }
                    else
                    {
                        parts = line.Split(new char[] { ' ' });
                        if(parts.Length != dim + 1)
                        {
                            displayAlert("Invalid input file");
                            Environment.Exit(-1);
                        }

                        for(int i = 0; i < dim; i++)
                        {
                            matrix[count - 1, i] = Convert.ToSingle(parts[i]);
                        }
                        solution[count - 1] = Convert.ToSingle(parts[parts.Length - 1]);

                    }
                    count++;
                }
                return new Tuple<float[,], float[]>(matrix, solution);
            }
        }
        
    }
}
