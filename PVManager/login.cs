/*
 * Creado por SharpDevelop.
 * Usuario: Hinojosa
 * Fecha: 06/02/2013
 * Hora: 08:50 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace mediterranius
{
	/// <summary>
	/// Description of login.
	/// </summary>
	public partial class login : Form
	{
		private db conexion= new db();

		public login()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			conexion.connect();

			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnEntrarClick(object sender, EventArgs e)
		{
			acceso();
			
	
		}
		
		void accede(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
				acceso();
		}
		
		void BtnCancelarClick(object sender, EventArgs e)
		{
			this.Close();
		}

		void acceso(){

			IDataReader reader;
			reader = conexion.select("select idUsuario,idEmpleado from usuarios " +
			                         "where username='" + txtUsuario.Text + 
			                         "' AND password=md5('"+txtContra.Text+"');");
			if(reader.Read()){
				txtContra.Text="";
				txtUsuario.Text="";
				lblError.Visible=false;
				Index objForm = new Index(reader[1].ToString());
				objForm.Show();
							
				reader.Close();
			}
			else{
				lblError.Visible=true;
			}
			
			reader.Close();
		}
	}
}
