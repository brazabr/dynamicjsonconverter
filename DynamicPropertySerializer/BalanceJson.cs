using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicPropertySerializer
{
    public class BalanceJson
    {
        public string currencyCode { get; set; }
        public string available { get; set; }
        public string onOrders { get; set; }
        public string btcValue { get; set; }
    }
}
