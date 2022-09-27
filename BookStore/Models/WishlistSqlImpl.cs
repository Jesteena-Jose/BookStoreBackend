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