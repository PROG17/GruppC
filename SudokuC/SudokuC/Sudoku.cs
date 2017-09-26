using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SudokuC
{
    public class Sudoku
    {
        public char[,] sudokuBoard; //Här deklarerar vi en en tvådimensionell array av typen char och anger storleken på denna.



        //Metod med samma namn som klassen(Konstruktor) som skapar en tvådimensionell Array("sudokuBoard") av en string som den hämtar in via en inparameter.
        public Sudoku(string board)
        {
            sudokuBoard = new char[9, 9];

            int count1 = 0; //Här skapar vi en variabel av typen int som vi använder som en räknare

            for (int r = 0; r < 9; r++) //med "r" räknar vi antal rows(rader), 9 rader.
            {
                for (int c = 0; c < 9; c++) // med c räknar vi antal columns(kolumner), 9 kolumner per rad).
                {
                    this.sudokuBoard[r, c] = (board[count1]); //Här lägger till värde på respektive element i vår tvådimensionella char arrray och värdet hämtar vi från vår string som angivits som inparameter.

                    count1++; //Här ökar vi värdet på vår räknare med 1 för att hämta nästa char i vår sträng för varje gång som denna loop körs.
                }

            }
        }

        //Konstruktor som tar in en tvådimisionell array av typrn char (används vid recursionen på del 2)
        public Sudoku(char[,] SudokuBoard)
        {
            sudokuBoard = new char[9, 9];

            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    this.sudokuBoard[r, c] = SudokuBoard[r, c];
                }
            }

        }


        
        //Denna metod ska lösa vår Sudoku och den loopar igenom varje element i vår tvådimensionella array av char som heter "sudokuBoard".
        internal bool Solve()
        {
            bool solvable;

            do
            {
                solvable = false;
                for (int r = 0; r < 9; r++)
                {
                    for (int c = 0; c < 9; c++)
                    {
                        if (sudokuBoard[r, c] == '0')   // Om cellen är tom
                        {
                            List<char> possibleValues = FindSolutions(r, c);

                            if (possibleValues.Count == 1)    // Om exakt en siffra är möjlig i cellen 
                            {
                                // Skriv in den enda möjliga siffran i cellen
                                sudokuBoard[r, c] = possibleValues[0];
                                solvable = true;
                            }
                        }
                    }
                }

            } while (solvable); // Fortsätt i loopen om minst en siffra blev inskriven          

            // Kontrollera om sudokut är löst
            if (CheckIfSolved())
            {
                return true;

            }

            // Det gick inte att lösa sudokut med logik, så nu måste vi göra en gissning
            // Gissa en lösning och returnera en bool som anger om gissningen gick bra          

            return GuessSolution();

        }




        private List<char> CheckRow(int r)
        {
            List<char> ValuesInRow = new List<char>();

            for (int c = 0; c < 9; c++)
            {
                if ((sudokuBoard[r, c] != '0') && (!ValuesInRow.Contains(sudokuBoard[r, c])))
                {
                    ValuesInRow.Add(sudokuBoard[r, c]);
                }
            }
            return ValuesInRow;
        }

        private List<char> CheckColumn(int c)
        {
            List<char> ValuesInColumn = new List<char>();

            for (int r = 0; r < 9; r++)
            {
                if ((sudokuBoard[r, c] != '0') && (!ValuesInColumn.Contains(sudokuBoard[r, c])))
                {
                    ValuesInColumn.Add(sudokuBoard[r, c]);
                }
            }
            return ValuesInColumn;
        }

        private List<char> CheckBlock(int R, int C)
        {
            List<char> ValuesInBlock = new List<char>();

            R = (R / 3) * 3;
            C = (C / 3) * 3;

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if ((sudokuBoard[R + r, C + c] != '0') && (!ValuesInBlock.Contains(sudokuBoard[R + r, C + c])))
                    {
                        ValuesInBlock.Add(sudokuBoard[R + r, C + c]);
                    }
                }
            }
            return ValuesInBlock;
        }

        private bool CheckIfSolved()
        {
            foreach (var item in sudokuBoard)
            {
                if (item == '0')
                {
                    return false;
                }
            }
            return true;
        }

        private List<char> FindSolutions(int r, int c)
        {
            List<char> rowValue = CheckRow(r);
            List<char> colValue = CheckColumn(c);
            List<char> boxValue = CheckBlock(r, c);

            


            List<char> solutions = new List<char>();

            for (char i = '1'; i <= '9'; i++)
            {
                if (!rowValue.Contains(i) && (!colValue.Contains(i) && (!boxValue.Contains(i))))
                {
                    solutions.Add(i);
               
                }
            }
         
            return solutions;
        }

        public void PrintBoard()
        {
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    Console.Write(sudokuBoard[r, c] + " ");
                }
                Console.WriteLine();
            }
        }

        private bool GuessSolution()
        {
            int guessRow = 0;
            int guessCol = 0;
            // Leta upp nästa tomma cell, och använd sedan den tomma cellen för hitta en möjlig lösning
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (CheckIfSolved()) //Om det inte finns några nollor kvar på brädan returneras metoden false och anroppas från solve() metoden.
                    {

                        return true;

                    }
                }

            }

            List<char> guessPossibleValues = FindSolutions(guessRow, guessCol);

            while (guessPossibleValues.Count > 0)      // Om listan innehåller mer än än lösning kör koden nedanför.
            {
                // Gissa på nästa möjliga index( värde/lösning) i listan och sätter ner det i nuvarande cell.
                char guess = guessPossibleValues[0];
                sudokuBoard[guessRow, guessCol] = guess;

                //Här skapas en ny sudokubräda med orginal brädan som mall och görs till en bool om brädan är lösbar.             
                Sudoku guessSudoku = new Sudoku(sudokuBoard);
                bool result = guessSudoku.Solve();

                if (result)    //Om sudokut är löst så kopiera brädan till orginalbrädan och metoden returnerar true.
                {
                    sudokuBoard = guessSudoku.sudokuBoard;
                    return true;
                }

                // Sudokut är inte löst
                guessPossibleValues.Remove(guess);     // Ta bort "siffran" guess listan över möjliga gisningar och fortsätter att gissa.
                
            }

            return false;// Det går inte att lösa sudokut med algoritmen.. metoden returnerar false
        }

    }
            
        



}


