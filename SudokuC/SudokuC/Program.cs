using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuC
{
    class Program
    {
        static void Main(string[] args)
        {
            Sudoku game = new Sudoku("003020600900305001001806400008102900700000008006708200002609500800203009005010300");

            game.Solve();

            Console.ReadLine();
        }
    }
}
