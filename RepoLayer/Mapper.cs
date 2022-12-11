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
    }
}