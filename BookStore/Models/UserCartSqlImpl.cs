using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class UserCartSqlImpl : IUserCartRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public UserCartSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            comm = new SqlCommand();
        }
        public UserCart AddUserCart(UserCart userCart)
        {
            comm.CommandText = "insert into UserCart Values(" + userCart.BookId + "," + userCart.UserId + ")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return userCart;
            }
            return null;
        }

        public void DeleteUserCart(int UserCartId)
        {
            comm.CommandText = "Delete from UserCart where UserCartId=" + UserCartId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<UserCartBook> GetusercartBooks(int GUserId)
        {
            List<UserCartBook> userCartBooks = new List<UserCartBook>();
            UserCart userCart;
            Book book;
            comm.CommandText = "select * from UserCart U,Book B where U.BookId=B.BookId and U.UserId=" + GUserId;
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int UserCartId = Convert.ToInt32(reader["UserCartId"]);
                int BookId = Convert.ToInt32(reader["BookId"]);
                int UserId = Convert.ToInt32(reader["UserId"]);
                userCart = new UserCart(UserCartId, BookId, UserId);

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

                userCartBooks.Add(new UserCartBook(userCart, book));

            }
            conn.Close();
            return userCartBooks;
        }

        public void UpdateUserCart(int UserCartId, UserCart userCart)
        {
            comm.CommandText = "Update UserCart set BookId=" + userCart.BookId + " where UserCartId=" + UserCartId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}