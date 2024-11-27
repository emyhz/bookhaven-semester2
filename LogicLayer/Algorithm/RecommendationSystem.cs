using LogicLayer.EntityClasses;
using LogicLayer.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Algorithm
{
    public class RecommendationSystem
    {
        private OrderManager _orderManager;
        private BookManager _bookManager;
        public RecommendationSystem(OrderManager orderManager, BookManager bookManager)
        {
            _orderManager = orderManager;
            _bookManager = bookManager;
        }
        //public List<Book> GetFrequentlyBoughtBooks(int bookId, int count)
        //{
        //    List<Order> bookOrders = _orderManager.GetUserOrders(bookId);

        //}

    }
}
