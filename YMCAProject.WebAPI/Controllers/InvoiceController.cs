using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using YMCAProject.Models;
using YMCAProject.Services;

namespace YMCAProject.WebAPI.Controllers
{
    public class InvoiceController : ApiController
    {
        [HttpPost]
        [Route("api/Invoice")]
        public IHttpActionResult PostInvoice([FromBody] InvoiceCreate invoice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new InvoiceService();

            if (!service.CreateInvoice(invoice))
                return InternalServerError();

            return Ok("Invoice successfully added.");
        }

        [HttpGet]
        [Route("api/Invoice/{id}")]
        public IHttpActionResult GetInvoiceByID([FromUri] int id)
        {
            var service = new InvoiceService();
            var invoice = service.GetInvoiceByID(id);
            return Ok(invoice);
        }

        [HttpGet]
        [Route("api/Invoice")]
        public IHttpActionResult GetAllInvoices()
        {
            var service = new InvoiceService();
            var invoiceList = service.GetAllInvoices();
            return Ok(invoiceList);
        }

        [HttpPut]
        [Route("api/Invocie/{id}")]
        public IHttpActionResult PutInvoice([FromBody] InvoiceEdit invoice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new InvoiceService();

            if (!service.UpdateInvoice(invoice))
                return InternalServerError();

            return Ok("Invoice successfully updated.");
        }

        [HttpDelete]
        [Route("api/Invoice/{id}")]
        public IHttpActionResult DeleteInvocie([FromUri] int id)
        {
            var service = new InvoiceService();
            if (!service.DeleteInvoice(id))
                return InternalServerError();

            return Ok("Invoice successfully deleted.");
        }
    }
}


    