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
    public partial class RegistroVenta : Form
    {
        cmdGrid lee = new cmdGrid();
        db conexion = new db();
        IDataReader reader;
        int idTicket;
        int idEmpleado;
        //int id_Ticket;

        public RegistroVenta(int _idTicket,int _idEmpleado)
        {
            conexion.connect();
            InitializeComponent();
            idTicket = _idTicket;
            idEmpleado = _idEmpleado;

            calculaTotal();
            if (lblTotal.Text != "0")
                gridVenta.DataSource = lee.fillTickets(idTicket.ToString());
        }



        private void barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                buscaTarget();
            }
        }
        void buscaTarget()
        {
            reader = conexion.select("Select descripcion,precio,idProducto from productos where codigoBarras ='" + barcode.Text + "' ");

            if (reader.Read())
            {
                txtnombre.Text = reader[0].ToString();
                txtprecio.Text = reader[1].ToString();
                txtid.Text = reader[2].ToString();
                //agregaAventa(txtid.Text, txtprecio.Text, "1");
                //gridVenta.DataSource = lee.fillTickets(id_Ticket.ToString());
                //calculaTotal();
            }
            else
            {
                MessageBox.Show("codigo no existe");
            }
            reader.Close();
        }
       
        void agregaAventa(string idProducto, string presio, string cant)
        {
            try
            {
                conexion.insert("INSERT INTO ventasTicket set " +
                            "idProducto=" + idProducto +
                            ",cantidad= " + cant +
                            ",presioUnitario=" + presio +
                            ",importe=" + (double.Parse(cant) * double.Parse(presio)) +
                            ",idTicket=" + idTicket +
                            ";");
            }catch(System.Exception){
                MessageBox.Show("No hay productos listos para agregar");
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {

            if (lblTotal.Text != "0")
                gridVenta.DataSource = lee.fillTickets(idTicket.ToString());

            agregaAventa(txtid.Text, txtprecio.Text, "1");
            gridVenta.DataSource = lee.fillTickets(idTicket.ToString());
            calculaTotal();
        }

       

        private void gridVentaCambiaQuita(object sender, DataGridViewCellEventArgs e)
        {
			if(e.RowIndex ==-1)
					return;
			int idProducto;
            idProducto = int.Parse(gridVenta.Rows[e.RowIndex].Cells[0].Value.ToString());
            cambiaProducto objForm = new cambiaProducto(idProducto, idTicket);
            objForm.ShowDialog();
            RegistroVenta objVino = new RegistroVenta(idTicket, idEmpleado);
            objVino.Show();
            this.Close();
        }

        void calculaTotal()
        {
            reader = conexion.select("SELECT importe FROM ventasticket WHERE idTicket=" + idTicket + ";");
            double contador = 0;
            while (reader.Read())
            {
                contador += double.Parse(reader[0].ToString());
            }
            reader.Close();
            lblTotal.Text = contador.ToString();
        }


        private void btnimprime_Click(object sender, EventArgs e)
        {
            printTicket ticket = new printTicket();

            ticket.AddHeaderLine("C.P Espiritu Santo");
            ticket.AddHeaderLine("Calle");
            ticket.AddHeaderLine("Colonia");
            ticket.AddHeaderLine("RFC: CSI-020226-MV4");
            ticket.AddSubHeaderLine("Ticket: " + idTicket + " ");
            ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

            reader = conexion.select("SELECT ventasticket.cantidad,productos.descripcion, " +
                                     "ventasticket.importe FROM     " +
                                     "ventasticket INNER JOIN productos " +
                                     "ON (ventasticket.idProducto = productos.idProducto) where ventasticket.idTicket=" + idTicket + ";");
            while (reader.Read())
            {
                ticket.AddItem(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
            }
            reader.Close();

            ticket.AddTotal("Total: ", lblTotal.Text);
            ticket.AddFooterLine("GRACIAS POR SU VISITA");
            ticket.AddFooterLine("Dios lo bendice");

            try
            {
                ticket.PrintTicket("local");
                btnCerrar_Click(sender, e);
            }
            catch (System.Exception)
            {
                MessageBox.Show("No se encontro la impresora");
            }
        }

       

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas facturar esta venta?",
               "Alerta!", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, false)
               == DialogResult.Yes)
            {
                conexion.insert("UPDATE tickets SET subtotal = " + lblTotal.Text + ", " +
                                 "status='terminado' WHERE idTicket = " + idTicket + ";");
                Index objmesas = new Index(idEmpleado.ToString());
                objmesas.Show();
                this.Close();
                datosFactura factura = new datosFactura(idTicket);
                factura.Show();
                btnimprime_Click(sender, e);
                //MessageBox.Show("Facturando");
            }
            else
            {
                conexion.insert("UPDATE tickets SET subtotal = " + lblTotal.Text + ", " +
                                 "status='terminado' WHERE idTicket = " + idTicket + ";");
               
                Index objmesas = new Index(idEmpleado.ToString());
                objmesas.Show();
                this.Close();
            }
            
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Index objindex = new Index(idEmpleado.ToString());
            objindex.Show();
            this.Close();
        }
			

       
    }
}