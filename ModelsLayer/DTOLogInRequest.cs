using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class DTOLogInRequest
    {
        public string? Email {get; set;}
        public string? Password {get; set; }

        public DTOLogInRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}