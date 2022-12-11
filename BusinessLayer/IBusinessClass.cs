using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;
namespace BusinessLayer
{
    public interface IBusinessClass
    {
        Employee SignUpRequest(Employee e);
        object LoginRequest();
        public string ReimbursementRequest();
        
    }
}