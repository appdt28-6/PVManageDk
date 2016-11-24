using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mediterranius
{
    public partial class cambiaProducto : Form
    {
        db conexion = new db();
        IDataReader reader;
        int idTicket;
        int idProducto;
        public cambiaProducto(int _idProducto,int _idTicket)
        {
            conexion.connect();
            InitializeComponent();
            idTicket = _idTicket;
            idProducto = _idProducto;
            reader = conexion.select("SELECT productos.descripcion,ventasticket.cantidad FROM productos INNER JOIN "+ 
            "ventasticket ON (productos.idProducto = ventasTicket.idProducto) WHERE  "+
            "ventasticket.idTicket = "+_idTicket+" AND  "+
            "ventasticket.idProducto = "+_idProducto+";");
            if (reader.Read()) {
                txtProducto.Text = reader[0].ToString();
                txtCantidad.Text = reader[1].ToString();
            }
            reader.Close();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.insert("DELETE FROM ventasTicket WHERE  idTicket = " + idTicket + " AND  idProducto = " + idProducto + ";");
                this.Close();
            }catch(System.Exception){
                lblError.Visible = true;
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            cambiaCantidad();
        }

        private void txtCantidadCambia(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                cambiaCantidad();
            }

        }

        private void cambiaCantidad() {
            try
            {
                conexion.insert("UPDATE ventasTicket SET cantidad = " + txtCantidad.Text + ",importe=presioUnitario*" + txtCantidad.Text +
                    " WHERE  idTicket = " + idTicket + " AND  idProducto = " + idProducto + ";");
                this.Close();
            }
            catch (System.Exception)
            {
                lblError.Visible = true;
            }
        }
    }
}
