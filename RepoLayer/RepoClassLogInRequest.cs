using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
            Employee e = new Employee();
            try
            {
                string AzureConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["MyDatabase"]!;
                SqlConnection conn = new SqlConnection(AzureConnectionString);
            
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

                if(e == null)
                {
                    conn.Close();
                    Console.WriteLine("Invalid Email/Password");
                    return e!;
                }
                else
                {
                    conn.Close();
                    Console.WriteLine("Welcome back!");
                    return e;
                }
                
            }catch(SqlException ex)
            {
                Console.WriteLine(ex);
                return e;
            }
        }
    }
}