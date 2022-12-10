using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;
namespace BusinessLayer
{
    public interface IBusinessClass
    {
        object SignUpRequest();
        object LoginRequest();
        public string ReimbursementRequest();
        
    }
}