using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using BusinessLayer;

namespace apilayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {

       BusinessClass business = new BusinessClass();
        [HttpGet]
        public void GetLogin()
        {
            business.BusinessLoginRequest();
        }

        [HttpPost]
        public Employee AddReimbursementRequest()
        {
            return business.ReimbursementRequest();
            
        }

        /*[HttpGet]
        public string ViewPendingRequest(FinanceManager f)
        {
            return "view request";
        }

        [HttpGet]
        public string ViewUpdatedStatus(Employee e)
        {
            return "viewstatus";
        }*/

    }
}