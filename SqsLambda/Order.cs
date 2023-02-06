using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaTest
{
    internal class Order
    {
        public string Id { get; set; }
        public DateTime OrderTime { get; set; }
        public string OrderName { get; set; }
        public long OrderValue { get; set; }
        public string OrderDescription { get; set; }
    }
}
