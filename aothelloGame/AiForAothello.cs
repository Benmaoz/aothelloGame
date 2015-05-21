using System;
using System.Collections.Generic;
using System.Text;
using B15_Ex02;
namespace aothelloGame
{
     class AiForAothello
     {
          
          public static Point AiAlgoritemToChooseWhatPointIsTheBest(Board i_CurrBoard, Point[] i_PossiblePoints, Player i_CurrPlayer, Player i_RivalPlayer)
          {
               Point theBestPoint;
               List<Point> PossiblePointsThatNextToWall = getPointsNextToWall(i_CurrBoard, i_PossiblePoints, i_CurrPlayer);

               if (PossiblePointsThatNextToWall.Count != 0)
               {
                    theBestPoint = chooseThePointThatGiveTheHigherScores(i_CurrBoard, PossiblePointsThatNextToWall, i_CurrPlayer, i_RivalPlayer);
               }

               else
               {
                    theBestPoint = chooseThePointThatGiveTheHigherScores(i_CurrBoard, i_PossiblePoints, i_CurrPlayer, i_RivalPlayer);

               }
          }

          private static List<Point> getPointsNextToWall(Board i_CurrBoard, Point[] i_PossiblePoints, Player i_CurrPlayer)
          {
               List<Point> resPointsNextToWall = new List<Point>();
               Board.eBoardSize boardSize = i_CurrBoard.TypeOfBoard;

               foreach (Point cell in i_PossiblePoints)
               {
                    if (isNextToWall(cell, boardSize))
                         resPointsNextToWall.Add(cell);
               }
               
               return resPointsNextToWall;
          }

          private static bool isNextToWall(Point i_PointToCheck, Board.eBoardSize i_BoardSize)
          {
               bool res;
               if (i_PointToCheck.x == 0 || i_PointToCheck.x == (int)i_BoardSize - 1 || i_PointToCheck.y == 0 || i_PointToCheck.y == (int)i_BoardSize - 1)
               {
                    res = true;
               }

               else
               {
                    res = false;
               }

               return res;
          }
     }
}
