using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class FinanceManager : FinanceManagerAbstract
    {
        private string username{ get; set; }
        private string password{ get; set; } 
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