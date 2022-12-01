using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Employee //: EmployeeAbstract
    {
        public string username{ get; set; }
        public string password{ get; set; } 
        public Employee(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        /*public override void addReimbursementRequest()
        {

        }
        public override void viewUpdatedStatus()
        {

        }*/

    }
}