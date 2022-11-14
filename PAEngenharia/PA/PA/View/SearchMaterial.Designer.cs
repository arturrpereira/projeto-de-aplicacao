namespace PA.View
{
    partial class SearchMaterial
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
            this.nometela = new System.Windows.Forms.Label();
            this.btn_voltar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // nometela
            // 
            this.nometela.AutoSize = true;
            this.nometela.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nometela.ForeColor = System.Drawing.Color.Black;
            this.nometela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nometela.Location = new System.Drawing.Point(361, 9);
            this.nometela.Name = "nometela";
            this.nometela.Size = new System.Drawing.Size(200, 26);
            this.nometela.TabIndex = 21;
            this.nometela.Text = "Lista de Materiais";
            this.nometela.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_voltar
            // 
            this.btn_voltar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_voltar.BackColor = System.Drawing.Color.Black;
            this.btn_voltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_voltar.FlatAppearance.BorderSize = 0;
            this.btn_voltar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_voltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_voltar.ForeColor = System.Drawing.Color.White;
            this.btn_voltar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_voltar.Location = new System.Drawing.Point(770, 392);
            this.btn_voltar.Margin = new System.Windows.Forms.Padding(5, 2, 3, 2);
            this.btn_voltar.Name = "btn_voltar";
            this.btn_voltar.Size = new System.Drawing.Size(121, 38);
            this.btn_voltar.TabIndex = 20;
            this.btn_voltar.Text = "Voltar";
            this.btn_voltar.UseVisualStyleBackColor = false;
            this.btn_voltar.Click += new System.EventHandler(this.btn_voltar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(879, 323);
            this.dataGridView1.TabIndex = 19;
            // 
            // SearchMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(903, 441);
            this.Controls.Add(this.nometela);
            this.Controls.Add(this.btn_voltar);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SearchMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchMaterial";
            this.Load += new System.EventHandler(this.SearchMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label nometela;
        private Button btn_voltar;
        private DataGridView dataGridView1;
    }
}