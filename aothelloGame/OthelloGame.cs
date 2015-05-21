using System;
using System.Collections.Generic;
using System.Text;
using Ex02.ConsoleUtils;


namespace B15_Ex02
{

     class OthelloGame
     {
          private const bool k_ForCheck = true;
          private readonly Player m_PlayerA;
          private readonly Player m_PlayerB;
          private Board m_Board;
          private bool m_gameOnProcess = true;
          private bool m_playerATurn = true;

          public OthelloGame(Board.eBoardSize i_BoardSize, string i_playerAName, string i_PlayerBName)    //cost'r
          {
               m_Board = new Board(i_BoardSize);
               m_Board.Init();
               m_PlayerA = new Player(i_playerAName, (char)Ui.egameChars.PlayerASign);
               m_PlayerB = new Player(i_PlayerBName, (char)Ui.egameChars.PlayerBSign);
               initPlayers();
          }

          public void Run()
          {
               bool validMove = true;
               string userMove;
               Player currPlayer;
               Random random = new Random();
               Point cellMove;

               while (isGameOnProcess())
               {
                    currPlayer = determinesWhosTurn();   //checking whos turn is now to play
                    Screen.Clear();
                    Ui.PrintBoard(m_Board);

                    if (!currPlayer.IsComputerPlayer())    //human turn to play
                    {
                         if (!validMove)
                         {
                              Ui.TellUserBadMove();
                         }

                         userMove = Ui.GetMoveFromUser(m_Board.TypeOfBoard, currPlayer);
                         if (userMove.Equals( Ui.egameChars.Exit.ToString()))
                         {
                              break;
                         }
                         cellMove = Ui.ConvertInputToPoint(userMove);
                    }

                    else                                    //cpu turn to play
                    {
                         cellMove = currPlayer.PossibleMoves[random.Next(currPlayer.PossibleMoves.Count)];
                    }

                    validMove = DoIteration(cellMove);  
               }

               if (!m_gameOnProcess)
               {
                    Screen.Clear();
                    if (m_PlayerA.NumOfTableAppearances > m_PlayerB.NumOfTableAppearances)
                    {
                         Ui.ShowWinnerOfTheGameWindow(m_PlayerA, m_PlayerB);
                    }
                    else
                    {
                         Ui.ShowWinnerOfTheGameWindow(m_PlayerB, m_PlayerA);
                    }
               }   

          }

          public bool IsPlayWithComputer()
          {
               return m_PlayerB.IsComputerPlayer();
          }

          public Board Board
          {
               get
               {
                    return m_Board;
               }
          }

          public Board.eBoardSize BoardType
          {
               get
               {
                    return m_Board.TypeOfBoard;
               }
          }

          public bool DoIteration(Point i_PointToInsert)   //one iteration of game
          {
               bool iterationSuccess = true;

               iterationSuccess = doMove(i_PointToInsert, !k_ForCheck);
               if (iterationSuccess)
               {
                    updatePossibleMoves();    // checking if there is possibles moves for current player
                    m_playerATurn = !m_playerATurn;
                    updatePossibleMoves();   // checking if there is possibles moves for next player
               }

               return iterationSuccess;
          }

          private bool doMove(Point i_MovePoint, bool i_ForCheck)
          {
               bool validMove = false;
               char rivalSign = getRivalSign();
               Point[] allPointAround = m_Board.GetArrayOfPointAround(i_MovePoint);

               if (m_Board.IsEmptyCell(i_MovePoint))
               {
                    foreach (Point cell in allPointAround)
                    {
                         if (m_Board.GetCellChar(cell) == rivalSign)
                         {
                              Direction.eDirection directionToCheck = Direction.GetDirection(i_MovePoint, cell);
                              validMove = checkingAndChangingLine(cell, directionToCheck, rivalSign, i_ForCheck) || validMove;
                         }
                    }
               }

               if (validMove && !i_ForCheck)
               {
                    m_Board[i_MovePoint.x, i_MovePoint.y] = getCurentPlayerSign();
                    getCurrentPlayer().NumOfTableAppearances++;
               }

               return validMove;
          }

