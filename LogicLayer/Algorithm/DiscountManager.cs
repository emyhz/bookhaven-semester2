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
            DateTime? lastPurchaseDate = _orderManager.GetUserLastPurchaseDate(userId);


            IDiscountStrategy discountStrategy;

            if (lastPurchaseDate == null || lastPurchaseDate == DateTime.MinValue)
            {
                discountStrategy = new NoDiscount();
            }
            else
            {
                discountStrategy = new LongTimeNoBuyDiscount(lastPurchaseDate.Value, 10); //discount = 10%
            }

            // Apply the discount strategy to all books
            foreach (Book book in books)
            {
                book.SetDiscountStrategy(discountStrategy);
            }

        }
    }
}
