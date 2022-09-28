using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class WishlistSqlImpl : IWishlistRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public WishlistSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            comm = new SqlCommand();
        }
        public Wishlist AddWishlist(Wishlist wishlist)
        {
            comm.CommandText = "insert into Wishlist Values("+wishlist.BookId+","+wishlist.UserId+")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return wishlist;
            }
            return null;
        }

        public void DeleteWishlist(int WishlistId)
        {
            comm.CommandText = "Delete from Whislist where WishlistId=" + WishlistId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<WishlistBook> GetWishlistBooks(int GUserId)
        {
            List<WishlistBook> wishlistbooks = new List<WishlistBook>();
            Wishlist wishlist;
            Book book;
            comm.CommandText = "select * from Wishlist W,Book B where W.BookId=B.BookId and W.UserId=" + GUserId;
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int WishlistId = Convert.ToInt32(reader["WishlistId"]);
                int BookId = Convert.ToInt32(reader["BookId"]);
                int UserId = Convert.ToInt32(reader["UserId"]);
                wishlist=new Wishlist(WishlistId, BookId, UserId);

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

                wishlistbooks.Add(new WishlistBook(wishlist, book));

            }
            conn.Close();
            return wishlistbooks;
        }

        public List<Wishlist> GetWishlists(int GUserId)
        {
            List<Wishlist> wishlists = new List<Wishlist>();
            comm.CommandText = "select * from Wishlist where UserId="+GUserId;
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int WishlistId = Convert.ToInt32(reader["WishlistId"]);
                int BookId = Convert.ToInt32(reader["BookId"]);
                int UserId = Convert.ToInt32(reader["UserId"]);
                wishlists.Add(new Wishlist(WishlistId,BookId,UserId));

            }
            conn.Close();
            return wishlists;
        }

        public void UpdateWishlist(int WishlistId, Wishlist wishlist)
        {
            comm.CommandText = "Update Wishlist set BookId="+wishlist.BookId+" where WishlistId=" + WishlistId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}