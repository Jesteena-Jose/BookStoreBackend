using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Coupon
    {
        public Coupon() { }
        public Coupon(int couponId, string couponCode, int adminId,int userId)
        {
            CouponId = couponId;
            CouponCode = couponCode;
            AdminId = adminId;
            UserId = userId;
        }

        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public int AdminId { get; set; }
        public int UserId { get; set; }

    }
}