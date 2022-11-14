namespace PA.View
{
    partial class SearchPET
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
            this.btn_voltar_pet = new System.Windows.Forms.Button();
            this.dataGrid_searchPet = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_searchPet)).BeginInit();
            this.SuspendLayout();
            // 
            // nometela
            // 
            this.nometela.AutoSize = true;
            this.nometela.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nometela.ForeColor = System.Drawing.Color.Black;
            this.nometela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nometela.Location = new System.Drawing.Point(361, 10);
            this.nometela.Name = "nometela";
            this.nometela.Size = new System.Drawing.Size(139, 26);
            this.nometela.TabIndex = 21;
            this.nometela.Text = "Lista de Pet";
            this.nometela.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btn_voltar_pet
            // 
            this.btn_voltar_pet.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_voltar_pet.BackColor = System.Drawing.Color.Black;
            this.btn_voltar_pet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_voltar_pet.FlatAppearance.BorderSize = 0;
            this.btn_voltar_pet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_voltar_pet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_voltar_pet.ForeColor = System.Drawing.Color.White;
            this.btn_voltar_pet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_voltar_pet.Location = new System.Drawing.Point(770, 393);
            this.btn_voltar_pet.Margin = new System.Windows.Forms.Padding(5, 2, 3, 2);
            this.btn_voltar_pet.Name = "btn_voltar_pet";
            this.btn_voltar_pet.Size = new System.Drawing.Size(121, 38);
            this.btn_voltar_pet.TabIndex = 20;
            this.btn_voltar_pet.Text = "Voltar";
            this.btn_voltar_pet.UseVisualStyleBackColor = false;
            this.btn_voltar_pet.Click += new System.EventHandler(this.btn_voltar_pet_Click);
            // 
            // dataGrid_searchPet
            // 
            this.dataGrid_searchPet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_searchPet.Location = new System.Drawing.Point(12, 65);
            this.dataGrid_searchPet.Name = "dataGrid_searchPet";
            this.dataGrid_searchPet.RowTemplate.Height = 25;
            this.dataGrid_searchPet.Size = new System.Drawing.Size(879, 323);
            this.dataGrid_searchPet.TabIndex = 19;
            // 
            // SearchPET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(903, 441);
            this.Controls.Add(this.nometela);
            this.Controls.Add(this.btn_voltar_pet);
            this.Controls.Add(this.dataGrid_searchPet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SearchPET";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchPET";
            this.Load += new System.EventHandler(this.SearchPET_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_searchPet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label nometela;
        private Button btn_voltar_pet;
        private DataGridView dataGrid_searchPet;
    }
}