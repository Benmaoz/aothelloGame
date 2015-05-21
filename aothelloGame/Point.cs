using System;
using System.Collections.Generic;
using System.Text;

namespace B15_Ex02
{
     struct Point
     {
          private int m_X;
          private int m_Y;

          public Point(int i_X, int i_Y)
          {
               m_X = i_X;
               m_Y = i_Y;
          }
          
          public int x
          {
               get
               {
                    return m_X;
               }

               set
               {
                    m_X = value;
               }
          }

          public int y
          {
               get
               {
                    return m_Y;
               }

               set
               {
                    m_Y = value;
               }
          }
     }
}
