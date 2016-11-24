/*
 * Creado por SharpDevelop.
 * Usuario: Hinojosa
 * Fecha: 06/02/2013
 * Hora: 08:42 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace mediterranius
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class Index : Form
	{
		db conexion = new db();
		cmdGrid lee = new cmdGrid();
		IDataReader reader;
		string id_empleado;
		public Index(string idEmpleado)
		{
			conexion.connect();
			id_empleado=idEmpleado;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			reader=conexion.select("Select username from usuarios where idEmpleado = "+idEmpleado);
			if (reader.Read()){
				lblUsuario.Text=reader[0].ToString();
			}
			reader.Close();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void termina(object sender, FormClosingEventArgs e)
		{
		}
		
		
		

        private void btnTienda_Click(object sender, EventArgs e)
        {
            if (this.btnTienda.BackColor == Color.Orange)
            {
                conexion.insert("INSERT INTO tickets SET subtotal=0,mesero=100, mesa=100;");
                reader = conexion.select("SELECT MAX(idTicket) FROM tickets;");
                string idTicket = "";
                if (reader.Read())
                {
                    idTicket = reader[0].ToString();
                }
                reader.Close();
                RegistroVenta objVino = new RegistroVenta(int.Parse(idTicket), int.Parse(id_empleado));
                objVino.Show();
            }else
            {
                RegistroVenta objVino = new RegistroVenta(int.Parse(lblTicketTienda.Text), int.Parse(id_empleado));
                objVino.Show();
            }
            this.Close();
        }

        void MainFormLoad(object sender, EventArgs e)
		{
			

		
			
            //Tienda			
            reader = conexion.select("Select status,mesero,idTicket from tickets where idTicket=( SELECT MAX(idTicket) FROM tickets WHERE mesa=100) ;");
            if (reader.Read())
            {
                if (reader[0].ToString() == "abierto")
                {
                    btnTienda.BackColor = Color.YellowGreen;
                    lblTicketTienda.BackColor = Color.YellowGreen;
                    lblTicketTienda.Text = reader[2].ToString();
                }
            }
            reader.Close();
        }
		
		void BtnSalirClick(object sender, EventArgs e)
		{
			this.Close();
		}

       

	}
}