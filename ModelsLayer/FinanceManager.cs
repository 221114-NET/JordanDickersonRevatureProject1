using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class FinanceManager : FinanceManagerAbstract
    {
        public string ?EmployeeId{ get; set; }

        [JsonPropertyName("email")]
        public string ?Email{ get; set; }

        [JsonPropertyName("password")]
        public string ?Password{ get; set; }

        [JsonPropertyName("position")] 
        public string ?Position{ get; set; } = "Finance Manager";

        [JsonPropertyName("firstname")]
        public string ?FirstName{ get; set; }

        [JsonPropertyName("lastname")]
        public string ?LastName{ get; set; }


        public override void ViewPendingRequest(bool result)
        {

        }
    }
}