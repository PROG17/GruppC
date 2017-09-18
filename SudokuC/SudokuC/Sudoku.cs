using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuC
{
    public class Sudoku
    {
        public char[,] sudokuBoard = new char[9, 9]; //Här deklarerar vi en en tvådimensionell array av typen char och anger storleken på denna.

        int count1 = 0; //Här skapar vi en variabel av typen int som vi använder som en räknare

        public List<char> checkedNumbers = new List<char>(); // Här deklarerar vi en lista av typen char som heter "checkedNumbers".

        public List<char> solutions = new List<char>();
        

        //Metod med samma namn som klassen(Konstruktor) som skapar en tvådimensionell Array("sudokuBoard") av en string som den hämtar in via en inparameter.
        public Sudoku(string board)
        {
            for (int r = 0; r < 9; r++) //med "r" räknar vi antal rows(rader), 9 rader.
            {
                for (int c = 0; c < 9; c++) // med c räknar vi antal columns(kolumner), 9 kolumner per rad).
                {
                    sudokuBoard[r, c] = (board[count1]); //Här lägger till värde på respektive element i vår tvådimensionella char arrray och värdet hämtar vi från vår string som angivits som inparameter.

                    count1++; //Här ökar vi värdet på vår räknare med 1 för att hämta nästa char i vår sträng för varje gång som denna loop körs.
                }

            }
        }

        //Denna metod ska lösa vår Sudoku och den loopar igenom varje element i vår tvådimensionella array av char som heter "sudokuBoard".
        public void Solve()
        {
            bool soluble = true;

            while (Methods.CheckIfSolved(sudokuBoard) && soluble)
            {
                soluble = false;
                for (int r = 0; r < 9; r++)
                {
                    for (int c = 0; c < 9; c++)
                    {
                        if (sudokuBoard[r, c] == '0')
                        {

                            checkedNumbers = Methods.CheckRow(r, sudokuBoard, checkedNumbers);
                            checkedNumbers = Methods.CheckColumn(c, sudokuBoard, checkedNumbers);
                            checkedNumbers = Methods.CheckBlock(r, c, sudokuBoard, checkedNumbers);

                            for (int i = 49; i <= 57; i++)
                            {
                                if (!checkedNumbers.Contains((char)i))
                                {
                                    solutions.Add((char)i);
                                }
                            }
                        }

                        if (solutions.Count == 1)
                        {
                            sudokuBoard[r, c] = solutions[0];
                            soluble = true;
                        }

                        checkedNumbers.Clear();
                        solutions.Clear();
                    }
                }
            }

            if (!soluble)
            {
                Console.WriteLine("Kan ej lösa, ger upp! \nHär är resultatet:");
                Console.WriteLine();
                Methods.PrintBoard(sudokuBoard);
                Console.ReadLine();
            }
        }
    }
}
