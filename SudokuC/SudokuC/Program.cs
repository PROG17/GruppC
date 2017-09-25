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
            Sudoku game = new Sudoku("003020600" +
                                     "900305001" +
                                     "001806400" +
                                     "008102900" +
                                     "700000008" +
                                     "006708200" +
                                     "002609500" +
                                     "800203009" +
                                     "005010300");

            
            game.Solve();

            Console.ReadLine();
        }
    }
}
