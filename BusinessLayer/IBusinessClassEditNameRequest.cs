using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;

namespace BusinessLayer
{
    public interface IBusinessClassEditNameRequest
    {
        public string EditNameRequest(string email, string? firstName, string? lastName);
    }
}