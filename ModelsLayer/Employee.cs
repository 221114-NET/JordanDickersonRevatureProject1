using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ModelsLayer
{
    public class Employee : EmployeeAbstract
    {

        // constructor for employee object to post data into it
        public Employee()
        {

        }

        // get employee constructor
        public Employee(string EmployeeId, string Email, string Password, string Position, string FirstName, string LastName)
        {
            this.Email = Email;
            this.Password = Password;
            this.Position = Position;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }


        public string ?EmployeeId{ get; set; }

        [JsonPropertyName("email")]
        public string ?Email{ get; set; }

        [JsonPropertyName("password")]
        public string ?Password{ get; set; }

        [JsonPropertyName("position")] 
        public string ?Position{ get; set; } = "Employee";

        [JsonPropertyName("firstname")]
        public string ?FirstName{ get; set; }

        [JsonPropertyName("lastname")]
        public string ?LastName{ get; set; }

        [JsonPropertyName("type")]
        public string ?Type{ get; set; }

        [JsonPropertyName("amount")]
        public string ?Amount{ get; set; }

        [JsonPropertyName("description")]
        public string ?Description{ get; set; }

        [JsonPropertyName("status")]
        public string ?Status{ get; set; }

        [JsonPropertyName("request")]
        public string ?Request{ get; set; }

        public override string ReimbursementRequest()
        {
            // do while loop for type validation
            do{
            Console.WriteLine("What type of reimbursement ticket are you submitting?");
            Console.WriteLine("Pick from the following types (Travel, Food or Rental)?");
            Type = Console.ReadLine()!.ToLower().Replace(" ","");
            }while(!Type.Equals("travel") && !Type.Equals("food") && !Type.Equals("rental"));

            Console.WriteLine("How much should you be reimbursed for?");
            Amount = Console.ReadLine()!;

            Console.WriteLine("Explain why you should be reimbursed?");
            Description = Console.ReadLine()!;

            Status = "Pending";

            return Request = $"Ticket Type: {Type} \nAmount: {Amount} \nDescription: {Description} \nStatus: {Status}";
        }
        public override void viewUpdatedStatus()
        {

        }

    }
}