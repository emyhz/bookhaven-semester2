using LogicLayer.EntityClasses;
using LogicLayer.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookHavenWebApp.Pages
{
    public class OrderCompleteModel : PageModel
    {
        OrderManager _orderManager;

        public OrderCompleteModel(OrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [BindProperty(SupportsGet = true)]
        public int OrderId { get; set; }

        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }

        public void OnGet()
        {
            Order order = _orderManager.GetOrderDetailsForUser(OrderId);
            TotalPrice = order.TotalPrice;
            OrderItems = order.OrderItems;
        }

    }
}
