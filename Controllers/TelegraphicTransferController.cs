using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jtcinstallment.Api.Entity;
using jtcinstallment.Api.Models;
using System.Diagnostics;
using System.Linq.Expressions;

namespace jtccarsales.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TelegraphicTransferController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public TelegraphicTransferController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/TelegraphicTransfer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCustomerTt>>> GetTblCustomerTt()
        {
            return await _context.TblCustomerTt.ToListAsync();
        }
        // GET: api/TelegraphicTransfer
        [HttpGet]
        public async Task<ApiResponse> GetCustomerTT()
        {
            try{
                var ttList = await _context.TblCustomerTt.Where(i=>i.Id==13).ToListAsync();
                var currencyList = await _context.TblCurrencyMaster.ToListAsync();
                var salemanList = await _context.TblUserMaster.ToListAsync();
                var customerList = await _context.TblCustomerMaster.ToListAsync();
                var banklist = await _context.TblBank.ToListAsync();

                var items = (from tt in ttList select new {
                    ttstatus = tt.Ttstatus,
                    customername = customerList.Where(i => i.Id == tt.Customerid).FirstOrDefault().CustomerName,
                    customercode = customerList.Where(i => i.Id == tt.Customerid).FirstOrDefault().CustomerCode,
                    bankreferance = "bank reference",
                    receivedbankname = banklist.Where(i => i.Id == tt.ReceivedBankId).FirstOrDefault().Name,
                    date = tt.RecordDate,
                    remmiterbankname = tt.RemmiterBankName,
                    remmitername = tt.RemmiterName,
                    currency = currencyList.Where(i => i.Id == tt.CurrencyId).FirstOrDefault().Name,
                    amount = tt.Amount,
                    bankcharges = tt.BankCharges,
                    totalttamount = tt.ToatalAmount,
                    confirmby = tt.ComfirmBy,
                    ttremark = tt.Remarks,
                    transferamount = tt.TransferAmount,
                    transferbankcharges = tt.BankCharges,
                    refundamount = tt.RefundAmount,
                    refundbankcharges = tt.RefundBankCharge,
                    receivedamount = tt.ReceviedAmount,
                    receivedremarks=tt.ReceviedRemarks,
                    transferremarks=tt.TransferRemarks,
                    refundremarks=tt.RefundRemarks,
                    updatedate=tt.UpdateDate

                }).ToList();
                var ApiResponse = await response.ApiResult("OK", items, "Record Found");

                return ApiResponse;
            }
            catch(Exception ex){
                var ApiResponseCatch = await response.ApiResult("OK", "", ex.ToString());

                return ApiResponseCatch;
            }
        }
        // GET: api/TelegraphicTransfer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCustomerTt>> GetTblCustomerTt(long id)
        {
            var tblCustomerTt = await _context.TblCustomerTt.FindAsync(id);

            if (tblCustomerTt == null)
            {
                return NotFound();
            }

            return tblCustomerTt;
        }

        // PUT: api/TelegraphicTransfer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCustomerTt(long id, TblCustomerTt tblCustomerTt)
        {
            if (id != tblCustomerTt.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCustomerTt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCustomerTtExists(id))
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

        // POST: api/TelegraphicTransfer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblCustomerTt>> PostTblCustomerTt(TblCustomerTt tblCustomerTt)
        {
            _context.TblCustomerTt.Add(tblCustomerTt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCustomerTt", new { id = tblCustomerTt.Id }, tblCustomerTt);
        }

        // DELETE: api/TelegraphicTransfer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblCustomerTt>> DeleteTblCustomerTt(long id)
        {
            var tblCustomerTt = await _context.TblCustomerTt.FindAsync(id);
            if (tblCustomerTt == null)
            {
                return NotFound();
            }

            _context.TblCustomerTt.Remove(tblCustomerTt);
            await _context.SaveChangesAsync();

            return tblCustomerTt;
        }

        private bool TblCustomerTtExists(long id)
        {
            return _context.TblCustomerTt.Any(e => e.Id == id);
        }
    }
}
