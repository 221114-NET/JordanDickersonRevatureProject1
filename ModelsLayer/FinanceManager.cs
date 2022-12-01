using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class FinanceManager : FinanceManagerAbstract
    {
        public string username{ get; set; }
        public string password{ get; set; } 
        public FinanceManager(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public override void viewPendingRequest(bool result)
        {

        }
    }
}