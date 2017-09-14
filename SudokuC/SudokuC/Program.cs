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
            Sudoku game = new Sudoku("003020600900305001001806400008102900700000008006708200002609500800203009005010300");
            

            Console.ReadLine();
        }
    }
}
