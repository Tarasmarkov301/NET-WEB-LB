using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfNail.Data.Models
{
    public class Client
    {
        public string name { get; set; }
        public Client(string name)
        {
            this.name = name;
        }
    }
}
