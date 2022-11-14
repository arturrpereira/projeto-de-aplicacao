using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using PA.db;

namespace PA.View
{
    public partial class SearchPET : Form
    {
        public SearchPET()
        {
            InitializeComponent();
        }

        private void btn_voltar_pet_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SearchPET_Load(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM Pet ORDER BY id_pet";
            NpgsqlDataReader dr = con.ExecuteReader();

            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGrid_searchPet.DataSource = dt;
            }
        }
    }
}
