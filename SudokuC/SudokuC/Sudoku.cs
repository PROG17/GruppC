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

         

        public List<char> checkedNumbers = new List<char>(); // Här deklarerar vi en lista av typen char som heter "checkedNumbers".

        public List<char> solutions = new List<char>();
        

        //Metod med samma namn som klassen(Konstruktor) som skapar en tvådimensionell Array("sudokuBoard") av en string som den hämtar in via en inparameter.
        public Sudoku(string board)
        {
            int count1 = 0; //Här skapar vi en variabel av typen int som vi använder som en räknare

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

            while (CheckIfSolved(sudokuBoard) && soluble)
            {
                soluble = false;
                for (int r = 0; r < 9; r++)
                {
                    for (int c = 0; c < 9; c++)
                    {
                        int row = r;
                        int col = c;

                        if (sudokuBoard[r, c] == '0')
                        {
                            
                            checkedNumbers = CheckRow(r, sudokuBoard, checkedNumbers);
                            checkedNumbers = CheckColumn(c, sudokuBoard, checkedNumbers);
                            checkedNumbers = CheckBlock(r, c, sudokuBoard, checkedNumbers);

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
                        else if (solutions.Count >= 1)
                        {
                            AlternativeBoard(solutions, row, col);

                        }

                        checkedNumbers.Clear();
                        solutions.Clear();
                    }
                }
            }

            if (!soluble)
            {
                //Console.WriteLine("Kan ej lösa, ger upp! \nHär är resultatet:");
                //Console.WriteLine();
                //PrintBoard(sudokuBoard);
                //Console.ReadLine();
            }
        }
        public static List<char> CheckRow(int r, Char[,] boardArray, List<char> checkList)
        {
            for (int c = 0; c < 9; c++)
            {
                if (boardArray[r, c] != '0') //Här kontrollerar vi att det inte är en nolla.
                {
                    checkList.Add(boardArray[r, c]);
                }
            }
            return checkList; //Returnerar lista

        }
        public static List<char> CheckColumn(int c, Char[,] boardArray, List<char> checkList)
        {
            for (int r = 0; r < 9; r++)
            {
                if ((boardArray[r, c] != '0') && (!checkList.Contains(boardArray[r, c]))) //Här kontrollerar vi att det inte är en nolla.
                {
                    checkList.Add(boardArray[r, c]);
                }
            }
            return checkList; //Returnerar lista

        }
        public static List<char> CheckBlock(int R, int C, Char[,] boardArray, List<char> checkList)
        {
            //Här nedan använder vi en formel som låter oss att hitta index till den översta och vänstra elementet i respektive block.
            R = (R / 3) * 3;
            C = (C / 3) * 3;

            //Här loopar vi igenom respektive block och lägger till siffror(bortsett från 0) som den hittar i en lista som den sedan returnerar.
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if ((boardArray[R + r, C + c] != '0') && (!checkList.Contains(boardArray[r, c]))) //Här kontrollerar vi att det inte är en nolla.
                    {
                        checkList.Add(boardArray[R + r, C + c]);
                    }
                }

            }
            return checkList; //Returnerar lista

        }
        public static bool CheckIfSolved(char[,] bordArray)
        {
            int i = 0;

            foreach (var item in bordArray)
            {
                if (item == '0')
                {
                    i++;
                }
            }

            if (i == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void PrintBoard(char[,] bordArray)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Console.Write(bordArray[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private string AlternativeBoard(List<char> tryvaluesList, int row, int col)
        {
            //Sudoku guess = new Sudoku(AlternativeBoardString(AlternativeBoard));
            string guess = "";

           foreach(char item in tryvaluesList)
            {
                sudokuBoard[row, col] = item;

                foreach(char item2 in sudokuBoard)
                {
                    guess += item2.ToString();
                }
            }
            Sudoku game2 = new Sudoku(guess);
            return guess;
            
            
                      /*Skapa metod för att lägga in en ny siffra i sudokun, från tryvaluesList.
                       * denna görs om till en sträng som körs igenom solve-metoden.
                       * om solve-metoden inte hittar någon ny lösning ska programmet gå tillbaka till denna metod
                       * och lägga till en ny gissning från listan
                      */
        }

        private string AlternativeBoardString(List<char> AlternativeBoard)
        {
            string AlternativeString = "";

            foreach (var item in AlternativeBoard)
            {
                AlternativeString += item; //för att lägga ihop varje del i char-Listan till en enda sträng
            }

            return AlternativeString;
        }
    }
}
