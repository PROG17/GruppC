using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuC
{
    public class Sudoku
    {
        public char[,] sudokuBoard = new char[9, 9];
        int count1 = 0;
        public List<char> checkedNumbers = new List<char>();


        //Metod(Konstruktor) som skapar två dimitionell Array(sudokuBoard) av en string.
        public Sudoku(string board)
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    sudokuBoard[r, c] = (board[count1]);
                    count1++;

                    Console.WriteLine(sudokuBoard[r, c]);
                }

            }
        }

        

        //public void Solve()
        //{


        //}



    }
}
