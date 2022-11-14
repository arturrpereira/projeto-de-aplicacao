using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using PA.View;



namespace PA.View
{
    public partial class index : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraServico_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public index()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void index_Load(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new inicio());

        }
        public  void AbrirNOPrincipal(object form)
        {
            if (this.Principal.Controls.Count > 0)
                this.Principal.Controls.RemoveAt(0);
            Form principal = form as Form;
            principal.TopLevel = false;
            principal.FormBorderStyle = FormBorderStyle.None;
            principal.Dock = DockStyle.Fill;
            this.Principal.Controls.Add(principal);
            this.Principal.Tag = principal;
            principal.BringToFront();
            principal.Show();

        }
        

        private void btnCadastroCliente_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new ClienteView());
            Submenu.Visible = false;
            nometela.Text = "Cadastro Cliente";
            btnHome.Visible = true;
                       

        }

        private void btnCadFunc_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new procurar_funcionario());
            Submenu.Visible = false;
            nometela.Text = "Cadastro Funcionário";
            btnHome.Visible = true;




        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraServico_Paint(object sender, PaintEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new PetView ());
            Submenu.Visible = false;
            nometela.Text = "Cadastro Pet";
            btnHome.Visible = true;


        }

        private void labelhome_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new CargoView());
            Submenu.Visible = false;
            nometela.Text = "Cadastro Cargo";
            btnHome.Visible = true;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnMaximizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Maximized;
        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (Submenu.Visible == true)
            {
                Submenu.Visible = false;
            } else
            {
                Submenu.Visible = true;
                Submenu.BringToFront();
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new UsuarioView());
            Submenu.Visible = false;
            nometela.Text = "Cadastro Usuário";
            btnHome.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new FornecedorView());
            Submenu.Visible = false;
            nometela.Text = "Cadastro Fornecedor";
            btnHome.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new ServiçoView());
            Submenu.Visible = false;
            nometela.Text = "Cadastro Serviço";
            btnHome.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new MaterialView());
            Submenu.Visible = false;
            nometela.Text = "Cadastro Material";
            btnHome.Visible = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new EstoqueView());
            Submenu.Visible = false;
            nometela.Text = "Cadastro Estoque";
            btnHome.Visible = true;

        }

        private void Principal_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Submenu_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void BoxLogo_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new inicio());
            Submenu.Visible = false;
            btnHome.Visible = false;
            nometela.Text = "Home";
        }

        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            //AbrirNOPrincipal(new DashboardView());
            btnHome.Visible = true;
            nometela.Text = "Dashboard";
        }

        private void nometela_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            btnHome.Visible = false;
            AbrirNOPrincipal(new inicio());
            nometela.Text = "Home";
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (submenu2.Visible == true)
            {
                submenu2.Visible = false;
            }
            else
            {
                submenu2.Visible = true;
                submenu2.BringToFront();
            }
            
        }

        private void submenu2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new ListaPedidosView());
            Submenu.Visible = false;
            nometela.Text = "Pedidos";
            btnHome.Visible = true;
        }

        private void btnFunc_Serv_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new Funcionario_Servico_View());
            submenu2.Visible = false;
            nometela.Text = "Funcionario/Serviços";
            btnHome.Visible=true;


        }

        private void btnForn_Mat_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new Fornecedor_Material_View());
            submenu2.Visible = false;
            nometela.Text = "Fornecedor/Material";
            btnHome.Visible = true;

     
        }

        private void btnMat_Est_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new Material_Estoque_View());
            submenu2.Visible = false;
            nometela.Text = "Material/Estoque";
            btnHome.Visible = true;

      
        }

        private void btnMov_Click(object sender, EventArgs e)
        {
            AbrirNOPrincipal(new Material_ServicoView());
            submenu2.Visible = false;
            nometela.Text = "Material/Serviço";
            btnHome.Visible = true;

        
        }

        
        private void btnDashboard2_Click(object sender, EventArgs e)
        {
 
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
