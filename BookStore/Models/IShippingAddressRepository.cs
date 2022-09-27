using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    internal interface IShippingAddressRepository
    {
        List<ShippingAddress> GetShippingAddresses(int UserId);
        ShippingAddress AddAddress(ShippingAddress address);
        void UpdateAddress(int AddressId,ShippingAddress address);
        void DeleteAddress(int AddressId);
    }
}
