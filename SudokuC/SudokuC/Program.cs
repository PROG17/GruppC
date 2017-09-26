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
            //Här gör vi en instans av klassen "Sudoku" som vi kallar för "game". Denna klass har en konstruktor(metod med samma namn som klaasen) och därför har vi en string som inparameter.
            Sudoku game = new Sudoku("037060000205000800006908000" +
                                     "000600024001503600650009000" +
                                     "000302700009000402000050360");




            //("003020600900305001001806400" +
            // "008102900700000008006708200" +
            // "002609500800203009005010300");

            


            game.Solve();

            game.PrintBoard();

            Console.ReadLine();


        }
    }
}
