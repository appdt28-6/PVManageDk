namespace mediterranius
{
    partial class RegistroVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroVenta));
        	this.barcode = new System.Windows.Forms.TextBox();
        	this.gridVenta = new System.Windows.Forms.DataGridView();
        	this.label1 = new System.Windows.Forms.Label();
        	this.lblTotal = new System.Windows.Forms.Label();
        	this.txtnombre = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.txtprecio = new System.Windows.Forms.TextBox();
        	this.txtid = new System.Windows.Forms.TextBox();
        	this.btnimprime = new System.Windows.Forms.Button();
        	this.btnRegresar = new System.Windows.Forms.Button();
        	this.btnVender = new System.Windows.Forms.Button();
        	this.btnCerrar = new System.Windows.Forms.Button();
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.pictureBox2 = new System.Windows.Forms.PictureBox();
        	((System.ComponentModel.ISupportInitialize)(this.gridVenta)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// barcode
        	// 
        	this.barcode.Location = new System.Drawing.Point(12, 12);
        	this.barcode.Name = "barcode";
        	this.barcode.Size = new System.Drawing.Size(136, 20);
        	this.barcode.TabIndex = 0;
        	this.barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.barcode_KeyPress);
        	// 
        	// gridVenta
        	// 
        	this.gridVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.gridVenta.Location = new System.Drawing.Point(12, 109);
        	this.gridVenta.Name = "gridVenta";
        	this.gridVenta.Size = new System.Drawing.Size(727, 142);
        	this.gridVenta.TabIndex = 1;
        	this.gridVenta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVentaCambiaQuita);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.ForeColor = System.Drawing.Color.White;
        	this.label1.Location = new System.Drawing.Point(230, 75);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(31, 13);
        	this.label1.TabIndex = 2;
        	this.label1.Text = "Total";
        	// 
        	// lblTotal
        	// 
        	this.lblTotal.AutoSize = true;
        	this.lblTotal.ForeColor = System.Drawing.Color.White;
        	this.lblTotal.Location = new System.Drawing.Point(267, 75);
        	this.lblTotal.Name = "lblTotal";
        	this.lblTotal.Size = new System.Drawing.Size(13, 13);
        	this.lblTotal.TabIndex = 3;
        	this.lblTotal.Text = "0";
        	// 
        	// txtnombre
        	// 
        	this.txtnombre.Location = new System.Drawing.Point(62, 38);
        	this.txtnombre.Name = "txtnombre";
        	this.txtnombre.ReadOnly = true;
        	this.txtnombre.Size = new System.Drawing.Size(263, 20);
        	this.txtnombre.TabIndex = 4;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.ForeColor = System.Drawing.Color.White;
        	this.label2.Location = new System.Drawing.Point(9, 41);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(47, 13);
        	this.label2.TabIndex = 5;
        	this.label2.Text = "Nombre:";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.ForeColor = System.Drawing.Color.White;
        	this.label3.Location = new System.Drawing.Point(12, 71);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(40, 13);
        	this.label3.TabIndex = 6;
        	this.label3.Text = "Precio:";
        	// 
        	// txtprecio
        	// 
        	this.txtprecio.Location = new System.Drawing.Point(55, 68);
        	this.txtprecio.Name = "txtprecio";
        	this.txtprecio.ReadOnly = true;
        	this.txtprecio.Size = new System.Drawing.Size(62, 20);
        	this.txtprecio.TabIndex = 7;
        	// 
        	// txtid
        	// 
        	this.txtid.Location = new System.Drawing.Point(161, 12);
        	this.txtid.Name = "txtid";
        	this.txtid.Size = new System.Drawing.Size(34, 20);
        	this.txtid.TabIndex = 8;
        	this.txtid.Visible = false;
        	// 
        	// btnimprime
        	// 
        	this.btnimprime.Location = new System.Drawing.Point(647, 288);
        	this.btnimprime.Name = "btnimprime";
        	this.btnimprime.Size = new System.Drawing.Size(92, 47);
        	this.btnimprime.TabIndex = 9;
        	this.btnimprime.Text = "Ticket";
        	this.btnimprime.UseVisualStyleBackColor = true;
        	this.btnimprime.Click += new System.EventHandler(this.btnimprime_Click);
        	// 
        	// btnRegresar
        	// 
        	this.btnRegresar.BackColor = System.Drawing.SystemColors.Control;
        	this.btnRegresar.Location = new System.Drawing.Point(440, 289);
        	this.btnRegresar.Name = "btnRegresar";
        	this.btnRegresar.Size = new System.Drawing.Size(106, 46);
        	this.btnRegresar.TabIndex = 10;
        	this.btnRegresar.Text = "Regresar";
        	this.btnRegresar.UseVisualStyleBackColor = true;
        	this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
        	// 
        	// btnVender
        	// 
        	this.btnVender.Location = new System.Drawing.Point(137, 64);
        	this.btnVender.Name = "btnVender";
        	this.btnVender.Size = new System.Drawing.Size(87, 35);
        	this.btnVender.TabIndex = 11;
        	this.btnVender.Text = "Vender";
        	this.btnVender.UseVisualStyleBackColor = true;
        	this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
        	// 
        	// btnCerrar
        	// 
        	this.btnCerrar.Location = new System.Drawing.Point(552, 289);
        	this.btnCerrar.Name = "btnCerrar";
        	this.btnCerrar.Size = new System.Drawing.Size(89, 46);
        	this.btnCerrar.TabIndex = 12;
        	this.btnCerrar.Text = "Terminar";
        	this.btnCerrar.UseVisualStyleBackColor = true;
        	this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.Location = new System.Drawing.Point(0, 0);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(1045, 417);
        	this.pictureBox1.TabIndex = 13;
        	this.pictureBox1.TabStop = false;
        	// 
        	// label4
        	// 
        	this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
        	this.label4.Location = new System.Drawing.Point(157, 295);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(20, 23);
        	this.label4.TabIndex = 15;
        	this.label4.Text = "by";
        	// 
        	// pictureBox2
        	// 
        	this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
        	this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
        	this.pictureBox2.Location = new System.Drawing.Point(183, 265);
        	this.pictureBox2.Name = "pictureBox2";
        	this.pictureBox2.Size = new System.Drawing.Size(174, 70);
        	this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        	this.pictureBox2.TabIndex = 14;
        	this.pictureBox2.TabStop = false;
        	// 
        	// RegistroVenta
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.Color.SteelBlue;
        	this.ClientSize = new System.Drawing.Size(751, 347);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.pictureBox2);
        	this.Controls.Add(this.btnCerrar);
        	this.Controls.Add(this.btnVender);
        	this.Controls.Add(this.btnRegresar);
        	this.Controls.Add(this.btnimprime);
        	this.Controls.Add(this.txtid);
        	this.Controls.Add(this.txtprecio);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.txtnombre);
        	this.Controls.Add(this.lblTotal);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.gridVenta);
        	this.Controls.Add(this.barcode);
        	this.Controls.Add(this.pictureBox1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        	this.Name = "RegistroVenta";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Vino";
        	((System.ComponentModel.ISupportInitialize)(this.gridVenta)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox barcode;
        private System.Windows.Forms.DataGridView gridVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtprecio;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Button btnimprime;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}