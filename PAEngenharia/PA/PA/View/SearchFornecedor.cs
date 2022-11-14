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
    public partial class SearchFornecedor : Form
    {
        public SearchFornecedor()
        {
            InitializeComponent();
        }

        private void SearchFornecedor_Load(object sender, EventArgs e)
        {
            NpgsqlCommand con = new NpgsqlCommand();
            con.Connection = ConnectionDB.Connection();
            con.CommandType = CommandType.Text;
            con.CommandText = "SELECT * FROM Fornecedor ORDER BY id_fornecedor";
            NpgsqlDataReader dr = con.ExecuteReader();

            if (dr.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

            }
        }
    }
}
