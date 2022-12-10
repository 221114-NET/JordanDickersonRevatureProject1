using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Employee : EmployeeAbstract
    {
        public string ?Email{ get; set; }
        public string ?Password{ get; set; } 

        public string ?Type{ get; set; }
        public string ?Amount{ get; set; }

        public string ?Description{ get; set; }

        public string ?Status{ get; set; }

        public string ?Request{ get; set; }

        public override string ReimbursementRequest()
        {
            do{
            Console.WriteLine("What type of reimbursement ticket are you submitting?");
            Console.WriteLine("Pick from the following types (Travel, food or rental)?");
            Type = Console.ReadLine()!.ToLower().Replace(" ","");
            }while(!Type.Equals("travel") && !Type.Equals("food") && !Type.Equals("rental"));

            Console.WriteLine("How much should you be reimbursed for?");
            Amount = Console.ReadLine()!;

            Console.WriteLine("Explain why you should be reimbursed?");
            Description = Console.ReadLine()!;

            Status = "Pending";

            return Request = $"Ticket     type:{Type}     amount:{Amount}    description:{Description}    status:{Status}";
        }
        public override void viewUpdatedStatus()
        {

        }

    }
}