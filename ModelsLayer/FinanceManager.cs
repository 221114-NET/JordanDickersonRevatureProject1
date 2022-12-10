using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class FinanceManager : FinanceManagerAbstract
    {
        public string ?email{ get; set; }
        public string ?password{ get; set; } 

        public override void viewPendingRequest(bool result)
        {

        }
    }
}