using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class ShippingAddressSqlImpl : IShippingAddressRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public ShippingAddressSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            comm = new SqlCommand();
        }
        public ShippingAddress AddAddress(ShippingAddress address)
        {
            comm.CommandText = "insert into ShippingAddress Values('"+address.HouseNo+"','"+address.City+"','"+address.State+"','"+address.Country+"',"+address.Pincode+","+address.UserId+")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return address;
            }
            return null;
        }

        public void DeleteAddress(int AddressId)
        {
            comm.CommandText = "Delete from ShippingAddress where AddressId=" + AddressId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<ShippingAddress> GetShippingAddresses(int GUserId)
        {
            List<ShippingAddress> addresses = new List<ShippingAddress>();
            comm.CommandText = "select * from ShippingAddress Where UserId=" + GUserId;
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {

                int AddressId = Convert.ToInt32(reader["AddressId"]);
                string HouseNo = reader["HouseNo"].ToString();
                string City = reader["City"].ToString();
                string State = reader["State"].ToString();
                string Country = reader["Country"].ToString();
                int Pincode = Convert.ToInt32(reader["Pincode"]);
                int UserId = Convert.ToInt32(reader["UserId"]);
                addresses.Add(new ShippingAddress(AddressId,HouseNo,City,State,Country,Pincode,UserId));

            }
            conn.Close();
            return addresses;
        }

        public void UpdateAddress(int AddressId, ShippingAddress address)
        {
            comm.CommandText = "Update ShippingAddress set HouseNo='"+address.HouseNo+"',City='"+address.City+"',State='"+address.State+"',Country='"+address.Country+"',Pincode='"+address.Pincode+"'  where AddressId=" + AddressId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}