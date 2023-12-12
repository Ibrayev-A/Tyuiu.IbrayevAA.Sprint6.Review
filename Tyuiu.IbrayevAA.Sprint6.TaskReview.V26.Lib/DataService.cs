using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyuiu.IbrayevAA.Sprint6.TaskReview.V26.Lib
{
    public class DataService
    {
        public int GetMatrix(int[,] array, int c, int k, int l)
        {
            int rows = array.GetUpperBound(0) + 1;
            int columns = array.Length / rows;
            int p = 1;

            for (int j = k; j < l; j++)
            {
                if (array[c, j] % 2 != 0)
                {
                        p = array[c, j] * p;
                }
                else
                {
                    if (j > l && p == 1)
                    {
                        p = 0;
                    }
                }
            }
            

            return p;
        }
    }
}
