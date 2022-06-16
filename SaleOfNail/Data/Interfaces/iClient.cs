using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaleOfNail.Data.Models;
namespace SaleOfNail.Data.Interfaces
{
    public interface iClient
    {
        IEnumerable<Nail> inProcess(string name);
        IEnumerable<Nail> notDone(string name);
        IEnumerable<Nail> Done(string name);
        bool setClient(string name, string pass, string telephone);
        bool getClient(string name);
        void writeSale(int numberOfNail, string clientName);
    }
}
