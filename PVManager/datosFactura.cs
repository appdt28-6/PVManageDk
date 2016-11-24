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
    public partial class datosFactura : Form
    {
        db conectar = new db();
        IDataReader reader;


        public datosFactura(int idtick)
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conectar.connect();
           conectar.insert("INSERT INTO clientes (`idCliente`, `razonSocial`, `idEstado`, `idMunicipio`, `colonia`, `calleYnumero`, `rfc`, `telefono`, `correo`) VALUES (NULL, '"+txtraz.Text+"','"+txtestado.Text+"','"+txtmun.Text+"','"+txtcol.Text+"','"+txtcalle.Text+"','"+txtrfc.Text+"','"+txttel.Text+"','"+txtmail.Text+"')");
            MessageBox.Show("Cliente Registrado");
            llenafactura();
            this.Close();
        }

        void llenafactura() {
            conectar.connect();
            reader=conectar.select("select max(idCliente) from clientes");
            if(reader.Read())
            {
            idcli.Text = reader[0].ToString();
            }
            reader.Close();
            reader = conectar.select("select max(idTicket)from tickets");
            if (reader.Read())
            {
                txttik.Text = reader[0].ToString();
            }
            reader.Close();
            reader = conectar.select("select subtotal from tickets where idTicket = "+txttik.Text+" ");
            if (reader.Read())
            {
                txtsub.Text = reader[0].ToString();
            }
            reader.Close();
           conectar.insert("INSERT INTO  facturas (`idFactura`,`idCliente`, `subtotal`, `iva`, `total`, `folio`, `idTicket`) VALUES (NULL, '" + idcli.Text + "','" + txtsub.Text + "','" + ".16" + "','" + Convert.ToString((double.Parse(txtsub.Text)*.16)+double.Parse(txtsub.Text)) + "','1234','" + txttik.Text + "')");
           conectar.insert("UPDATE tickets SET facturado ='Si' WHERE idTicket = " + txttik.Text + ";"); 
           imprimefact();
            //MessageBox.Show("Imprimiendo FAct");
            
        
        }
        void imprimefact() {

           printTicket fact = new printTicket();
          	fact.AddHeaderLine("C.P Espiritu Santo");
            fact.AddHeaderLine("Calle");
            fact.AddHeaderLine("Colonia");
            fact.AddHeaderLine("RFC: CSI-020226-MV4");
           //fact.AddSubHeaderLine("Ticket: " +txttik.Text + ", Mesero: " + id_Mesero);
           fact.AddSubHeaderLine("Ticket: " +txttik.Text + " ");

           fact.AddSubHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

            reader = conectar.select("SELECT razonSocial,rfc,idEstado FROM clientes where idCliente=" +idcli.Text + ";");
            while (reader.Read())
            {
                fact.AddItem(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
            }
            reader.Close();

            reader = conectar.select("select max(idFactura)from facturas");
            if (reader.Read()) {
                txtfac.Text = reader[0].ToString();
            }
            reader.Close();

            reader = conectar.select("SELECT subtotal,iva,total FROM facturas where idFactura=" +txtfac.Text+ ";");
            while (reader.Read())
            {
                //fact.AddItem(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                //}
                //reader.Close();

                fact.AddTotal("Importe: ", reader[0].ToString());
                fact.AddTotal("Iva:", reader[1].ToString());
                fact.AddTotal("Total:", reader[2].ToString());
            }
            reader.Close();

            fact.AddFooterLine("Cultura del vino");
            fact.AddFooterLine("GRACIAS POR SU VISITA");

            try
            {
               fact.PrintTicket("local");
            }
            catch (System.Exception)
            {
                MessageBox.Show("No se encontro la impresora");
            }
        
        }
		
    }
}
