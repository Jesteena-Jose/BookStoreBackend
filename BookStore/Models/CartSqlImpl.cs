using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class CartSqlImpl : ICartRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CartSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            comm = new SqlCommand();
        }
        public Cart AddCart(Cart cart)
        {
            comm.CommandText = "insert into Cart(TotalPrice,AddressId,UserId) values('"+cart.TotalPrice+"','"+cart.AddressId+"','"+cart.UserId+"')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return cart;
            }
            return null;
        }

        public void DeleteCart(int CartId)
        {
            comm.CommandText = "Delete from Cart where CartId=" + CartId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public Cart GetCart(int GUserId)
        {
            Cart cart;
            comm.CommandText = "select * from Cart where UserId="+GUserId;
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int CartId = Convert.ToInt32(reader["CartId"]);
                DateTime CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                int TotalPrice = Convert.ToInt32(reader["TotalPrice"]);
                int AddressId = Convert.ToInt32(reader["AddressId"]);
                int UserId = Convert.ToInt32(reader["UserId"]);
                cart = new Cart(CartId,CreatedAt,TotalPrice,AddressId,UserId);
                return cart;
            }
            conn.Close();
            return null;
        }

        public void UpdateCart(int CartId, Cart cart)
        {
            comm.CommandText = "Update Cart set TotalPrice='"+cart.TotalPrice+"',AddressId='"+cart.AddressId+"' where CartId=" +CartId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}