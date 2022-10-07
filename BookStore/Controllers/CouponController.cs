using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BookStore.Models;

namespace BookStore.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class CouponController : ApiController
    {
        private ICouponRepository repository;
        public CouponController()
        {
            repository = new CouponSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetCoupons();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(int UserId)
        {
            var data = repository.GetCouponById(UserId);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Add(Coupon coupon)
        {
            var data = repository.AddCoupon(coupon);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int CouponId)
        {
            repository.DeleteCoupon(CouponId);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(int CouponId, Coupon coupon)
        {
            repository.UpdateCoupon(CouponId, coupon);
            return Ok();
        }
    }
}
