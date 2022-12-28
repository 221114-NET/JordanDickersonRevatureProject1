using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class DTOToken
    {
        public string Token {get; set;}
        
        public DTOToken(string token)
        {
            Token = token;
        }
    }
}