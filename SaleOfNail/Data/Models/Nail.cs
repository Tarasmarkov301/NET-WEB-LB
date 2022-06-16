using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SaleOfNail.Data.Models
{
    public class Nail
    {
        public string name { get; set; }
        public int number { get; set; }
        public int price { get; set; }
        public string foto { get; set; }
        public string description { get; set; }
        public Nail(string name ,int number , int price, string foto, string description) {
            this.name = name;
            this.number = number;
            this.price = price;
            this.description = description;
            this.foto = foto;
        }
    }
}
