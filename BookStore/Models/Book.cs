using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book
    {

        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public int Status { get; set; }
        public string Image { get; set; }

        public Book()
        {

        }
        public Book(int BookId,int CategoryId,string Title,string Author,string ISBN,int Year,int Price,string Description,string Position,int Status,string Image)
        {
            this.BookId = BookId;
            this.CategoryId = CategoryId;
            this.Title = Title;
            this.Author = Author;
            this.ISBN = ISBN;
            this.Year = Year;
            this.Price = Price;
            this.Description = Description;
            this.Position = Position;
            this.Status = Status;
            this.Image = Image;
        }
    }
    
}