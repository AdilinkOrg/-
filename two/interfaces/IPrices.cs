using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace two.interfaces {
    interface IPrices {
        int MinCost { get; set; }
        int MaxCost { get; set; }

        int AvgValue();
    }
}
