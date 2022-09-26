using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class ShippingAddress
    {
        public ShippingAddress()
        {
        }

        public ShippingAddress(int addressId, string houseNo, string city, string state, string country, int pincode, int userId)
        {
            AddressId = addressId;
            HouseNo = houseNo;
            City = city;
            State = state;
            Country = country;
            Pincode = pincode;
            UserId = userId;
        }

        public int AddressId { get; set; }
        public string HouseNo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Pincode { get; set; }
        public int UserId { get; set; }
    }
}