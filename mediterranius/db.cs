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

		private IDbConnection dbcon;
		
		IDbCommand dbcmd;
		
		public void connect(){
			dbcon = new MySqlConnection( parametros );
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
	}
}