          private bool checkingAndChangingLine(Point i_startPoint, Direction.eDirection i_Direction, char i_RivalSign, bool i_ForCheck)
          {
               bool needToChange = false;

               Point nextPointToCheck = Direction.GetNextPointByDirection(i_startPoint, i_Direction);

               if (!m_Board.IsValidPoint(i_startPoint) || m_Board[i_startPoint.x, i_startPoint.y] == (char)Ui.egameChars.EmptyCell)
               {
                    needToChange = false;
               }

               else if (m_Board[i_startPoint.x, i_startPoint.y] == i_RivalSign)
               {
                    needToChange = checkingAndChangingLine(nextPointToCheck, i_Direction, i_RivalSign, i_ForCheck);
                    if (needToChange && !i_ForCheck)
                    {
                         m_Board[i_startPoint.x, i_startPoint.y] = getCurentPlayerSign();
                         getCurrentPlayer().NumOfTableAppearances++;
                         getRivalPlayer().NumOfTableAppearances--;
                    }
               }

               else if (m_Board[i_startPoint.x, i_startPoint.y] == getCurentPlayerSign())
               {
                    needToChange = true;
               }

               return needToChange;
          }

          private char getRivalSign()
          {
               char rivalSign;

               if (m_playerATurn)
               {
                    rivalSign = m_PlayerB.PlayerSign;
               }

               else
               {
                    rivalSign = m_PlayerA.PlayerSign;
               }

               return rivalSign;
          }

          private char getCurentPlayerSign()
          {
               char sighToReturn;

               if (m_playerATurn)
               {
                    sighToReturn = m_PlayerA.PlayerSign;
               }
               else
               {
                    sighToReturn = m_PlayerB.PlayerSign;
               }

               return sighToReturn;
          }

          private Player getCurrentPlayer()
          {
               Player currPlayer;

               if(m_playerATurn)
               {
                    currPlayer = m_PlayerA;
               }
               else
               {
                    currPlayer = m_PlayerB;
               }

               return currPlayer;
          }

          private Player getRivalPlayer()
          {
               Player currPlayer;

               if (m_playerATurn)
               {
                    currPlayer = m_PlayerB;
               }
               else
               {
                    currPlayer = m_PlayerA;
               }

               return currPlayer;
          }

          private Player determinesWhosTurn()
          {
               Player playerToPlay = null;

               if (m_playerATurn && m_PlayerA.PossibleMoves.Count != 0)
               {
                    playerToPlay = m_PlayerA;
               }

               else if (!m_playerATurn && m_PlayerB.PossibleMoves.Count != 0)
               {
                    playerToPlay = m_PlayerB;
               }

               else if (m_playerATurn && m_PlayerA.PossibleMoves.Count == 0)
               {
                    playerToPlay = m_PlayerB;
                    m_playerATurn = !m_playerATurn;
               }

               else if (!m_playerATurn && m_PlayerB.PossibleMoves.Count == 0)
               {
                    playerToPlay = m_PlayerA;
                    m_playerATurn = !m_playerATurn;
               }

               return playerToPlay;
          }

          private bool isGameOnProcess()
          {
               if (!(m_PlayerA.PossibleMoves.Count > 0 || m_PlayerB.PossibleMoves.Count > 0))
               {
                    m_gameOnProcess = !m_gameOnProcess;
               }
               return m_gameOnProcess;
               
          }

          private void updatePossibleMoves()
          {
               Point currPoint = new Point();
               Player currPlayer = getCurrentPlayer();

               currPlayer.PossibleMoves.Clear();
               for (int i = 0; i < (int)m_Board.TypeOfBoard; i++)
               {
                    for (int j = 0; j < (int)m_Board.TypeOfBoard; j++)
                    {
                         currPoint.x = i;
                         currPoint.y = j;
                         if (doMove(currPoint, k_ForCheck))
                         {
                              currPlayer.PossibleMoves.Add(currPoint);
                         }
                    }
               }
          }

          private void initPlayers()
          {
               updatePossibleMoves();
               m_playerATurn = !m_playerATurn;
               updatePossibleMoves();
               m_playerATurn = !m_playerATurn;
          }
     }
}
