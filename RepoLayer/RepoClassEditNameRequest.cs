using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ModelsLayer;
using Microsoft.Extensions.Configuration;

namespace RepoLayer
{
    public class RepoClassEditNameRequest : IRepoClassEditNameRequest
    {
        private readonly IMyLogger iLog; // dependency injection

        public RepoClassEditNameRequest(IMyLogger iLog){
            this.iLog = iLog;
        }
        public string EditNameRequest(string email ,string? firstName, string? lastName)
        {
            string AzureConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection("ConnectionStrings")["MyDatabase"]!;
            SqlConnection conn = new SqlConnection(AzureConnectionString);
            conn.Open();

            SqlCommand command = new SqlCommand($"UPDATE Employees SET FirstName = @FirstName, LastName = @LastName Where Email = @Email", conn);

            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);

            int rowsAffected = command.ExecuteNonQuery();

            
            if(rowsAffected == 1)
            {
                conn.Close();
                iLog.LogStuff("EditNameRequest");
                return "First and last name was updated.";
            }
            else
            {
                conn.Close();
                return "Nothing was updated.";
            }
        }
    }
}