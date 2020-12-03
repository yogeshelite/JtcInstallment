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
    public class VesselNamesController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public VesselNamesController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/VesselNames
        [HttpGet]
        public async Task<ApiResponse> AllVesselName()
        {
            var items = await _context.TblVesselName.ToListAsync();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }

        // GET: api/VesselNames/5
        //[HttpGet("{id}")]
        [HttpPost]
        public async Task<ApiResponse> GetVesselNameById(TblVesselName VesselName)
        {
            var tblVesselName = await _context.TblVesselName.FindAsync(VesselName.Id);

            var ApiResponse = await response.ApiResult("OK", tblVesselName, "Record Add");
            return ApiResponse;

        }

        // PUT: api/VesselNames/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ApiResponse> UpdateVesselName(long id, TblVesselName tblVesselName)
        {
            
            _context.Entry(tblVesselName).State = EntityState.Modified;
           
            try
            {
                await _context.SaveChangesAsync();
                var ApiResponse = await response.ApiResult("OK", "", "Record Add");
                return ApiResponse;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var ApiResponseError = await response.ApiResult("OK", ex, "Record Add");
                return ApiResponseError;
            }

            
        }

        // POST: api/VesselNames
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ApiResponse> AddVesselName(TblVesselName tblVesselName)
        {
            _context.TblVesselName.Add(tblVesselName);
            await _context.SaveChangesAsync();
            var ApiResponse = await response.ApiResult("OK", "", "Record Add");
            return ApiResponse;
           // return CreatedAtAction("GetTblVesselName", new { id = tblVesselName.Id }, tblVesselName);
        }

        // DELETE: api/VesselNames/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblVesselName>> DeleteTblVesselName(long id)
        {
            var tblVesselName = await _context.TblVesselName.FindAsync(id);
            if (tblVesselName == null)
            {
                return NotFound();
            }

            _context.TblVesselName.Remove(tblVesselName);
            await _context.SaveChangesAsync();

            return tblVesselName;
        }

        private bool TblVesselNameExists(long id)
        {
            return _context.TblVesselName.Any(e => e.Id == id);
        }
    }
}
