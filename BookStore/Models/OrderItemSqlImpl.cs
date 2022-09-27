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