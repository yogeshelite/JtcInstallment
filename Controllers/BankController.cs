using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jtcinstallment.Api.Entity;
using jtcinstallment.Api.Models;

namespace jtccarsales.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public BankController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Bank
        [HttpGet]
        public async Task<ApiResponse> AllBank()
        {
            var responsebank = await GetAllBanks();
            return responsebank;
        }

        // GET: api/Bank/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblBank>> GetTblBank(long id)
        {
            var tblBank = await _context.TblBank.FindAsync(id);

            if (tblBank == null)
            {
                return NotFound();
            }

            return tblBank;
        }

        // PUT: api/Bank/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblBank(long id, TblBank tblBank)
        {
            if (id != tblBank.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblBank).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblBankExists(id))
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

        // POST: api/Bank
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblBank>> PostTblBank(TblBank tblBank)
        {
            _context.TblBank.Add(tblBank);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblBank", new { id = tblBank.Id }, tblBank);
        }
        [HttpPost]
        public async Task<ApiResponse> AddBank(TblBank tblBank)
        {
            _context.TblBank.Add(tblBank);
            await _context.SaveChangesAsync();

            var response = await GetAllBanks();
            return response;
        }
        [HttpPost]
        public async Task<ApiResponse> UpdateBank(TblBank tblBank)
        {
            _context.Entry(tblBank).State = EntityState.Modified;
            _context.Entry(tblBank).Property(x => x.RecordDate).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var ApiResponse = await response.ApiResult("FAILED", "", "Bank Not Found");
                return ApiResponse;
            }

            var responseBank = await GetAllBanks();
            return responseBank;
        }
        [HttpPost]
        public async Task<ApiResponse> EnableDisableBank(TblBank tblBank)
        {
            TblBank _tblbank = new TblBank
            {
                Id = tblBank.Id,
                ForJtc = tblBank.ForJtc
            };
            _context.Entry(_tblbank).Property(x => x.ForJtc).IsModified = true;

            try
            {
                var respose = await _context.SaveChangesAsync();
                var responsebank = await GetAllBanks();
                return responsebank;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!TblBankExists(tblBank.Id))
                {
                    var ApiResponse = await response.ApiResult("FAILED", "", "Bank Not Found");
                    return ApiResponse;
                }
                else
                {
                    var ApiResponse = await response.ApiResult("FAILED", ex, "Bank Not Found");
                    return ApiResponse;
                }
            }



        }
        [HttpPost]
        public async Task<ApiResponse> BankById(TblBank tblBank)
        {
            var tblBankresponse = await _context.TblBank.FindAsync(tblBank.Id);

            if (tblBank == null)
            {
                var ApiResponseErr = await response.ApiResult("FAILED", "", "Bank Not Found");
                return ApiResponseErr;
            }

            var ApiResponse = await response.ApiResult("OK", tblBankresponse, "Bank Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> DeleteBank(TblBank tblBank)
        {
            // var _tblBank = await _context.TblBank.FindAsync(tblBank.Id);
            if (tblBank == null)
            {
                var ApiResponseErr = await response.ApiResult("FAILED", "", "Bank Not Found");
                return ApiResponseErr;
            }
            _context.Entry(tblBank).Property(x => x.DeleteDate).IsModified = true;
            try
            {
                var respose = await _context.SaveChangesAsync();
                var responsebank = await GetAllBanks();
                return responsebank;
            }
            catch (DbUpdateConcurrencyException ex)
            {

                var ApiResponse = await response.ApiResult("FAILED", ex, "Bank Not Found");
                return ApiResponse;

            }



        }
        // DELETE: api/Bank/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblBank>> DeleteTblBank(long id)
        {
            var tblBank = await _context.TblBank.FindAsync(id);
            if (tblBank == null)
            {
                return NotFound();
            }

            _context.TblBank.Remove(tblBank);
            await _context.SaveChangesAsync();

            return tblBank;
        }

        private bool TblBankExists(long id)
        {
            return _context.TblBank.Any(e => e.Id == id);
        }
        private async Task<ApiResponse> GetAllBanks()
        {
            var listCountry = await _context.TblCountryMaster.ToListAsync();
            var listbank = await _context.TblBank.ToListAsync();
            var items = (from lb in listbank
                         join lc in listCountry on lb.CountryId equals lc.Id
                         where lb.DeleteDate is null
                         select new
                         {
                             Id = lb.Id,
                             BankName = lb.Name,
                             Country = lc.CountryName,
                             Forjtc = lb.ForJtc
                         }).OrderByDescending(i => i.Id).ToList();

            // return await _context.TblBank.ToListAsync();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }
    }
}
