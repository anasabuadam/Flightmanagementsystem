using Flightmanagementsystem.BasicFolderClass;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Flightmanagementsystem.DAOClass;
using Flightmanagementsystem.FacadeClass;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace Fly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerDAO icustomer;
        public readonly CustomerDAOPGSQL customerDAOPGSQL;
        public CustomerController(ICustomerDAO customer, CustomerDAOPGSQL dAOPGSQL)
        {
            icustomer = customer;
            customerDAOPGSQL = dAOPGSQL;
        }

        [HttpGet]
        public Task<CustomerDAOPGSQL> GetCustomer(int ID)
        {
            AnonymousUserFacade userFacade = new AnonymousUserFacade();
            IList<CustomerDAOPGSQL> customers = (IList<CustomerDAOPGSQL>)userFacade.GetAllFlights();
            Console.WriteLine(customers);
            return (Task<CustomerDAOPGSQL>)customers;


        }

    }
}

