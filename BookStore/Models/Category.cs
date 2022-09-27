using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Category
    {
        public Category() { }
        public Category(int categoryId, string categoryName, string description, string image, int status, string position, DateTime createdAt)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            Description = description;
            Image = image;
            Status = status;
            Position = position;
            CreatedAt = createdAt;
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Status { get; set; }
        public string Position { get; set; }
        public DateTime CreatedAt { get; set; }
       
    }
}