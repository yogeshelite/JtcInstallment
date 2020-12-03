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
    public class CurrencyController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public CurrencyController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Currency
        [HttpGet]
        public async Task<ApiResponse> GetAllCurrency()
        {
            var listCurrency = await _context.TblCurrencyMaster.ToListAsync();
            var ApiResponse = await response.ApiResult("OK", listCurrency, "Record Found");
            return ApiResponse;
        }
        [HttpGet]
        public async Task<ApiResponse> CountryWiseCurrency()
        {
            var countrylist = await _context.TblCountryMaster.ToListAsync();
            var listCurrency = await _context.TblCurrencyMaster.ToListAsync();
            var items = (from lcu in listCurrency
                         join cl in countrylist on lcu.CountryId equals cl.Id
                         select new
                         {
                             id = lcu.Id,
                             countryname = cl.CountryName,
                             currencyname = lcu.Name,
                             defaultInspectionFee = cl.DefaultInspectionFee,
                             defaultAuctionFee = cl.DefaultAuctionFee,
                             defaultRecycleFee = cl.DefaultRecycleFee,
                             defaultRepairFee = cl.DefaultRepairFee,
                             defaultTransportationFee = cl.DefaultTransportationFee,
                             defaultInspectionValidInMonth = cl.DefaultInspectionValidInMonth,
                             defaultTax = cl.DefaultTax,
                             defaultCIF = cl.DefaultCif,
                             dollerExchangeValue = lcu.DollerExchangeValue,
                             yenExchangeValue = lcu.YenExchangeValue,
                             KenyanShillingExchangeValue = lcu.KenyanShillingExchangeValue
                         }).OrderBy(i => i.countryname).ToList();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }

        // GET: api/Currency/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCurrencyMaster>> GetTblCurrencyMaster(long id)
        {
            var tblCurrencyMaster = await _context.TblCurrencyMaster.FindAsync(id);

            if (tblCurrencyMaster == null)
            {
                return NotFound();
            }

            return tblCurrencyMaster;
        }

        // PUT: api/Currency/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCurrencyMaster(long id, TblCurrencyMaster tblCurrencyMaster)
        {
            if (id != tblCurrencyMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCurrencyMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCurrencyMasterExists(id))
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

        // POST: api/Currency
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblCurrencyMaster>> PostTblCurrencyMaster(TblCurrencyMaster tblCurrencyMaster)
        {
            _context.TblCurrencyMaster.Add(tblCurrencyMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCurrencyMaster", new { id = tblCurrencyMaster.Id }, tblCurrencyMaster);
        }

        // DELETE: api/Currency/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblCurrencyMaster>> DeleteTblCurrencyMaster(long id)
        {
            var tblCurrencyMaster = await _context.TblCurrencyMaster.FindAsync(id);
            if (tblCurrencyMaster == null)
            {
                return NotFound();
            }

            _context.TblCurrencyMaster.Remove(tblCurrencyMaster);
            await _context.SaveChangesAsync();

            return tblCurrencyMaster;
        }

        private bool TblCurrencyMasterExists(long id)
        {
            return _context.TblCurrencyMaster.Any(e => e.Id == id);
        }
    }
}
