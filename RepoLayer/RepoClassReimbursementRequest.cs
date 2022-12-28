using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ModelsLayer;

namespace RepoLayer
{
    public class RepoClassReimbursementRequest : IRepoClassReimbursementRequest
    {
         private readonly IMyLogger iLog; // dependency injection

        public RepoClassReimbursementRequest(IMyLogger iLog){
            this.iLog = iLog;
        }  

        public ReimbursementTicket ReimbursementRequest(ReimbursementTicket ticket, int employeeId)
        {
            string AzureConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["MyDatabase"]!;
            SqlConnection conn = new SqlConnection(AzureConnectionString);
            
            SqlCommand command = new SqlCommand($"insert into Reimbursement_Tickets (Type, Description, DollarAmount, Status, EmployeeId)"
            + "VALUES (@Type, @Description, @DollarAmount, @Status, @EmployeeId)",conn);

            conn.Open();

            command.Parameters.AddWithValue("@Type", ticket.Type);
            command.Parameters.AddWithValue("@Description", ticket.Description);
            command.Parameters.AddWithValue("@DollarAmount", ticket.DollarAmount);
            command.Parameters.AddWithValue("@Status", ticket.Status);
            command.Parameters.AddWithValue("@EmployeeId", employeeId); //e.EmployeeId

            int rowsAffected = command.ExecuteNonQuery();

            
            if(rowsAffected == 1)
            {
                iLog.LogStuff(ticket);
                Console.WriteLine("Your reimbursement request was sent, check your status later.");
                Console.WriteLine($"Summary\n{ticket.Request}");
            }
            else
            {
                Console.WriteLine("Your reimbursement request was unsuccessful, try again");
                ticket = null!;
            }
            
            conn.Close();
            return ticket;
        }
    }
}