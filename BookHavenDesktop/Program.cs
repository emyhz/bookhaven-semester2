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

            IUserDb dbUser = new DBUser();              // Data access layer for user
            IOrderDb dbOrder = new DBOrder();           // Data access layer for orders
            IOrderItemDb dbOrderItem = new DBOrderItem(); // Data access layer for order items

            UserManager userManager = new UserManager(dbUser);
            OrderItemManager orderItemManager = new OrderItemManager(dbOrderItem, userManager, new BookManager());
            OrderManager orderManager = new OrderManager(dbOrder, userManager, orderItemManager);


            ApplicationConfiguration.Initialize();
            Application.Run(new AccessForm(userManager, orderManager));
        }
    }
}