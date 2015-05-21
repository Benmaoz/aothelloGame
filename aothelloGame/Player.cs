using System;
using System.Collections.Generic;
using System.Text;
using Ex02;

namespace B15_Ex02
{
     class Player
     {
          private readonly string r_PlayerName = null;
          private readonly char r_PlayerSign;
          private readonly bool r_ComputerUser = true;
          private int m_NumOfTableAppearances = 2;
          private List<Point> m_PossibleMoves = new List<Point>();

          public Player(string i_Name, char i_Sign)    // cost'r 
          {
               r_PlayerName = i_Name;
               r_PlayerSign = i_Sign;
               if(r_PlayerName != null)
                    r_ComputerUser = false;

          }
          
          public string PlayerName
          {
               get
               {
                    return r_PlayerName;
               }
          }

          public int NumOfTableAppearances
          {
               set
               {
                    m_NumOfTableAppearances = value;
               }

               get
               {
                    return m_NumOfTableAppearances;
               }
          }

          public char PlayerSign
          {
               get
               {
                    return r_PlayerSign;
               }
          }

          public bool IsComputerPlayer()
          {
               return r_ComputerUser;
          }

          public List<Point> PossibleMoves
          {
               set
               {
                    m_PossibleMoves = value;
               }

               get
               {
                    return m_PossibleMoves;
               }
          }
          
     }
}
