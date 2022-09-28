using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class CartItemSqlImpl : ICartItemRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CartItemSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            comm = new SqlCommand();
        }
        public CartItem AddCartItem(CartItem cartItem)
        {
            comm.CommandText = "insert into CartItem values('"+cartItem.BookId+"','"+cartItem.CartId+"')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return cartItem;
            }
            return null;
        }

        public void DeleteCartItem(int CartItemId)
        {
            comm.CommandText = "Delete from CartItem where CartItemId=" + CartItemId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<CartBooks> GetBooksInCart(int GCartId)
        {
            List<CartBooks> cartBooks = new List<CartBooks>();
            Book book;
            CartItem cartItem;
            comm.CommandText = "select * from Book B,CartItem C where B.BookId=C.BookId AND CartId=" + GCartId;
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int BookId = Convert.ToInt32(reader["BookId"]);
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
                int CartItemId = Convert.ToInt32(reader["CartItemId"]);
                int CartId = Convert.ToInt32(reader["CartId"]);
                cartItem = new CartItem(CartItemId, BookId, CartId);
                cartBooks.Add(new CartBooks(cartItem, book));

            }
            conn.Close();
            return cartBooks;
        }

        public List<CartItem> GetCartItems(int GCartId)
        {
            List<CartItem> carts = new List<CartItem>();
            comm.CommandText = "select * from CartItem where CartId=" + GCartId;
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int CartItemId = Convert.ToInt32(reader["CartItemId"]);
                int BookId = Convert.ToInt32(reader["BookId"]);
                int CartId = Convert.ToInt32(reader["CartId"]);
                carts.Add(new CartItem(CartItemId,BookId,CartId));
                
            }
            conn.Close();
            return carts;
        }

        public void UpdateCartItem(int CartItemId, CartItem cartItem)
        {
            comm.CommandText = "Update CartItem set BookId='"+cartItem.BookId+"' where CartItemId=" + CartItemId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}