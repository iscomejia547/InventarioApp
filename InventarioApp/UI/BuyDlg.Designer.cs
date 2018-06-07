namespace InventarioApp.UI
{
    partial class BuyDlg
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProductCMB = new System.Windows.Forms.ComboBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.qtytxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pricetxt = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.FieldPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.FieldPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ProductCMB);
            this.panel1.Controls.Add(this.AddBtn);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 89);
            this.panel1.TabIndex = 0;
            // 
            // ProductCMB
            // 
            this.ProductCMB.FormattingEnabled = true;
            this.ProductCMB.Location = new System.Drawing.Point(42, 37);
            this.ProductCMB.Name = "ProductCMB";
            this.ProductCMB.Size = new System.Drawing.Size(160, 21);
            this.ProductCMB.TabIndex = 2;
            // 
            // AddBtn
            // 
            this.AddBtn.AutoSize = true;
            this.AddBtn.Location = new System.Drawing.Point(263, 35);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(92, 23);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "Agregar compra";
            this.AddBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cantidad";
            // 
            // qtytxt
            // 
            this.qtytxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtytxt.Location = new System.Drawing.Point(13, 9);
            this.qtytxt.Name = "qtytxt";
            this.qtytxt.Size = new System.Drawing.Size(140, 26);
            this.qtytxt.TabIndex = 2;
            this.qtytxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(82, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Precio";
            // 
            // pricetxt
            // 
            this.pricetxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pricetxt.Location = new System.Drawing.Point(13, 65);
            this.pricetxt.Name = "pricetxt";
            this.pricetxt.Size = new System.Drawing.Size(140, 26);
            this.pricetxt.TabIndex = 4;
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(152, 228);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // FieldPanel
            // 
            this.FieldPanel.Controls.Add(this.qtytxt);
            this.FieldPanel.Controls.Add(this.pricetxt);
            this.FieldPanel.Location = new System.Drawing.Point(182, 109);
            this.FieldPanel.Name = "FieldPanel";
            this.FieldPanel.Size = new System.Drawing.Size(200, 100);
            this.FieldPanel.TabIndex = 6;
            // 
            // BuyDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 263);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FieldPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BuyDlg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Añadir Compra";
            this.Shown += new System.EventHandler(this.BuyDlg_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.FieldPanel.ResumeLayout(false);
            this.FieldPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ProductCMB;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox qtytxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pricetxt;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Panel FieldPanel;
    }
}