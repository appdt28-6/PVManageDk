/*
 * Creado por SharpDevelop.
 * Usuario: Angel
 * Fecha: 08/03/2011
 * Hora: 09:56 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */

using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

namespace mediterranius
{
	public class cmdGrid
	{
		private db conexion = new db();
		private IDataReader reader;
		private BindingSource dbind = new BindingSource();

		public BindingSource fillUsuarios()
		{
			conexion.connect();
			reader = conexion.select("Select * from usuarios;");			
			dbind.DataSource = reader;
			reader.Close();
			return(dbind);
		}
		
		public BindingSource fillTickets(string idTicket)
		{
			conexion.connect();
			reader = conexion.select("SELECT ventasticket.idProducto as 'Id', productos.descripcion as 'Descripcion', " +
			                         "ventasticket.cantidad as 'Cantidad', ventasticket.presioUnitario as 'Precio', " +
			                         "ventasticket.importe as 'Importe' FROM     " +
			                         "ventasticket INNER JOIN productos " +
			                         "ON (ventasticket.idProducto = productos.idProducto) where ventasticket.idTicket="+idTicket+";");
			dbind.DataSource = reader;			
			reader.Close();
			return(dbind);
		}
		
		public BindingSource searchUsuario(string Nombre){
			conexion.connect();
			reader = conexion.select("Select nombre as Nombre, " +
                                     "ape_pat as 'Apellido paterno', ape_mat as " +
                                     "'Apellido materno',usuario as 'Nombre de usuario' " +
                                     "from usuarios where (nombre like '%"+Nombre+"%') OR (" +
                                     "usuario like '%"+Nombre+"%')" +
                                     "order by usuario ASC;");
			dbind.DataSource = reader;
			reader.Close();
			return(dbind);
		}
		
		public BindingSource fillSublineas(string idLinea){
			conexion.connect();
			reader = conexion.select("SELECT descripcion as 'Selecciona una sublinea' FROM sublineas s where idLinea="+idLinea+";");
			dbind.DataSource = reader;
			reader.Close();
			return(dbind);
		}
		
		public BindingSource fillProductos(string idSublinea){
			conexion.connect();
			reader = conexion.select("SELECT idProducto as 'Id',clave as 'Clave', descripcion as 'Descripcion', presio as 'Presio' FROM productos where idsublinea = "+idSublinea+";");
			dbind.DataSource = reader;
			reader.Close();
			return(dbind);
		}
	}
}