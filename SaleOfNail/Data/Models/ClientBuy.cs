using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleOfNail.Data.Models
{
    public class ClientBuy
    {
        public IEnumerable<Nail> inProgress;
        public IEnumerable<Nail> done;
        public IEnumerable<Nail> notDone;
        public string name;
        public ClientBuy(IEnumerable<Nail> inProgress, IEnumerable<Nail> done, IEnumerable<Nail> notDone, string name)
        {
            this.inProgress = inProgress;
            this.done = done;
            this.notDone = notDone;
            this.name = name;
        }
    }
}
