using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class OrderItemSqlImpl : IOrderItemRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public OrderItemSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            comm = new SqlCommand();
        }
        public OrderItem AddOrderItem(OrderItem orderItem)
        {
            comm.CommandText = "insert into OrderItem Values("+orderItem.BookId+","+orderItem.OrderId+")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return orderItem;
            }
            return null;
        }

        public void DeleteOrderItem(int OrderItemId)
        {
            comm.CommandText = "Delete from OrderItem where OrderItemId=" + OrderItemId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<OrderBooks> GetAllOrderBooks(int GUserId)
        {
            List<OrderBooks> orderbooks = new List<OrderBooks>();
            Order order;
            OrderItem orderItem;
            Book book;
            comm.CommandText = "select * from [Order] O,OrderItem OT, Book B where O.OrderId = OT.OrderId and OT.BookId = B.BookId and O.UserId="+GUserId;
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int OrderItemId = Convert.ToInt32(reader["OrderItemId"]);
                int BookId = Convert.ToInt32(reader["BookId"]);
                int OrderId = Convert.ToInt32(reader["OrderId"]);
                orderItem=new OrderItem(OrderItemId, BookId, OrderId);
                                
                DateTime OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                int TotalPrice = Convert.ToInt32(reader["TotalPrice"]);
                string OrderStatus = reader["OrderStatus"].ToString();
                DateTime DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"]);
                int AddressId = Convert.ToInt32(reader["AddressId"]);
                int UserId = Convert.ToInt32(reader["UserId"]);
                order=new Order(OrderId, OrderDate, TotalPrice, OrderStatus, DeliveryDate, AddressId, UserId);

                int CategoryId = Convert.ToInt32(reader["CategoryId"]);
                string Title = reader["Title"].ToString();
                string Author = reader["Author"].ToString();
                string ISBN = reader["ISBN"].ToString();
                int Year = Convert.ToInt32(reader["Year"]);
                int Price = Convert.ToInt32(reader["Price"]);
                string Description = reader["Description"].ToString();
                string Position = reader["Position"].ToString();
                int Status = Convert.ToInt32(reader["Status"]);
                string Image = reader["Image"].ToString();
                book=new Book(BookId, CategoryId, Title, Author, ISBN, Year, Price, Description, Position, Status, Image);
                orderbooks.Add(new OrderBooks(order, orderItem, book));

            }
            conn.Close();
            return orderbooks;
        }

        public List<OrderBooks> GetNewOrderBooks(int GUserId, int status)
        {
            if (status == 1)
            {
                List<OrderBooks> orderbooks = new List<OrderBooks>();
                Order order;
                OrderItem orderItem;
                Book book;
                comm.CommandText = "select * from [Order] O,OrderItem OT, Book B where O.OrderId = OT.OrderId and OT.BookId = B.BookId and O.OrderStatus!='Completed' and O.UserId=" + GUserId;
                conn.Open();
                comm.Connection = conn;
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    int OrderItemId = Convert.ToInt32(reader["OrderItemId"]);
                    int BookId = Convert.ToInt32(reader["BookId"]);
                    int OrderId = Convert.ToInt32(reader["OrderId"]);
                    orderItem = new OrderItem(OrderItemId, BookId, OrderId);

                    DateTime OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    int TotalPrice = Convert.ToInt32(reader["TotalPrice"]);
                    string OrderStatus = reader["OrderStatus"].ToString();
                    DateTime DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"]);
                    int AddressId = Convert.ToInt32(reader["AddressId"]);
                    int UserId = Convert.ToInt32(reader["UserId"]);
                    order = new Order(OrderId, OrderDate, TotalPrice, OrderStatus, DeliveryDate, AddressId, UserId);

                    int CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    string Title = reader["Title"].ToString();
                    string Author = reader["Author"].ToString();
                    string ISBN = reader["ISBN"].ToString();
                    int Year = Convert.ToInt32(reader["Year"]);
                    int Price = Convert.ToInt32(reader["Price"]);
                    string Description = reader["Description"].ToString();
                    string Position = reader["Position"].ToString();
                    int Status = Convert.ToInt32(reader["Status"]);
                    string Image = reader["Image"].ToString();
                    book = new Book(BookId, CategoryId, Title, Author, ISBN, Year, Price, Description, Position, Status, Image);
                    orderbooks.Add(new OrderBooks(order, orderItem, book));

                }
                conn.Close();
                return orderbooks;
            }
            else
            {
                return null;
            }
        }

        public List<OrderItem> GetOrderItems(int GOrderId)
        {
            List<OrderItem> orderitems = new List<OrderItem>();
            comm.CommandText = "select * from OrderItem Where OrderId=" + GOrderId;
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int OrderItemId = Convert.ToInt32(reader["OrderItemId"]);
                int BookId = Convert.ToInt32(reader["BookId"]);
                int OrderId = Convert.ToInt32(reader["OrderId"]);
                orderitems.Add(new OrderItem(OrderItemId,BookId,OrderId));

            }
            conn.Close();
            return orderitems;
        }

        public void UpdateOrderItem(int OrderItemId,OrderItem orderItem)
        {
            comm.CommandText = "Update OrderItem set OrderId="+orderItem.OrderId+",BookId="+orderItem.BookId+"  where OrderItemId=" + OrderItemId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}