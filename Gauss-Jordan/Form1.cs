using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gauss_Jordan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            matrixView.AutoSize = true;

            matrixView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            matrixView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            matrixView.AllowUserToDeleteRows = false;
            
            numericUpDown1.Value = 2;
            
        }

        float[,] matrix;
        float[] solution;

        private void sizeChanged(object sender, EventArgs e)
        {

            NumericUpDown inp = (NumericUpDown)sender;
            if(inp.Value <= 1)
            {
                inp.Value = 2;
                return;
            }

            this.SuspendLayout();

            matrixView.Columns.Clear();
            matrixView.Rows.Clear();

            matrixView.RowCount = (int)inp.Value;
            matrixView.ColumnCount = (int)inp.Value +2;

            //Leave out the last two columns
            for(int col = 0; col < matrixView.ColumnCount -2; col++)
            {
                matrixView.Columns[col].HeaderText = $"x{col}";
                matrixView.Rows[col].HeaderCell.Value = $"{col}";
            }

            matrixView.Columns[matrixView.ColumnCount - 1].HeaderText = "S";
            matrixView.Columns[matrixView.ColumnCount - 2].HeaderText = "|";

            for(int row = 0; row < matrixView.RowCount; row++)
            {
                matrixView.Rows[row].Cells[matrixView.ColumnCount - 2].Value = "|";
                matrixView.Rows[row].Cells[matrixView.ColumnCount - 2].ReadOnly = true;
            }

            this.ResumeLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void calc_Click(object sender, EventArgs e)
        {
            Gauss gauss;

            matrix = new float[matrixView.RowCount,matrixView.ColumnCount-2];
            solution = new float[matrixView.RowCount];

            for(int row = 0; row < matrixView.RowCount; row++)
            {
                for(int col = 0; col < matrixView.ColumnCount-2; col++)
                {
                    matrix[row, col] = Convert.ToSingle(matrixView.Rows[row].Cells[col].Value);
                }
                solution[row] = Convert.ToSingle(matrixView[matrixView.ColumnCount - 1, row].Value);
            }

            gauss = new Gauss((float[,])matrix.Clone(), (float[])solution.Clone());

            if(comboBox1.SelectedIndex == 0)
            {
                gauss.gauss();
            }else if(comboBox1.SelectedIndex == 1)
            {
                gauss.gauss_jordan();
            }else if(comboBox1.SelectedIndex == -1)
            {
                return;
            }

            for (int row = 0; row < matrixView.RowCount; row++)
            {
                for (int col = 0; col < matrixView.ColumnCount - 2; col++)
                {
                    matrixView[col, row].Value = gauss.matrix[row, col];
                }
                matrixView[matrixView.ColumnCount - 1, row].Value = gauss.solution[row];
            }

        }

        private void reset_Click(object sender, EventArgs e)
        {
            if(matrix != null)
            {
                for(int row = 0;row < matrix.GetLength(0); row++)
                {
                    for(int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrixView[col, row].Value = matrix[row, col];
                    }
                    matrixView[matrixView.ColumnCount - 1, row].Value = solution[row];
                }
            }

        }

        private void validateCell(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
