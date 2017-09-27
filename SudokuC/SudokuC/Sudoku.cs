using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SudokuC
{
    class Sudoku
    {

        // En tvådimisionell array som har 9x9(se metoderna nedanför) som kommer vara programmets sudukobräda

        private int[,] sudokuBoard = new int[9, 9];

        // Konstruktor, som skapar en tvådimensionell Array("sudokuBoard") av en string som den hämtar in via en inparameter.
        public Sudoku(string board)
        {

            for (int i = 0; i < sudokuBoard.Length; i++)
            {
                int r = i / 9;
                int c = i % 9;
                if ((r < 9) && (c < 9))
                {
                    sudokuBoard[r, c] = int.Parse(board.Substring(i, 1));
                }
            }
        }

        // Konstruktor, skriv in alla givna siffror i arrayen. Den skapades i syfte för att kunna skapa en kopia av arrayen i RecursiveSolve().
        public Sudoku(int[,] recursiveBoard)
        {


            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    sudokuBoard[r, c] = recursiveBoard[r, c];
                }
            }

        }




        //Denna metod returnerar en lista på de värden som finns i en specifik rad.
        private List<int> CheckValuesInRow(int r)
        {
            List<int> valuesInRow = new List<int>();

            for (int c = 0; c < 9; c++)
            {

                if ((sudokuBoard[r, c] > 0) && (!valuesInRow.Contains(sudokuBoard[r, c])))
                {
                    valuesInRow.Add(sudokuBoard[r, c]);
                }
            }

            return valuesInRow;
        }

        //Denna metod returnerar en lista på de värden som finns i en specifik kolumn.
        private List<int> CheckValuesInCol(int c)
        {
            List<int> valuesInCol = new List<int>();

            for (int r = 0; r < 9; r++)
            {

                if ((sudokuBoard[r, c] > 0) && (!valuesInCol.Contains(sudokuBoard[r, c])))
                {
                    valuesInCol.Add(sudokuBoard[r, c]);
                }
            }

            return valuesInCol;
        }
        //Denna metod returnerar en lista på de värden som finns i en specifikt block.

        private List<int> CheckValuesInBlock(int r, int c)
        {
            List<int> valuesInBlock = new List<int>();

            int R = r / 3;
            int C = c / 3;

            for (r = R * 3; r < (R + 1) * 3; r++)
            {
                for (c = C * 3; c < (C + 1) * 3; c++)
                {

                    if ((sudokuBoard[r, c] > 0) && (!valuesInBlock.Contains(sudokuBoard[r, c])))
                    {
                        valuesInBlock.Add(sudokuBoard[r, c]);
                    }
                }
            }

            return valuesInBlock;
        }

        private List<int> FindPossibleValues(int r, int c)
        {

            // skapar tre listor som ska ska söka efter värden i rad, col och block.
            // Det som underlättade att skapa nya instanser av listorna i metoden var för inte behöva cleara varje gång. 
            // vi hade ett enormt bestyr med listorna och de ville inte funka. 
            // det var en av anledningarna till att vi valde att testa med int istället för char. För något blev riktigt fel vid komp.

            List<int> rowValues = CheckValuesInRow(r);
            List<int> colValues = CheckValuesInCol(c);
            List<int> boxValues = CheckValuesInBlock(r, c);


            List<int> solutions = new List<int>();

            for (int i = 1; i <= 9; i++)
            {
                // Kollar om det finns ett värde mellan 1-9 i rad, col och block. Om det är ett värde mellan 1-9 som inte finns i de övre listorna så kommer det adderas till listan solutions.
                if (!(rowValues.Contains(i) || colValues.Contains(i) || boxValues.Contains(i)))
                {
                    solutions.Add(i);
                }
            }
            // returnera den nya listan med unika värden.
            return solutions;
        }

        public bool Solve()
        {
            bool madeChanges = false;
            int C = 0;
            int R = 0;

            do
            {
                madeChanges = false;
                for (int r = 0; r < 9; r++)
                {
                    for (int c = 0; c < 9; c++)
                    {


                        if (sudokuBoard[r, c] == 0)
                        {
                            List<int> logicalValues = FindPossibleValues(r, c);

                            if (logicalValues.Count == 1)
                            {
                                sudokuBoard[r, c] = logicalValues[0];
                                madeChanges = true;

                            }

                            else
                            {
                                C = c;
                                R = r;
                            }

                        }
                    }
                }
            } while (madeChanges);

            if (!CheckIfSolved())
            {


                List<int> recursiveValues = FindPossibleValues(R, C);

                for (int i = 0; i < recursiveValues.Count; i++)
                {
                    sudokuBoard[R, C] = recursiveValues[i];
                    Sudoku game = new Sudoku(sudokuBoard);
                    var isSoleved = game.Solve();
                    if (!isSoleved) ////
                    {
                        continue;
                    }
                    else
                    {
                        sudokuBoard = game.sudokuBoard;
                        break;
                    }
                }

            }

            return CheckIfSolved();
        }

        //Metoden som tittar på om det finns några "0" kvar på brädet.
        private bool CheckIfSolved()
        {
            foreach (var item in sudokuBoard)
            {
                if (item == 0)
                {
                    return false;
                }
            }
            return true;
        }


        // Denna metod skriver ut Sudokut i konsolen med "Sudukodesign"
        public void PrintBoard()
        {
            Console.WriteLine("   SUDUKO SOLVER 2000     ");
            Console.WriteLine(@"¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");

            for (int r = 0; r < 9; r++)
            {
                if (r % 3 == 0)
                {
                    for (int i = 0; i < 25; i++)
                    {

                        Console.Write("-");
                    }
                    Console.WriteLine();
                }

                for (int c = 0; c < 9; c++)
                {
                    if (c % 3 == 0)
                    {
                        Console.Write("| ");
                    }
                    Console.Write(sudokuBoard[r, c] + " ");
                }

                Console.Write("|");
                Console.WriteLine();
            }

            for (int i = 0; i < 25; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            Thread.Sleep(2000);
            Console.WriteLine("Status: [Solved]");
            Console.WriteLine("Detta är lösningen på sudokut!");

        }



    }
}



