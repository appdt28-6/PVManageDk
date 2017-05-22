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
            reader = conexion.select("Select nombre,precio,idProducto from productos where codigoBarras ='" + barcode.Text + "' ");

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
                conexion.insert("INSERT INTO ventasticket set " +
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
            Ticket ticket = new Ticket();

            //ticket.HeaderImage = "C:\imagen.jpg"; //esta propiedad no es obligatoria

            ticket.AddHeaderLine("Buffet Espiritu S.");
            //ticket.AddHeaderLine("EXPEDIDO EN:");
            ticket.AddHeaderLine("BLVD. SANTA CATARINA");
            ticket.AddHeaderLine("MONSERRAT #110, FRACC. LA HERRADURA");
            //ticket.AddHeaderLine("RFC: CSI-020226-MV4");

            //El metodo AddSubHeaderLine es lo mismo al de AddHeaderLine con la diferencia
            //de que al final de cada linea agrega una linea punteada "=========="
            ticket.AddHeaderLine("Ticket # "+ idTicket +" ");
            ticket.AddHeaderLine("\n");
            //ticket.AddHeaderLine("Le atendió: Prueba");
            ticket.AddHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

            //El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
            //del producto y el tercero es el precio
            //ticket.AddItem("1", "Articulo 1", "15.00");
            //ticket.AddItem("2", "Articulo 2", "25.00");
            ticket.AddHeaderLine("\n");
            ticket.AddHeaderLine("----------------------");
            ticket.AddHeaderLine("\n");
            ticket.AddHeaderLine("Cant.     Desc.     Importe");
            ticket.AddHeaderLine("\n");
            //ticket.AddHeaderLine("Articulo 2");

            reader = conexion.select("SELECT ventasticket.cantidad,productos.descripcion, " +
                                                 "ventasticket.importe FROM     " +
                                                 "ventasticket INNER JOIN productos " +
                                                 "ON (ventasticket.idProducto = productos.idProducto) where ventasticket.idTicket=" + idTicket + ";");
            while (reader.Read())
            {
                //ticket.AddItem(Convert.ToString(reader[0]), "Articulo",Convert.ToString(reader[2]));
                ticket.AddHeaderLine(" "+reader[0].ToString()+"      " + reader[1] +"      $"+reader[2].ToString());
                ticket.AddHeaderLine("\n");
            }

            reader.Close();
            ticket.AddHeaderLine("\n");
            ticket.AddHeaderLine("----------------------");
            ticket.AddHeaderLine("\n");
            ticket.AddHeaderLine("SUBTOTAL: $" +lblTotal.Text);
            int subtotal = Convert.ToInt32(lblTotal.Text);
            double iva=subtotal*.16;
            ticket.AddHeaderLine("IVA: $" + iva);
            ticket.AddHeaderLine("Total: $" +(subtotal+iva));
            //El metodo AddTotal requiere 2 parametros, la descripcion del total, y el precio
            //ticket.AddTotal("SUBTOTAL", "29.75" );
            //ticket.AddTotal("IVA", "5.25" );
            //ticket.AddTotal("TOTAL", lblTotal.Text);
            //ticket.AddTotal("", "" ); //Ponemos un total en blanco que sirve de espacio
            //ticket.AddTotal("RECIBIDO", "50.00" );
            //ticket.AddTotal("CAMBIO", "15.00" );
            //ticket.AddTotal("", "" );//Ponemos un total en blanco que sirve de espacio
            //ticket.AddTotal("USTED AHORRO", "0.00" );

            //El metodo AddFooterLine funciona igual que la cabecera
            //ticket.AddFooterLine("EL CAFE ES NUESTRA PASION...");
            //ticket.AddFooterLine("VIVE LA EXPERIENCIA EN STARBUCKS");
            ticket.AddFooterLine("GRACIAS POR TU VISITA");

            //Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un
            //parametro de tipo string que debe de ser el nombre de la impresora.



            //Ticket ticket = new Ticket();

            //            ticket.AddHeaderLine("Buffet Espiritu Santo ");
            //            //ticket.AddHeaderLine("Calle");
            //            //ticket.AddHeaderLine("Colonia");
            //            //ticket.AddHeaderLine("RFC: CSI-020226-MV4");
            //            ticket.AddSubHeaderLine("Ticket: " + idTicket + " ");
            //            ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());


            //            reader = conexion.select("SELECT ventasticket.cantidad,productos.nombre, " +
            //                                     "ventasticket.importe FROM     " +
            //                                     "ventasticket INNER JOIN productos " +
            //                                     "ON (ventasticket.idProducto = productos.idProducto) where ventasticket.idTicket=" + idTicket + ";");
            //            while (reader.Read())
            //            {
            //               ticket.AddItem(reader[0].ToString(),"", reader[2].ToString());
            //            }

            //            reader.Close();
            //            ticket.AddSubHeaderLine("Total:" + lblTotal.Text + " ");
            //            //ticket.AddTotal("Total:",lblTotal.Text);
            //            ticket.AddFooterLine("GRACIAS POR SU VISITA");
            //            //ticket.AddFooterLine("Dios lo bendice");

            try
            {
                ticket.PrintTicket("Generic");
                btnCerrar_Click(sender, e);
            }
            catch (System.Exception)
            {
                btnCerrar_Click(sender, e);
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
                //btnimprime_Click(sender, e);
                //MessageBox.Show("Facturando");
            }
            else
            {
                conexion.insert("UPDATE tickets SET subtotal = " + lblTotal.Text + ", " +
                                 "status='terminado' WHERE idTicket = " + idTicket + ";");
               
                Index objmesas = new Index(idEmpleado.ToString());
                objmesas.Show();
               // btnimprime_Click(sender, e);
                this.Close();
            }
            
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Index objindex = new Index(idEmpleado.ToString());
            objindex.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            barcode.Text = "2255";
            buscaTarget();
            agregaAventa(txtid.Text, txtprecio.Text, "1");
            gridVenta.DataSource = lee.fillTickets(idTicket.ToString());
            calculaTotal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            barcode.Text = "201550";
            buscaTarget();
            agregaAventa(txtid.Text, txtprecio.Text, "1");
            gridVenta.DataSource = lee.fillTickets(idTicket.ToString());
            calculaTotal();
        }

        private void btnllevar_Click(object sender, EventArgs e)
        {
            barcode.Text = "2257";
            buscaTarget();
            agregaAventa(txtid.Text, txtprecio.Text, "1");
            gridVenta.DataSource = lee.fillTickets(idTicket.ToString());
            calculaTotal();
        }
    }
}