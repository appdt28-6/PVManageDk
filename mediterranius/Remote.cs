using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediterranius
{
    class Remote
    {
        db conexion = new db();
        IDataReader reader;

        private string parametrosw =
          "Server=mysql5006.smarterasp.net;" +
          "Database=db_a09b1f_pv;" +
          "User ID=a09b1f_pv;" +
          "Password=@ppDT2016.;" +
          "Pooling=false";

        private IDbConnection dbcon2;

        IDbCommand dbcmd2;
        public void connect()
        {
            dbcon2 = new MySqlConnection(parametrosw);
            dbcon2.Open();
            dbcmd2 = dbcon.CreateCommand();
        }

        public void SubeVentas()
        {
            Remote remote = new Remote();
           
            INSERT newtable (user, age, os) SELECT table1.user, table1.age, table2.os FROM table1, table2 WHERE table1.user = table2.user;
            dbcmd2.CommandText = sql;
            IDataReader reader = dbcmd2.ExecuteReader();
            reader.Close();

        }


        }
}
