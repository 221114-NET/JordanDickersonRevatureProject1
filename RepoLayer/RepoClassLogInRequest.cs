using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
    public class RepoClassLogInRequest : IRepoClassLogInRequest
    {
        private readonly IMyLogger iLog; // dependency injection

        public RepoClassLogInRequest(IMyLogger iLog){
            this.iLog = iLog;
        }

        public Employee LogInRequest(string userEmail, string userPassword)
        {
            Employee e = new Employee(userEmail, userPassword);

            SqlConnection conn = new SqlConnection("");
            SqlCommand command = new SqlCommand($"Select EmployeeId, Position, FirstName, LastName From Employees Where Email = @Email AND Password = @Password", conn);

            conn.Open();

            command.Parameters.AddWithValue("@Email", userEmail);
            command.Parameters.AddWithValue("@Password", userPassword);

            SqlDataReader resultSet = command.ExecuteReader(); // return record/s in a different format
            
            iLog.LogStuff(e);
            while(resultSet.Read()) // this method goes through each row of the result set
            {
                // a mapper just re formats the result set
                e = Mapper.DataBaseToEmployee(resultSet);
            }
            
            conn.Close();
            return e;
        }
    }
}