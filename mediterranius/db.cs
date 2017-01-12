using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace mediterranius
{
	public class db
	{
		private string parametros =
          "Server=localhost;" +
          "Database=pvmanager;" +
          "User ID=root;" +
          "Password=@ppdt;" +
          "Pooling=false";

        //private string parametrosw =
        //  "Server=sql10.freemysqlhosting.net;" +
        //  "Database=sql10151059;" +
        //  "User ID=sql10151059;" +
        //  "Password=CZpI3qx4vN;" +
        //  "Pooling=false";

        private string parametrosw =
          "Server=mysql5006.smarterasp.net;" +
          "Database=db_a09b1f_pv;" +
          "User ID=a09b1f_pv;" +
          "Password=@ppDT2016.;" +
          "Pooling=false";



        private IDbConnection dbcon;
		
		IDbCommand dbcmd;
		
		public void connect(){

            //if (AccesoInternet())

            //{
            //    dbcon = new MySqlConnection(parametrosw);
            //    dbcon.Open();
            //    dbcmd = dbcon.CreateCommand();
            //    //Instrucciones en caso de tener acceso a internet
            //}
            //else
            //{
            //    dbcon = new MySqlConnection(parametros);
            //    dbcon.Open();
            //    dbcmd = dbcon.CreateCommand();
            //    //Instrucciones en caso de no tener acceso a internet
            //}

            ///anterior
            dbcon = new MySqlConnection(parametrosw);
            dbcon.Open();
            dbcmd = dbcon.CreateCommand();
        }

		public void insert( string sql ){
			dbcmd.CommandText = sql;		
			IDataReader reader = dbcmd.ExecuteReader();
			reader.Close();
		}
		
		public IDataReader select( string sql ){
			dbcmd.CommandText = sql;
			return dbcmd.ExecuteReader();
		}

        private bool AccesoInternet()
        {
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch (Exception es)
            {
                return false;
            }

        }
    }
}