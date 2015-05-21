using System;
using System.Collections.Generic;
using System.Text;
using Ex02.ConsoleUtils;

namespace B15_Ex02
{
     class program
     {
          static void Main()
          {
               OthelloGame r_TheGame;
               string firstUserName, secondUserName;
               Board.eBoardSize boardSize;

               firstUserName = Ui.GetNameFromUser();
               Screen.Clear();
               secondUserName = Ui.ChooseAginstWhoToPlay();
               Screen.Clear();
               boardSize = Ui.GetBoardSizeFromUser();
               Screen.Clear();
               r_TheGame = new OthelloGame(boardSize, firstUserName, secondUserName);
               r_TheGame.Run();
          }
     }
}
