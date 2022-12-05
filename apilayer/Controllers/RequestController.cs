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

       //BusinessClass business = new BusinessClass();
       private readonly IBusinessClass iBus; // dependency injection

       public RequestController(IBusinessClass iBus){ // constructor for di
        this.iBus = iBus;
       }

        [HttpGet]
        public void GetLogin()
        {
            iBus.BusinessLoginRequest();
        }

        [HttpPost]
        public Employee AddReimbursementRequest()
        {
            return iBus.ReimbursementRequest();
            
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