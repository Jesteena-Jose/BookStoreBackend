using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class CouponSqlImpl:ICouponRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CouponSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            comm = new SqlCommand();
        }

        public Coupon AddCoupon(Coupon coupon)
        {
            comm.CommandText = "insert into Coupon Values('"+coupon.CouponCode+"','"+coupon.AdminId+"','"+coupon.UserId+"') ";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return coupon;
            }
            return null;
        }

        public void DeleteCoupon(int CouponId)
        {
            comm.CommandText = "Delete from Coupon where CouponId=" + CouponId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<Coupon> GetCouponById(int GUserId)
        {
            List<Coupon> Coupons = new List<Coupon>();
            comm.CommandText = "select * from Coupon Where UserId="+GUserId;
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int CouponId = Convert.ToInt32(reader["CouponId"]);
                string CouponCode = reader["CouponCode"].ToString();
                int AdminId = Convert.ToInt32(reader["AdminId"]);
                int UserId = Convert.ToInt32(reader["UserId"]);
                Coupons.Add(new Coupon(CouponId,CouponCode,AdminId,UserId));

            }
            conn.Close();
            return Coupons;
        }

        public List<Coupon> GetCoupons()
        {
            List<Coupon> Coupons = new List<Coupon>();
            comm.CommandText = "select * from Coupon";
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int CouponId = Convert.ToInt32(reader["CouponId"]);
                string CouponCode = reader["CouponCode"].ToString();
                int AdminId = Convert.ToInt32(reader["AdminId"]);
                int UserId = Convert.ToInt32(reader["UserId"]);
                Coupons.Add(new Coupon(CouponId, CouponCode, AdminId, UserId));

            }
            conn.Close();
            return Coupons;
        }

        public void UpdateCoupon(int CouponId, Coupon coupon)
        {
            comm.CommandText = "Update Coupon set CouponCode='"+coupon.CouponCode+"',AdminId="+coupon.AdminId+",UserId="+coupon.UserId+"  where CouponId=" + CouponId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}