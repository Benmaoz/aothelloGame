using System;
using System.Collections.Generic;
using System.Text;
using Ex02.ConsoleUtils;
using System.Threading;

namespace B15_Ex02
{

     class Ui
     {
          private const int k_SizeOfCell = 4;
          private const int k_sizeOfInput = 2;

          public enum egameChars
          {
               Exit = 'Q',
               SideWall = '|',
               UpDownWall = '=',
               EmptyCell = ' ',
               PlayerASign = 'X',
               PlayerBSign = 'O'
          }

          
          public static string ChooseAginstWhoToPlay()
          {
               string userchoose;

               Console.WriteLine("to play against friend enter his name, else press enter:");
               userchoose = Console.ReadLine();
               if (userchoose.Length == 0)
                    userchoose = null;

               return userchoose;
          }

          public static string GetNameFromUser()
          {              
               Console.WriteLine("please enter your name: ");
               return Console.ReadLine();
          }

          public static Board.eBoardSize GetBoardSizeFromUser()
          {
               Board.eBoardSize boardSize;
               Console.WriteLine(
@"please choose the size of the board: 
1. small board( 6X6 )
2. big board( 8X8 )");
               string userChoose = Console.ReadLine();
               switch (int.Parse(userChoose))
               {
                    case 1:
                         boardSize = Board.eBoardSize.SmallBoard;
                         break;
                    case 2:
                         boardSize = Board.eBoardSize.BigBoard;
                         break;
                    default:
                         boardSize = GetBoardSizeFromUser();
                         break;
               }
               return boardSize;

          }

          public static string GetMoveFromUser(Board.eBoardSize i_BoardSize, Player i_Player)
          {
               string userMove;

               Console.WriteLine("{0} {1} enter your next move:", i_Player.PlayerSign, i_Player.PlayerName);
               userMove =  Console.ReadLine();
               while (userMove[0] != (char)egameChars.Exit && !Ui.IsValidateInput(userMove, i_BoardSize))
               {
                    Console.WriteLine("{0} {1} enter your next move:", i_Player.PlayerSign, i_Player.PlayerName);
                    userMove = Console.ReadLine();
               }

               return userMove;
          }

          public static void PrintBoard(Board i_Board)
          {
               char colIndex = 'A';

               Console.Write(" ");
               for (int i = 0; i < (int)i_Board.TypeOfBoard; i++)
               {
                    Console.Write(string.Format("  {0} ", colIndex));
                    colIndex++;  
               }

               Console.WriteLine("");
               for (int i = 0; i < (int)i_Board.TypeOfBoard; i++)
               {
                    printPartitionLine((int)i_Board.TypeOfBoard);
                    Console.Write(string.Format("{0}", (i+1).ToString()));
                    for (int j = 0; j < (int)i_Board.TypeOfBoard; j++)
                    {
                         Console.Write(string.Format("{0} {1} ", (char)egameChars.SideWall, i_Board.GetCellChar(i, j)));
                    }

                    Console.WriteLine((char)egameChars.SideWall);
               }

               printPartitionLine((int)i_Board.TypeOfBoard);
          }

          private static void printPartitionLine(double i_Length)
          {
               Console.Write(" ");
               string lineToPrint = new string((char)egameChars.UpDownWall, (int)i_Length * k_SizeOfCell + 1);
               Console.WriteLine(lineToPrint);
          }

          public static bool IsValidateInput(string i_Input,Board.eBoardSize i_TypeOfBoard)
          {
               bool valid = true;
               char col = i_Input.ToCharArray()[0];
               char row = i_Input.ToCharArray()[1];
               if (i_Input.Length > k_sizeOfInput)
               {
                    valid = false;
               }

               if (!(row >= '1' && row < '1' + (int)i_TypeOfBoard))
               {
                    valid = false;
               }

               if (!(col >= 'A' && col < 'A' + (int)i_TypeOfBoard))
               {
                    valid = false;
               }

               if (!valid)
               {
                    Console.WriteLine("the input is not valid");
               }

               return valid;
          }

          public static void TellUserBadMove()
          {
               Console.WriteLine("you cant use this cell, choose another one");
          }

          public static void ShowWinnerOfTheGameWindow(Player i_Winner, Player i_Looser)
          {
               Console.WriteLine(
@"
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
++++++++++ winner ++++++++++++++++++++++ looser +++++++++++++
++++++++++{0}                           {1}                 
++++++++++{2}                           {3}                  
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++", i_Winner.PlayerName, i_Looser.PlayerName,
                                                              i_Winner.NumOfTableAppearances,
                                                              i_Looser.NumOfTableAppearances);
               Thread.Sleep(500);
          }

          public static Point ConvertInputToPoint(string i_StrToConvert)
          {
               return new Point(i_StrToConvert.ToCharArray()[0] - 'A', i_StrToConvert.ToCharArray()[1] - '1');
          }
     }
}
