using HotelManagementSystem.Data;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentDetailsController : Controller
    {
        private readonly HMSApiDbcontext dbContext;
        public PaymentDetailsController(HMSApiDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetPaymentDetails()
        {
            return Ok(dbContext.Payment_Details.ToList());
        }

        [HttpPost]
        public IActionResult AddPaymentDetails(AddPaymentDetailsWithoutId addPaymentDetailsWithoutId)
        {
            var Payment = new Payment_Detail();

            Payment.Payment_Card = addPaymentDetailsWithoutId.Payment_Card;
            Payment.Payment_Card_Holder_Name = addPaymentDetailsWithoutId.Payment_Card_Holder_Name;
            var BillId = dbContext.Bills.Find(addPaymentDetailsWithoutId.Bill_Id);
            if(BillId == null)
            {
                return NotFound("This Bill Id is not present");
            }
            else
            {
                Payment.Bill_Id = addPaymentDetailsWithoutId.Bill_Id;
            }
            
            dbContext.Payment_Details.Add(Payment);
            dbContext.SaveChanges();

            return Ok("New Payment Details Added");
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdatePaymentDetails([FromRoute] int id, UpdatePaymentDetailsWithoutId updatePaymentDetailsWithoutId)
        {
            var result = dbContext.Payment_Details.Find(id);

            if (result != null)
            {
                result.Payment_Card = updatePaymentDetailsWithoutId.Payment_Card;
                result.Payment_Card_Holder_Name = updatePaymentDetailsWithoutId.Payment_Card_Holder_Name;
                var BillId = dbContext.Bills.Find(updatePaymentDetailsWithoutId.Bill_Id);
                if (BillId == null)
                {
                    return NotFound("This Bill Id is not present");
                }
                else
                {
                    result.Bill_Id = updatePaymentDetailsWithoutId.Bill_Id;
                }

                dbContext.SaveChanges();

                return Ok("Update Successfull");
            }

            return NotFound();
        }
    }
}
