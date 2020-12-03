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
    public class CountryController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public CountryController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Country
        [HttpGet]
        public async Task<ApiResponse> AllCountry()
        {
            var listCountry = await _context.TblCountryMaster.OrderByDescending(i => i.Id).ToListAsync();
            var ApiResponse = await response.ApiResult("OK", listCountry, "Record Found");
            return ApiResponse;
        }

        // GET: api/Country/5
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> GetCountryByid(TblCountryMaster tblCountryMasterObj)
        {
            var item = await _context.TblCountryMaster.FindAsync(tblCountryMasterObj.Id);

            var ApiResponse = await response.ApiResult("OK", item, "Record Found");
            return ApiResponse;
        }

        // PUT: api/Country/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ApiResponse> updateCountry(TblCountryMaster tblCountryMaster)
        {
            if (tblCountryMaster.Id == 0)
            {
                var ApiResponse = await response.ApiResult("FAILED", "", "Error in Update");
                return ApiResponse;
            }
            _context.Entry(tblCountryMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                var ApiResponse = await response.ApiResult("OK", "", "update Record ");
                return ApiResponse;
            }
            catch (DbUpdateConcurrencyException)
            {
                var ApiResponse = await response.ApiResult("FAILED", "", "Error in UPdate");
                return ApiResponse;
            }


        }

        // POST: api/Country
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddCountry(TblCountryMaster tblCountryMaster)
        {
            _context.TblCountryMaster.Add(tblCountryMaster);
            await _context.SaveChangesAsync();
            var ApiResponse = await response.ApiResult("OK", tblCountryMaster.Id, "Record Add");
            return ApiResponse;
        }

        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblCountryMaster>> DeleteTblCountryMaster(long id)
        {
            var tblCountryMaster = await _context.TblCountryMaster.FindAsync(id);
            if (tblCountryMaster == null)
            {
                return NotFound();
            }

            _context.TblCountryMaster.Remove(tblCountryMaster);
            await _context.SaveChangesAsync();

            return tblCountryMaster;
        }

        private bool TblCountryMasterExists(long id)
        {
            return _context.TblCountryMaster.Any(e => e.Id == id);
        }
    }
}
