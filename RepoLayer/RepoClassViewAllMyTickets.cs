using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
    public class RepoClassViewAllMyTickets : IRepoClassViewAllMyTickets
    {
        private readonly IMyLogger iLog; // dependency injection

        public RepoClassViewAllMyTickets(IMyLogger iLog){
            this.iLog = iLog;
        }

        
        public List<ReimbursementTicket> ViewAllMyTickets(string email)
        {
            SqlConnection conn = new SqlConnection("");

            List<ReimbursementTicket> tickets = new List<ReimbursementTicket>();
            SqlCommand command = new SqlCommand($"Select TicketId, Type, Description, DollarAmount, Status, Reimbursement_Tickets.EmployeeId From Reimbursement_Tickets Left Join Employees On Employees.EmployeeId = Reimbursement_Tickets.EmployeeId Where Employees.Email = @Email", conn);

            conn.Open();

            command.Parameters.AddWithValue("@Email", email);

            SqlDataReader resultSet = command.ExecuteReader(); // return record/s in a different format
            
            iLog.LogStuff(tickets);
            while(resultSet.Read()) // this method goes through each row of the result set
            {
                // a mapper just re formats the result set
                ReimbursementTicket ticket = Mapper.DataBaseToTickets(resultSet);
                tickets.Add(ticket);
            }
            Console.WriteLine($"Number of tickets returned {tickets.Count}");
            conn.Close();
            return tickets;
        }
    }
}