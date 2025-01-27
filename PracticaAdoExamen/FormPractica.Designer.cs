namespace Test
{
    partial class FormPractica
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
            label1 = new Label();
            cmbclientes = new ComboBox();
            label2 = new Label();
            txtempresa = new TextBox();
            txtcontacto = new TextBox();
            label3 = new Label();
            txtcargo = new TextBox();
            label4 = new Label();
            txtciudad = new TextBox();
            label5 = new Label();
            txttelefono = new TextBox();
            label6 = new Label();
            label8 = new Label();
            lstpedidos = new ListBox();
            txtfechaentrega = new TextBox();
            label10 = new Label();
            label11 = new Label();
            txtformaenvio = new TextBox();
            label12 = new Label();
            txtimporte = new TextBox();
            btnnuevopedido = new Button();
            btneliminarpedido = new Button();
            txtcodigopedido = new TextBox();
            label9 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(101, 29);
            label1.TabIndex = 0;
            label1.Text = "Clientes";
            // 
            // cmbclientes
            // 
            cmbclientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbclientes.FormattingEnabled = true;
            cmbclientes.Location = new Point(17, 40);
            cmbclientes.Name = "cmbclientes";
            cmbclientes.Size = new Size(168, 37);
            cmbclientes.TabIndex = 1;
            cmbclientes.SelectedIndexChanged += cmbclientes_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(219, 12);
            label2.Name = "label2";
            label2.Size = new Size(110, 29);
            label2.TabIndex = 2;
            label2.Text = "Empresa";
            // 
            // txtempresa
            // 
            txtempresa.Location = new Point(224, 40);
            txtempresa.Name = "txtempresa";
            txtempresa.Size = new Size(207, 34);
            txtempresa.TabIndex = 3;
            // 
            // txtcontacto
            // 
            txtcontacto.Location = new Point(224, 118);
            txtcontacto.Name = "txtcontacto";
            txtcontacto.Size = new Size(207, 34);
            txtcontacto.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(219, 90);
            label3.Name = "label3";
            label3.Size = new Size(108, 29);
            label3.TabIndex = 4;
            label3.Text = "Contacto";
            // 
            // txtcargo
            // 
            txtcargo.Location = new Point(224, 194);
            txtcargo.Name = "txtcargo";
            txtcargo.Size = new Size(207, 34);
            txtcargo.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(219, 166);
            label4.Name = "label4";
            label4.Size = new Size(79, 29);
            label4.TabIndex = 6;
            label4.Text = "Cargo";
            // 
            // txtciudad
            // 
            txtciudad.Location = new Point(224, 274);
            txtciudad.Name = "txtciudad";
            txtciudad.Size = new Size(207, 34);
            txtciudad.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(219, 246);
            label5.Name = "label5";
            label5.Size = new Size(90, 29);
            label5.TabIndex = 8;
            label5.Text = "Ciudad";
            // 
            // txttelefono
            // 
            txttelefono.Location = new Point(223, 342);
            txttelefono.Name = "txttelefono";
            txttelefono.Size = new Size(208, 34);
            txttelefono.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(218, 314);
            label6.Name = "label6";
            label6.Size = new Size(110, 29);
            label6.TabIndex = 10;
            label6.Text = "Teléfono";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(469, 12);
            label8.Name = "label8";
            label8.Size = new Size(103, 29);
            label8.TabIndex = 14;
            label8.Text = "Pedidos";
            // 
            // lstpedidos
            // 
            lstpedidos.FormattingEnabled = true;
            lstpedidos.Location = new Point(469, 40);
            lstpedidos.Name = "lstpedidos";
            lstpedidos.Size = new Size(399, 410);
            lstpedidos.TabIndex = 15;
            lstpedidos.SelectedIndexChanged += lstpedidos_SelectedIndexChanged;
            // 
            // txtfechaentrega
            // 
            txtfechaentrega.Location = new Point(918, 113);
            txtfechaentrega.Name = "txtfechaentrega";
            txtfechaentrega.Size = new Size(211, 34);
            txtfechaentrega.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(914, 80);
            label10.Name = "label10";
            label10.Size = new Size(168, 29);
            label10.TabIndex = 18;
            label10.Text = "Fecha entrega";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(918, 166);
            label11.Name = "label11";
            label11.Size = new Size(181, 29);
            label11.TabIndex = 20;
            label11.Text = "Forma de envío";
            // 
            // txtformaenvio
            // 
            txtformaenvio.Location = new Point(918, 198);
            txtformaenvio.Name = "txtformaenvio";
            txtformaenvio.Size = new Size(211, 34);
            txtformaenvio.TabIndex = 21;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(918, 246);
            label12.Name = "label12";
            label12.Size = new Size(95, 29);
            label12.TabIndex = 22;
            label12.Text = "Importe";
            // 
            // txtimporte
            // 
            txtimporte.Location = new Point(918, 278);
            txtimporte.Name = "txtimporte";
            txtimporte.Size = new Size(211, 34);
            txtimporte.TabIndex = 23;
            txtimporte.TextAlign = HorizontalAlignment.Right;
            // 
            // btnnuevopedido
            // 
            btnnuevopedido.Location = new Point(914, 338);
            btnnuevopedido.Name = "btnnuevopedido";
            btnnuevopedido.Size = new Size(215, 43);
            btnnuevopedido.TabIndex = 24;
            btnnuevopedido.Text = "Nuevo pedido";
            btnnuevopedido.UseVisualStyleBackColor = true;
            btnnuevopedido.Click += btnnuevopedido_Click;
            // 
            // btneliminarpedido
            // 
            btneliminarpedido.Location = new Point(914, 397);
            btneliminarpedido.Name = "btneliminarpedido";
            btneliminarpedido.Size = new Size(215, 39);
            btneliminarpedido.TabIndex = 26;
            btneliminarpedido.Text = "Eliminar pedido";
            btneliminarpedido.UseVisualStyleBackColor = true;
            btneliminarpedido.Click += btneliminarpedido_Click;
            // 
            // txtcodigopedido
            // 
            txtcodigopedido.Location = new Point(918, 39);
            txtcodigopedido.Name = "txtcodigopedido";
            txtcodigopedido.Size = new Size(211, 34);
            txtcodigopedido.TabIndex = 28;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(914, 6);
            label9.Name = "label9";
            label9.Size = new Size(174, 29);
            label9.TabIndex = 27;
            label9.Text = "Código pedido";
            // 
            // FormPractica
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1190, 529);
            Controls.Add(txtcodigopedido);
            Controls.Add(label9);
            Controls.Add(btneliminarpedido);
            Controls.Add(btnnuevopedido);
            Controls.Add(txtimporte);
            Controls.Add(label12);
            Controls.Add(txtformaenvio);
            Controls.Add(label11);
            Controls.Add(txtfechaentrega);
            Controls.Add(label10);
            Controls.Add(lstpedidos);
            Controls.Add(label8);
            Controls.Add(txttelefono);
            Controls.Add(label6);
            Controls.Add(txtciudad);
            Controls.Add(label5);
            Controls.Add(txtcargo);
            Controls.Add(label4);
            Controls.Add(txtcontacto);
            Controls.Add(label3);
            Controls.Add(txtempresa);
            Controls.Add(label2);
            Controls.Add(cmbclientes);
            Controls.Add(label1);
            Font = new Font("Microsoft Sans Serif", 14.25F);
            Margin = new Padding(6);
            Name = "FormPractica";
            Text = "Clientes pedidos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbclientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtempresa;
        private System.Windows.Forms.TextBox txtcontacto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcargo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtciudad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstpedidos;
        private System.Windows.Forms.TextBox txtfechaentrega;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtformaenvio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtimporte;
        private System.Windows.Forms.Button btnnuevopedido;
        private System.Windows.Forms.Button btneliminarpedido;
        private System.Windows.Forms.TextBox txtcodigopedido;
        private System.Windows.Forms.Label label9;
    }
}

