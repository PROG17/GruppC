using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuC
{
    class Methods
    {
        //Denna metod loopar igenom alla 9 kolumner i en specefik rad och lägger till siffror(bortsett från 0) som den hittar i en lista som den sedan returnerar.
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

        //Denna metod loopar igenom alla 9 rader i en specefik kolumn och lägger till siffror(bortsett från 0) som den hittar i en lista som den sedan returnerar.
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

        //Denna metod loopar igenom alla element som ligger i en specifik block och lägger till siffror(bortsett från 0) som den hittar i en lista som den sedan returnerar.
        public static List<char> CheckBlock(int R, int C, Char[,] boardArray, List<char> checkList)
        {
            //Här nedan använder vi en formel som låter oss att hitta index till den översta eller vänstra elementet i respektive block.
            R = (R / 3) * 3;
            C = (C / 3) * 3;

            //Här loopar vi igenom respektive block och lägger till siffror(bortsett från 0) som den hittar i en lista som den sedan returnerar.
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if ((boardArray[R + r, C + c] != '0') && (!checkList.Contains(boardArray[r, c]))) //Här kontrollerar vi att det inte är en nolla.
                    {
                        checkList.Add(boardArray[r, c]);
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
                if(item == '0')
                {
                    i++;
                }
            }

            if(i == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
