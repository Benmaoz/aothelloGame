using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02
{
     class Board
     {
          private char[,] m_Board;
          private eBoardSize e_TypeOfBoard;

          public enum eBoardSize
          {
               SmallBoard = 6,
               BigBoard = 8

          }

          public Board(eBoardSize i_TypeOfBoard)
          {
               e_TypeOfBoard = i_TypeOfBoard;
               m_Board = new char[(int)i_TypeOfBoard, (int)i_TypeOfBoard];
          }

          public void Init()
          {
               for (int i = 0; i < (int)e_TypeOfBoard; i++)
               {
                    for (int j = 0; j < (int)e_TypeOfBoard; j++)
                    {
                         m_Board[i, j] = (char)Ui.egameChars.EmptyCell;
                    }
               }

               m_Board[(int)e_TypeOfBoard / 2 - 1, (int)e_TypeOfBoard / 2 - 1] = (char)Ui.egameChars.PlayerBSign;        // init the first values of the board
               m_Board[(int)e_TypeOfBoard / 2, (int)e_TypeOfBoard / 2] = (char)Ui.egameChars.PlayerBSign;
               m_Board[(int)e_TypeOfBoard / 2 - 1, (int)e_TypeOfBoard / 2] = (char)Ui.egameChars.PlayerASign;
               m_Board[(int)e_TypeOfBoard / 2, (int)e_TypeOfBoard / 2 - 1] = (char)Ui.egameChars.PlayerASign;
          } 

          public eBoardSize TypeOfBoard
          {   
               get
               {
                    return e_TypeOfBoard;
               }
          }

          public char GetCellChar(Point i_Point)
          {
               return m_Board[i_Point.x, i_Point.y];
          }

          public char GetCellChar(int i_Y, int i_X)
          {
               return m_Board[i_X, i_Y];
          }

          public char this[int x, int y]
          {
               get
               {
                    return m_Board[x, y];
               }
               set
               {
                    m_Board[x, y] = value;
               }          
          }

          public bool IsEmptyCell(Point i_CellPoint)
          {
               return (m_Board[i_CellPoint.x, i_CellPoint.y] == (char)Ui.egameChars.EmptyCell);
          }

          public bool IsValidPoint(Point i_PointToCheck) //check if the point is on the limits of the board
          {
               bool validPoint = true;

               if (i_PointToCheck.x >= (int)e_TypeOfBoard || i_PointToCheck.y >= (int)e_TypeOfBoard || i_PointToCheck.x < 0 || i_PointToCheck.y < 0)
               {
                    validPoint = false;
               }

               return validPoint;
          }

          public Point[] GetArrayOfPointAround(Point i_Point)   //return arr of all points around include when u have walls
          {
               Point[] tempArrOfPoints = new Point[8];
               int pos = 0;

               for(int i = 0; i < 3; i++)
               {
                    for (int j = 0; j < 3; j++)
                    {
                         Point OptionalPoint = new Point(i_Point.x - 1 + i, i_Point.y - 1 + j);
                         if(IsValidPoint(OptionalPoint) && (!i_Point.Equals(OptionalPoint)))
                         {
                              tempArrOfPoints[pos] = OptionalPoint;
                              pos++;
                         }
                    }
               }

               Point[] resArrOfPoints = new Point[pos];               
               Array.Copy(tempArrOfPoints, resArrOfPoints, pos);
 
               return resArrOfPoints;
          }
         

     }
}
