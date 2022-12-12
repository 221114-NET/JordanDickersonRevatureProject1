using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
    internal static class Mapper // mappers reformat if futher reformating is needed, the Read() did not work so I have to use this class  
    {
        internal static Employee DataBaseToEmployee(SqlDataReader sdr)
        {
            // map the sql column of data for that row to a c # value
            Employee employee = new Employee();
            
            employee.EmployeeId = sdr.GetInt32(0);
            employee.Position = sdr.GetString(1);
            employee.FirstName = sdr.GetString(2);
            employee.LastName = sdr.GetString(3);

            return employee;
        }

        internal static ReimbursementTicket DataBaseToTickets(SqlDataReader sdr)
        {
            // map the sql column of data for that row to a c # value
            ReimbursementTicket ticket = new ReimbursementTicket();
            
            ticket.TicketId = sdr.GetInt32(0);
            ticket.Type = sdr.GetString(1);
            ticket.Description = sdr.GetString(2);
            ticket.DollarAmount = sdr.GetString(3);
            ticket.Status = sdr.GetString(4);

            return ticket;
        }
    }
}