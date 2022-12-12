using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class ReimbursementTicket : ReimbursementTicketAbstract
    {
        [JsonPropertyName("ticketid")]
        public int ?TicketId{ get; set; }
        
        [JsonPropertyName("type")]
        public string ?Type{ get; set; }

        [JsonPropertyName("dollaramount")]
        public string ?DollarAmount{ get; set; }

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
            Type = Console.ReadLine()!.ToUpper().Replace(" ","");
            }while(!Type.Equals("TRAVEL") && !Type.Equals("FOOD") && !Type.Equals("RENTAL"));
            
            Regex hasLetter = new Regex("^\\d+$");

            // continue looping until Amount only contains numbers
            do{
                Console.WriteLine("How much should you be reimbursed for? (digits only)");
                DollarAmount = Console.ReadLine()!.Replace(" ","");
            }while(!hasLetter.IsMatch(DollarAmount)); // returns true when DollarAmount only contains numbers
            

            Console.WriteLine("Explain why you should be reimbursed?");
            Description = Console.ReadLine()!;

            Status = "Pending";

            return Request = $"Ticket Type: {Type} \nAmount: {DollarAmount} \nDescription: {Description} \nStatus: {Status}";
        }
    }
}