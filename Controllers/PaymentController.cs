﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
       static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(PaymentController));

        private readonly IPayment _repo;

        public PaymentController(IPayment repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Route("GetPaymentDetails")]
        public IActionResult GetPaymentProcess(long CreditCardNumber, int CreditLimit, double ProcessingCharge) 
        {
            try
            {
                return Ok(_repo.PaymentProcess(CreditCardNumber, CreditLimit, ProcessingCharge));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }


        
        }
    }
}
