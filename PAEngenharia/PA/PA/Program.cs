using PA.View;
namespace PA
{
    public static class Global
    {
        public static int id_usuario;
        public static string login_usuario;
        public static int ultimo_pedido;
        
    }
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new login());
        }
    }
}