using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ModelsLayer;

namespace RepoLayer
{
    public class RepoClassFilterMyTickets : IRepoClassFilterMyTickets
    {

        private readonly IMyLogger iLog; // dependency injection

        public RepoClassFilterMyTickets(IMyLogger iLog){
            this.iLog = iLog;
        }

        public List<ReimbursementTicket> FilterMyTickets(string email ,string status)
        {

            string AzureConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["MyDatabase"]!;
            SqlConnection conn = new SqlConnection(AzureConnectionString);
            
            List<ReimbursementTicket> tickets = new List<ReimbursementTicket>();
            SqlCommand command = new SqlCommand($"Select TicketId, Type, Description, DollarAmount, Status, Reimbursement_Tickets.EmployeeId From Reimbursement_Tickets Left Join Employees On Employees.EmployeeId = Reimbursement_Tickets.EmployeeId Where Employees.Email = @Email AND Reimbursement_Tickets.Status = @Status", conn);

            conn.Open();
            
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Status", status);
            
            SqlDataReader resultSet = command.ExecuteReader(); // return record/s in a different format
            
            iLog.LogStuff(tickets);
            while(resultSet.Read()) // this method goes through each row of the result set
            {
                // a mapper just re formats the result set
                ReimbursementTicket ticket = Mapper.DataBaseToTickets(resultSet);
                tickets.Add(ticket);
            }

            foreach(ReimbursementTicket ticket in tickets)
            {
                Console.WriteLine($"\n{ticket.Request}");
            }
            
            conn.Close();
            return tickets;
        }
    }
}