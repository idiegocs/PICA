namespace WindowsFClientWSProductos
{
    partial class FormProductos
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
            this.button1 = new System.Windows.Forms.Button();
            this.tipoFiltroLb = new System.Windows.Forms.Label();
            this.valorFiltroLb = new System.Windows.Forms.Label();
            this.paginaLb = new System.Windows.Forms.Label();
            this.tipoFiltroTx = new System.Windows.Forms.TextBox();
            this.valorFiltroTx = new System.Windows.Forms.TextBox();
            this.paginaTx = new System.Windows.Forms.TextBox();
            this.respTa = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "consumirWS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.consumirWS);
            // 
            // tipoFiltroLb
            // 
            this.tipoFiltroLb.AutoSize = true;
            this.tipoFiltroLb.Location = new System.Drawing.Point(29, 22);
            this.tipoFiltroLb.Name = "tipoFiltroLb";
            this.tipoFiltroLb.Size = new System.Drawing.Size(53, 13);
            this.tipoFiltroLb.TabIndex = 1;
            this.tipoFiltroLb.Text = "Tipo Filtro";
            // 
            // valorFiltroLb
            // 
            this.valorFiltroLb.AutoSize = true;
            this.valorFiltroLb.Location = new System.Drawing.Point(29, 63);
            this.valorFiltroLb.Name = "valorFiltroLb";
            this.valorFiltroLb.Size = new System.Drawing.Size(56, 13);
            this.valorFiltroLb.TabIndex = 2;
            this.valorFiltroLb.Text = "Valor Filtro";
            // 
            // paginaLb
            // 
            this.paginaLb.AutoSize = true;
            this.paginaLb.Location = new System.Drawing.Point(32, 99);
            this.paginaLb.Name = "paginaLb";
            this.paginaLb.Size = new System.Drawing.Size(40, 13);
            this.paginaLb.TabIndex = 3;
            this.paginaLb.Text = "Pagina";
            // 
            // tipoFiltroTx
            // 
            this.tipoFiltroTx.Location = new System.Drawing.Point(114, 22);
            this.tipoFiltroTx.Name = "tipoFiltroTx";
            this.tipoFiltroTx.Size = new System.Drawing.Size(100, 20);
            this.tipoFiltroTx.TabIndex = 4;
            // 
            // valorFiltroTx
            // 
            this.valorFiltroTx.Location = new System.Drawing.Point(114, 63);
            this.valorFiltroTx.Name = "valorFiltroTx";
            this.valorFiltroTx.Size = new System.Drawing.Size(100, 20);
            this.valorFiltroTx.TabIndex = 5;
            // 
            // paginaTx
            // 
            this.paginaTx.Location = new System.Drawing.Point(114, 99);
            this.paginaTx.Name = "paginaTx";
            this.paginaTx.Size = new System.Drawing.Size(100, 20);
            this.paginaTx.TabIndex = 6;
            // 
            // respTa
            // 
            this.respTa.Location = new System.Drawing.Point(32, 186);
            this.respTa.Name = "respTa";
            this.respTa.Size = new System.Drawing.Size(459, 162);
            this.respTa.TabIndex = 7;
            this.respTa.Text = "";
            // 
            // FormProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 360);
            this.Controls.Add(this.respTa);
            this.Controls.Add(this.paginaTx);
            this.Controls.Add(this.valorFiltroTx);
            this.Controls.Add(this.tipoFiltroTx);
            this.Controls.Add(this.paginaLb);
            this.Controls.Add(this.valorFiltroLb);
            this.Controls.Add(this.tipoFiltroLb);
            this.Controls.Add(this.button1);
            this.Name = "FormProductos";
            this.Text = "ConsultaProductosWS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label tipoFiltroLb;
        private System.Windows.Forms.Label valorFiltroLb;
        private System.Windows.Forms.Label paginaLb;
        private System.Windows.Forms.TextBox tipoFiltroTx;
        private System.Windows.Forms.TextBox valorFiltroTx;
        private System.Windows.Forms.TextBox paginaTx;
        private System.Windows.Forms.RichTextBox respTa;
    }
}

