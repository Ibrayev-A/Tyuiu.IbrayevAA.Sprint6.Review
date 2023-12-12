using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.IbrayevAA.Sprint6.TaskReview.V26.Lib;

namespace Tyuiu.IbrayevAA.Sprint6.TaskReview.V26
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        DataService ds = new DataService();
        Random rnd = new Random();

        private void buttonResult_IAA_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBoxVarN1_IAA.Text) < Convert.ToInt32(textBoxVarN2_IAA.Text) && Convert.ToInt32(textBoxVarK_IAA.Text) < Convert.ToInt32(textBoxVarL_IAA.Text) && Convert.ToInt32(textBoxVarC_IAA.Text) < Convert.ToInt32(textBoxVarN_IAA.Text))
            {
                int N = Convert.ToInt32(textBoxVarN_IAA.Text);
                int M = Convert.ToInt32(textBoxVarM_IAA.Text);
                int K = Convert.ToInt32(textBoxVarK_IAA.Text);
                int L = Convert.ToInt32(textBoxVarL_IAA.Text);
                int R = Convert.ToInt32(textBoxVarC_IAA.Text);
                int n1 = Convert.ToInt32(textBoxVarN1_IAA.Text);
                int n2 = Convert.ToInt32(textBoxVarN2_IAA.Text);
                int[,] mrtx = new int [N, M];
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        mrtx[i, j] = rnd.Next(n1, n2);
                    }
                }

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (mrtx[i, j] < 0)
                        {
                            mrtx[i, j] = mrtx[i, j] * -1;
                        }
                    }
                }

                for (int j = 0; j < M; j++)
                {
                    for (int i = 0; i < N; i = i+2)
                    {
                        if (j % 2 == 0)
                        {
                            mrtx[i, j] = mrtx[i, j] * -1;
                        }
                        else
                        for (int p = 1; p < N; p = p + 2)
                        {
                             {
                                    mrtx[p, j] = mrtx[p, j] * -1;
                             }
                        }
                        
                    }
                }

                textBoxResult_IAA.Text = Convert.ToString(ds.GetMatrix(mrtx, R, K, L));

                dataGridViewResult_IAA.RowCount = N;
                dataGridViewResult_IAA.ColumnCount = M;

                for (int i = 0; i < N; i++)
                {
                    dataGridViewResult_IAA.Columns[i].Width = 25;
                }

                for (int r = 0; r < N; r++)
                {
                    for (int c = 0; c < M; c++)
                    {
                        dataGridViewResult_IAA.Rows[r].Cells[c].Value = mrtx[r, c];
                    }
                }
            }
            else
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
