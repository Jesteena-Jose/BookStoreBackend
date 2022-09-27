using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    internal interface ICouponRepository
    {
        List<Coupon> GetCoupons();
        List<Coupon> GetCouponById(int UserId);
        Coupon AddCoupon(Coupon coupon);
        void UpdateCoupon(int CouponId, Coupon coupon);
        void DeleteCoupon(int CouponId);
    }
}
