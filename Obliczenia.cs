using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace WindowsFormsApplication3
{
    class Obliczenia
    {
        public static double Petla(string Pomiar)
        {
            double loop;
            double.TryParse(Pomiar, out loop);
            return Math.Round(230/loop,2);
        }
        public static double Zwarcie(DataTable Dt)
        {
            int Iznam = (int)Dt.Rows[0][0];
            int Wsp =(int) Dt.Rows[0][1];
            return Iznam * Wsp;
        }
        public static double Przec(DataTable Dt)
        {
            int Iznam = (int)Dt.Rows [0][0];
            return Iznam*1.45;
        }
    }
}
