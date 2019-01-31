using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilard
{
    public static class TrayectoryDrower
    {
        static int _boarWidth;
        static int _boardHaight;
        public static string DrowTrayectory(List<BallLocation> hits, int boarWidth, int boardHaight)
        {
            _boarWidth = boarWidth;
            _boardHaight = boardHaight;
            
            return PrintResult(hits);
        }


        
        private static string PrintResult(List<BallLocation> hits)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            for (int i = 0; i < _boardHaight; i++)
            {
                string numberY = i.ToString();
                sb.AppendFormat("{0}  ", numberY.PadRight(2));
                string xValues = string.Empty;
                for (int j = 0; j < _boarWidth; j++)
                {
                    var celItem = hits.FirstOrDefault(cell => cell.X == j && cell.Y == i);

                    if (celItem != null)
                    {
                        int indexOf = hits.IndexOf(celItem);
                        xValues += " " + indexOf.ToString().PadRight(2);

                    }
                    else
                    {
                        xValues += " ##";

                    }

                }
                sb.Append(xValues);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
