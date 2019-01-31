using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilard
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Bilard");
            //tworze macież o podanych rozmiarach
            Board board = new Board(10, 10);

            //Puszczenie kuli początkowe współrzędne i kierunek
            var result = board.HitBall(xSatart: 3, yStart: 4, throDirection: Direction.SW);


            var drowingResult = TrayectoryDrower.DrowTrayectory(board.Hits, board.x, board.y);
            Console.WriteLine(drowingResult);

            //zatrzymanie programu
            Console.Read();
        }




    }
}
