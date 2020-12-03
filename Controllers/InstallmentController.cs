using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jtcinstallment.Api.Entity;
using jtcinstallment.Api.Models;

namespace jtcinstallment.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InstallmentController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public InstallmentController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Installment
        [HttpGet]
        public async Task<ApiResponse> AllInstallment()
        {
            var listcustomer = await _context.TblCustomerMaster.ToListAsync();

            var listinstallment= await _context.TblInstallment.ToListAsync();
            var items = (from li in listinstallment
                        join lc in listcustomer on li.CustomerId equals lc.Id
                        select new {
                            id=li.Id,
                            stockNumber=li.StockNumber,
                            customerId=li.CustomerId,
                            salemanId=li.SalemanId,
                            salePrice=li.SalePrice,
                            downPayment=li.DownPayment,
                            timeDurationYears=li.TimeDurationYears,
                            totalInstallment=li.TotalInstallment,
                            taxPer=li.TaxPer,
                            taxAmount=li.TaxAmount,
                            finalAmount=li.FinalAmount,
                            installAmount=li.InstallAmount,
                            status=li.Status,
                            createdDate=li.CreatedDate,
                            updatedDate=li.UpdatedDate,
                            deletedDate=li.DeletedDate,
                            invoiceNumber=li.InvoiceNumber,
                            installmentmode=li.Installmentmode,
                            day=li.Day,
                           // paymentMode=li.PaymentMode,
                            customerName=lc.CustomerName,customerCode=lc.CustomerCode}).ToList();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> InstallmentDetailById(TblInstallmentDetail objInsDetail)
        {
            var items = await _context.TblInstallmentDetail.Where(i=>i.InstallmentId==objInsDetail.InstallmentId).ToListAsync();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> InstallmentPay(TblInstallmentDetail objInsDetail)
        {
            _context.Entry(objInsDetail).Property(x => x.InstallmentGivenDate).IsModified = true;
            _context.Entry(objInsDetail).Property(x => x.PaymentBy).IsModified = true;
            _context.Entry(objInsDetail).Property(x => x.ReffNo).IsModified = true;
            _context.Entry(objInsDetail).Property(x => x.PaidAmount).IsModified = true;
            _context.Entry(objInsDetail).Property(x => x.PaymentStatus).IsModified = true;
            try
            {
                var response = await _context.SaveChangesAsync();

                var ApiResponse = await InstallmentDetailById(objInsDetail);
                return ApiResponse;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var ApiResponseCatch = await response.ApiResult("FALIED", ex, "Erro In Update ");
                return ApiResponseCatch;
            }
            
        }

        // GET: api/Installment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblInstallment>> GetTblInstallment(long id)
        {
            var tblInstallment = await _context.TblInstallment.FindAsync(id);

            if (tblInstallment == null)
            {
                return NotFound();
            }

            return tblInstallment;
        }

        // PUT: api/Installment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblInstallment(long id, TblInstallment tblInstallment)
        {
            if (id != tblInstallment.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblInstallment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblInstallmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Installment
        [HttpPost]
        public async Task<ActionResult<TblInstallment>> PostTblInstallment(TblInstallment tblInstallment)
        {
            _context.TblInstallment.Add(tblInstallment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblInstallment", new { id = tblInstallment.Id }, tblInstallment);
        }

        // DELETE: api/Installment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblInstallment>> DeleteTblInstallment(long id)
        {
            var tblInstallment = await _context.TblInstallment.FindAsync(id);
            if (tblInstallment == null)
            {
                return NotFound();
            }

            _context.TblInstallment.Remove(tblInstallment);
            await _context.SaveChangesAsync();

            return tblInstallment;
        }

        private bool TblInstallmentExists(long id)
        {
            return _context.TblInstallment.Any(e => e.Id == id);
        }
    }
}
