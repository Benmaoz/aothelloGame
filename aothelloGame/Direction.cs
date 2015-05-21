using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02
{
     struct Direction
     {
          public enum eDirection
          {
               Up,
               UpRight,
               Right,
               DownRight,
               Down,
               DownLeft,
               Left,
               UpLeft,
               None
          }
          public static eDirection GetDirection(Point i_FromPoint , Point i_ToPoint)
          {
               int DifferenceOfX = i_ToPoint.x - i_FromPoint.x;
               int DifferenceOfY = i_ToPoint.y - i_FromPoint.y;
               eDirection resDirection = eDirection.None;
              
               if( DifferenceOfX == 0 && DifferenceOfY < 0)
               {   
                    resDirection = eDirection.Up;
               }
               
               else if(DifferenceOfX > 0 && DifferenceOfY < 0)
               {
                    resDirection = eDirection.UpRight;
               }

               else if (DifferenceOfX > 0 && DifferenceOfY == 0)
               {
                    resDirection = eDirection.Right;
               }

               else if (DifferenceOfX > 0 && DifferenceOfY > 0)
               {
                    resDirection = eDirection.DownRight;
               }

               else if (DifferenceOfX == 0 && DifferenceOfY > 0)
               {
                    resDirection = eDirection.Down;
               }

               else if (DifferenceOfX < 0 && DifferenceOfY > 0)
               {
                    resDirection = eDirection.DownLeft;
               }

               else if (DifferenceOfX < 0 && DifferenceOfY == 0)
               {
                    resDirection = eDirection.Left;
               }

               else if (DifferenceOfX < 0 && DifferenceOfY < 0)
               {
                    resDirection = eDirection.UpLeft;
               }

               return resDirection;               
          }

          public static Point GetNextPointByDirection(Point i_startPoint, Direction.eDirection i_Direction)
          {
               Point resNextPoint = i_startPoint;
               switch (i_Direction)
               {
                    case eDirection.Up:
                         {
                              resNextPoint.y--;
                              break;
                         }
                    case eDirection.UpRight:
                         {
                              resNextPoint.y--;  //with space??
                              resNextPoint.x++;
                              break;
                         }
                    case eDirection.Right:
                         {
                              resNextPoint.x++;
                              break;
                         }

                    case eDirection.DownRight:
                         {
                              resNextPoint.x++;
                              resNextPoint.y++;
                              break;
                         }

                    case eDirection.Down:
                         {
                              resNextPoint.y++;
                              break;
                         }

                    case eDirection.DownLeft:
                         {
                              resNextPoint.x--;
                              resNextPoint.y++;
                              break;
                         }

                    case eDirection.Left:
                         {
                              resNextPoint.x--;                              
                              break;
                         }

                    case eDirection.UpLeft:
                         {
                              resNextPoint.x--;
                              resNextPoint.y--;
                              break;
                         }
               }

               return resNextPoint;
          }
     }
}
