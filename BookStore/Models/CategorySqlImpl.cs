using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class CategorySqlImpl : ICategoryRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CategorySqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            comm = new SqlCommand();
        }
        public Category AddCategory(Category category)
        {
            comm.CommandText = "insert into Category(CategoryName,Description,Image,Status,Position) values('"+category.CategoryName+"','"+category.Description+"','"+category.Image+"','"+category.Status+"','"+category.Position+"')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return category;
            }
            return null;
        }

        public void DeleteCategory(int CategoryId)
        {
            comm.CommandText = "Delete from Category where CategoryId=" + CategoryId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            comm.CommandText = "select * from Category";
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int CategoryId = Convert.ToInt32(reader["CategoryId"]);
                string CategoryName = reader["CategoryName"].ToString();
                string Description = reader["Description"].ToString();
                string Image = reader["Image"].ToString();
                int Status = Convert.ToInt32(reader["Status"]);
                string Position = reader["Position"].ToString();
                DateTime CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
                categories.Add(new Category(CategoryId,CategoryName,Description,Image,Status,Position,CreatedAt));

            }
            conn.Close();
            return categories;
        }

        public void UpdateCategory(int CategoryId, Category category)
        {
            comm.CommandText = "Update Category set CategoryName='"+category.CategoryName+"',Description='"+category.Description+"',Image='"+category.Image+"',Status="+category.Status+",Position='"+category.Position+"'  where CategoryId=" + CategoryId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}