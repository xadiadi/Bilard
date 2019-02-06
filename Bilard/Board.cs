using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilard
{
    class Board
    {
        /// <summary>
        /// Rozmiar tablicy x
        /// </summary>
        public int x;
        /// <summary>
        /// Rozmiar tablicy y
        /// </summary>
        public int y;

        /// <summary>
        /// Historia przejść przez pola tablicy po uderzeniu w kule
        /// </summary>
        public List<BallLocation> Hits { get; private set; }

        /// <summary>
        /// Tablca numerów pól w szchownicy,
        /// każde pole ma numer
        /// </summary>
        public int[,] PlayBoardCells { get; private set; }
        /// <summary>
        /// Konstrurktor tworzy tabele o podanych rozmiarach
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Board(int x = 10, int y = 10)
        {
            this.x = x;
            this.y = y;
            Hits = new List<BallLocation>();
        }
        
        /// <summary>
        /// Rzut kulą po tablicy
        /// </summary>
        /// <param name="k">K- X direction</param>
        /// <param name="l">L- Y direction </param>
        /// <param name="throDirection">kierunek w którym piłka ma sie potoczyć</param>
        /// <returns></returns>
        internal List<BallLocation> HitBall(int xSatart, int yStart, Direction throDirection)
        {
            //resetuj wyniki
            Hits = new List<BallLocation>();
            if (xSatart > x)
            {
                throw new ArgumentException("Za duża początowa wartośc X");
            }
            if (yStart > y)
            {
                throw new ArgumentException("Za duża początkowa wartośc Y");
            }

            BallLocation startCell = new BallLocation(yStart, yStart);
            Hits.Add(startCell);

            //Obliczam początkowy kierunek dla piłki w prawo czy w lewo i dodołu i do góry
            bool yDown = IsDownDirection(throDirection);
            bool xDown = IsRigthSideDirection(throDirection);
           

            bool isFinish = false;
            while (!isFinish)
            {
                //jeżeli kończy się plansza dla y to odwróć kierunek
                if (yDown)
                {
                    if (yStart - 1 < 0)
                    {
                        //zawracamy piłeczkę
                        yDown = !yDown;
                    }
                }
                else
                {
                    //y
                    if (yStart + 1 > y - 1)
                    {
                        yDown = !yDown;
                    }
                }
                //jeżeli kończy się plansza dla X to odwróć kierunek
                if (xDown)
                {
                    if (xSatart - 1 < 0)
                    {
                        //zawracamy piłeczkę
                        xDown = !xDown;
                    }
                }
                else
                {
                    //y
                    if (xSatart + 1 > x - 1)
                    {
                        xDown = !xDown;
                    }
                }

                //ruszaj piłeczką o jedno pole
                if (yDown) { yStart--; } else { yStart++; }
                if (xDown) { xSatart--; } else { xSatart++; }

                //tworzę pole na którym jest teraz piłka
                BallLocation cell = new BallLocation(xSatart, yStart);


                ///Sprawdzam warunek wyjścia
                ///jeśli Hits zawiera już współrzędne ruchu (cell) to wychodzimy z pętli while
                ///bo trafiliśmy na pole w którym już była piłka
                if (IsBallCrossingTrajectory(cell))
                {

                    //get out of here
                    isFinish = true;
                    continue;
                }
                //Zapisz trajektorie na liście odwiedzonych pól
                Hits.Add(cell);

            }


            return Hits;
        }

        private static bool IsRigthSideDirection(Direction dir)
        {
            return dir == Direction.NW || dir == Direction.SW ? true : false;
        }

        private static bool IsDownDirection(Direction dir)
        {
            //ustawlam początkowy kierunek rzutu
            return dir == Direction.NW || dir == Direction.NE ? true : false;
        }

        bool IsBallCrossingTrajectory(BallLocation cell)
        {
         
            if (Hits.FirstOrDefault(aa => aa.X == cell.X && aa.Y == cell.Y) != null)
            {
                return true;
            }
            return false;
        }
        
    }
}
