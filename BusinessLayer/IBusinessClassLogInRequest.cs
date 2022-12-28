using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;

namespace BusinessLayer
{
    public interface IBusinessClassLogInRequest
    {
        public string LogInRequest(string userEmail, string userPassword);
    }
}