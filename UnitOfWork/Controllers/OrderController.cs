using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Data;
using UnitOfWork.Models;
using UnitOfWork.Repositories;

namespace UnitOfWork.Controllers
{
    [ApiController]
    [Route("v1/orders")]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public Order Post([FromServices] ICustomerRepository customerRepository,
                            [FromServices] IOrderRepository orderRepository,
                             [FromServices] IUniOfWork unityOfWork)
        {
            try
            {
                var customer = new Customer { Name = "Fernando Henrique Leme" };
                var order = new Order { Number = "123", Customer = customer };
                customerRepository.Save(customer);
                orderRepository.Save(order);
                unityOfWork.Commit();
                return order;
            }
            catch
            {
                unityOfWork.Rollback();
                return null;
            }
        }
    }
}