using BookHavenDesktop.Forms.MainPages;
using DataAccessLayer.Interfaces;
using DataAccessLayer;
using LogicLayer.Managers;

namespace BookHavenDesktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            IUserDb dbUser = new DBUser();  // Data access layer stays in the background
            UserManager userManager = new UserManager(dbUser);

            ApplicationConfiguration.Initialize();
            Application.Run(new AccessForm(userManager));
        }
    }
}