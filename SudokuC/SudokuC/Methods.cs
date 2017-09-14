using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuC
{
    class Methods
    {
        public static List<char> CheckRow(int r, Char[,] extraArray, List<char> checklist)
        {
            for (int c = 0; c < 9; c++)
            {
                if (extraArray[r, c] != '0')
                {
                    checklist.Add(extraArray[r, c]);
                }
            }
            return checklist;

        }

        public static List<char> ChecColumn(int c, Char[,] extraArray, List<char> checklist)
        {
            for (int r = 0; r < 9; r++)
            {
                if (extraArray[r, c] != '0')
                {
                    checklist.Add(extraArray[r, c]);
                }
            }
            return checklist;

        }

        public static List<char> CheckBlock(int R, int C, Char[,] extraArray, List<char> checklist)
        {
            R = (R * 3) / 3;
            C = (C * 3) / 3;

            for (int r = R; r < 3; r++)
            {
                for (int c = C; c < 3; c++)
                {
                    if (extraArray[r, c] != '0')
                    {
                        checklist.Add(extraArray[r, c]);
                    }
                }
                
            }
            return checklist;

        }

    }
}
