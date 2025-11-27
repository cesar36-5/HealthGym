<<<<<<< HEAD
using HealthGym;
=======
>>>>>>> d0804effa9edd0e3e6d3dbab47c7aacd1881de38

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
            ApplicationConfiguration.Initialize();
            Application.Run(new PlanNutricional());
        }
    }
}