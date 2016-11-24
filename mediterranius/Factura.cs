/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 19/10/2016
 * Time: 17:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace mediterranius
{
	/// <summary>
	/// Description of Factura.
	/// </summary>
	public partial class Factura : Form
	{
		 db conexion = new db();
        IDataReader reader;
		public Factura()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			try{
            reader = conexion.select("Select descripcion,precio,idProducto from productos where codigoBarras =102015");
          
            if (reader.Read())
            {
                textBox1.Text = reader[0].ToString();
               
            }
            else
            {
                MessageBox.Show("codigo no existe");
            }
            reader.Close();
           }
		 	catch(Exception a){ MessageBox.Show(a.ToString());}
		}
		
		 void buscaTarget()
        {
		 	try{
            reader = conexion.select("Select descripcion,precio,idProducto from productos where codigoBarras =102015");
          
            if (reader.Read())
            {
                textBox1.Text = reader[0].ToString();
               
            }
            else
            {
                MessageBox.Show("codigo no existe");
            }
            reader.Close();
           }
		 	catch(Exception a){ MessageBox.Show(a.ToString());}
		 }
	}
}
