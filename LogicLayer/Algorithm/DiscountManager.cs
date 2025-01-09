using LogicLayer.DesignPattern;
using LogicLayer.EntityClasses;
using LogicLayer.Interfaces;
using LogicLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Algorithm
{
    public class DiscountManager
    {
        private UserManager _userManager;
        private BookManager _bookManager;
        private OrderManager _orderManager;
        

        public DiscountManager(UserManager userManager, BookManager bookManager, OrderManager orderManager)
        {
            _userManager = userManager;
            _bookManager = bookManager;
            _orderManager = orderManager;
        }

        public void ApplyDiscountForInactiveUsers(int userId, List<Book> books)
        {
            // Get the user's last purchase date
            DateTime? lastPurchaseDate = _orderManager.GetUserLastPurchaseDate(userId);

            // Determine the discount strategy
            IDiscountStrategy discountStrategy;

            if (lastPurchaseDate == null)
            {
                // User is new and has never made a purchase, so no discount
                discountStrategy = new NoDiscount();
            }
            else
            {
                int daysSinceLastPurchase = (DateTime.Now - lastPurchaseDate.Value).Days;

                // If the user hasn't purchased in the last 20 days, apply the LongTimeNoBuyDiscount
                if (daysSinceLastPurchase > 20)
                {
                    discountStrategy = new LongTimeNoBuyDiscount(lastPurchaseDate.Value, 10); // 10% discount
                }
                else
                {
                    discountStrategy = new NoDiscount();
                }
            }

            // Apply the discount strategy to all books
            foreach (Book book in books)
            {
                book.SetDiscountStrategy(discountStrategy);
            }
        }
    }
}
