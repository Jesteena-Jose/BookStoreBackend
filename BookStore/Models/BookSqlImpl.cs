using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class BookSqlImpl : IBookRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public BookSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            comm = new SqlCommand();
        }

        public Book AddBook(Book book)
        {
            comm.CommandText = "insert into Book values(" + book.CategoryId + ",'" + book.Title + "','" + book.Author + "','" + book.ISBN + "'," + book.Year + "," + book.Price + ",'" + book.Description + "','" + book.Position + "','" + book.Status + "','" + book.Image + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return book;
            }
            return null;
        }

        public void DeleteBook(int BookId)
        {
            comm.CommandText = "Delete from Book where BookId="+BookId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            comm.CommandText = "select * from Book";
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
                string Image =reader["Image"].ToString();
                books.Add(new Book(BookId, CategoryId, Title, Author, ISBN, Year, Price, Description, Position, Status, Image));


            }
            conn.Close();
            return books;
        }

        public List<Book> GetBookByAuthor(string GAuthor)
        {
            List<Book> books = new List<Book>();
            comm.CommandText = "select * from Book where Author="+GAuthor;
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
                books.Add(new Book(BookId, CategoryId, Title, Author, ISBN, Year, Price, Description, Position, Status, Image));


            }
            conn.Close();
            return books;
        }

        public List<Book> GetBookByCat(int CatId)
        {
            List<Book> books = new List<Book>();
            comm.CommandText = "select * from Book where CategoryId="+CatId;
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
                books.Add(new Book(BookId, CategoryId, Title, Author, ISBN, Year, Price, Description, Position, Status, Image));


            }
            conn.Close();
            return books;
        }

        public Book GetBookById(int GBookId)
        {
            Book book;
            comm.CommandText = "select * from Book where BookId="+GBookId;
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
                book = new Book(BookId, CategoryId, Title, Author, ISBN, Year, Price, Description, Position, Status, Image);
                return book;

            }
            conn.Close();
            return null;
        }

        public Book GetBookByISBN(string GISBN)
        {
            Book book;
            comm.CommandText = "select * from Book where ISBN="+GISBN;
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
                book = new Book(BookId, CategoryId, Title, Author, ISBN, Year, Price, Description, Position, Status, Image);
                return book;

            }
            conn.Close();
            return null;
        }

        public List<Book> GetBookByName(string GTitle)
        {
            List<Book> books = new List<Book>();
            comm.CommandText = "select * from Book where Title="+GTitle;
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
                books.Add(new Book(BookId, CategoryId, Title, Author, ISBN, Year, Price, Description, Position, Status, Image));


            }
            conn.Close();
            return books;
        }

        public void UpdateBook(int BookId,Book book)
        {
            comm.CommandText = "Update Book set CategoryId="+book.CategoryId+",Title='"+book.Title+"',Author='"+book.Author+"',ISBN='"+book.ISBN+"',Year="+book.Year+",Price="+book.Price+",Description='"+book.Description+"',Position='"+book.Position+"',Status="+book.Status+",Image='"+book.Image+"' where BookId="+BookId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}