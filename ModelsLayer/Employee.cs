using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
namespace ModelsLayer
{
    public class Employee : EmployeeAbstract
    {

        // constructor for employee object to post data into it
        public Employee(){}

        // get employee constructor
        public Employee(int EmployeeId,  string Position, string FirstName, string LastName)
        {
            this.EmployeeId = EmployeeId;
            this.Position = Position;
            this.FirstName = FirstName;
            this.LastName = LastName;
        }


        public int ?EmployeeId{ get; set; }

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
    }
}