using HealthGym.Mantenedores;

namespace HealthGym
{
    internal static class Program
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
<<<<<<< HEAD
            Application.Run(new Recetas());
=======
            Application.Run(new MantenedorAlergia());
>>>>>>> 8f9e504544c1401ea82fbde3c5524f27251837e7
        }
    }
}