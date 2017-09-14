using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuC
{
    public static class Methods
    {
        public static void CheckRow(int r, Char[,] extraArray)
        {
            for (int c = 0; c < 9; c++)
            {
                if (extraArray[r,c] != '0')
                {
                    sudo.Add(extraArray[r, c]);
                }
            }

        }

    }
}
