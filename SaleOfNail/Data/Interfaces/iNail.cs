using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleOfNail.Data.Models;

namespace SaleOfNail.Data.Interfaces
{
    public interface iNail
    {
        IEnumerable<Nail> ALLNail { get; }
        IEnumerable<Nail> getNail(int number, string name);
        Nail getOneNail(int id);
        bool getPass(string name, string pass);
    }
}
