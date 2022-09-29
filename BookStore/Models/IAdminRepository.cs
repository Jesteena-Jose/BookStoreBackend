using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    internal interface IAdminRepository
    {
        Admin GetAdmin(string Username,string Password);
    }
}
