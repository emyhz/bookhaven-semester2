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

        public List<Book> GetFrequentlyBoughtBooks(int bookId, int count)
        {
            // Get all orders where the specified book was bought
            List<Order> bookOrders = _orderManager.GetOrdersForSpecificBook(bookId);

            // Extract all users who purchased these orders
            List<User> usersBoughtOrders = new List<User>();
            foreach (Order order in bookOrders)
            {
                usersBoughtOrders.Add(order.User);
            }

            // Get all orders placed by these users
            List<Order> ordersBoughtByUsers = new List<Order>();
            foreach (User user in usersBoughtOrders)
            {
                List<Order> orders = _orderManager.GetUserOrders(user.Id);
                ordersBoughtByUsers.AddRange(orders);
            }

            // Count occurrences of other books bought with the specified book
            Dictionary<int, int> bookCount = new Dictionary<int, int>();
            foreach (Order order in ordersBoughtByUsers)
            {
                foreach (OrderItem item in order.OrderItems)
                {
                    // Exclude the currently specified book
                    if (item.Book.Id != bookId)
                    {
                        if (bookCount.ContainsKey(item.Book.Id))
                        {
                            bookCount[item.Book.Id]++;
                        }
                        else
                        {
                            bookCount.Add(item.Book.Id, 1);
                        }
                    }
                }
            }

            // Sort books by their frequency in descending order and get the top `count` books
            var booksSort = bookCount.OrderByDescending(x => x.Value).Select(x=> _bookManager.GetBookById(x.Key)).Take(count).ToList();

            return booksSort;  // Return the recommended books


        }

    }
}
