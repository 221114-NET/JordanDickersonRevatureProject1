using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class FinanceManager : FinanceManagerAbstract
    {
        public string ?Email{ get; set; }
        public string ?Password{ get; set; } 

        public override void viewPendingRequest(bool result)
        {

        }
    }
}