using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;



namespace WindowsFormsApplication3
{
    class Db
    {
        const string DataBasePath = "Data Source=Pawel.db";

        public Db()
        {

        }
        public DataTable DataRead(string InputSql)
        {
            SQLiteConnection Conn = new SQLiteConnection(DataBasePath);
            DataTable Dt = new DataTable();
            Conn.Open();
            SQLiteCommand Cmd = new SQLiteCommand(InputSql, Conn);
            SQLiteDataReader Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);
            Dr.Close();
            Conn.Close();
            return Dt;
        }
        public DataTable DataReadPar(string Wyl)
        {
            SQLiteConnection Conn = new SQLiteConnection(DataBasePath);
            DataTable Dt = new DataTable();
            Conn.Open();
            SQLiteCommand Cmd = new SQLiteCommand("select Iznam, Wsp From Wylaczniki where Rodzaj = @Wyl", Conn);
            SQLiteParameter param = new SQLiteParameter();
            param.ParameterName = "@Wyl";
            param.Value = Wyl;
            Cmd.Parameters.Add(param);
            SQLiteDataReader Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);
            Dr.Close();
            Conn.Close();
            return Dt;

        }

    }
}
