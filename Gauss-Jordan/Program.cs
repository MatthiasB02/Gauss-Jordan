using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gauss_Jordan
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<float[,], float[]> linsystem = null;
            if (args.Length > 0)
            {
                 linsystem = Utils.gaussFromFile(args[0]);
            }
            Application.Run(new Form1(linsystem));
        }
    }
}