﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilard
{

    /// <summary>
    /// Odwiedzone pole tablicy
    /// </summary>
    public class BallLocation
    {

        public BallLocation(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
      

    }
}
