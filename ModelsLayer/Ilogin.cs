using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    // Login Interface that allows dependency injection
    public interface Ilogin
    {
        object login(string username, string password);
    }
}