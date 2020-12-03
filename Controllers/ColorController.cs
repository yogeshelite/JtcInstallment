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
    public class ColorController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public ColorController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Color
        [HttpGet]
        public async Task<ApiResponse> AllColor()
        {
            var items = await _context.TblColor.ToListAsync();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> ColorById(TblColor tblcolor)
        {
            var items = await _context.TblColor.Where(i => i.Id == tblcolor.Id).ToListAsync();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }

        // GET: api/Color/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblColor>> GetTblColor(long id)
        {
            var tblColor = await _context.TblColor.FindAsync(id);

            if (tblColor == null)
            {
                return NotFound();
            }

            return tblColor;
        }

        // PUT: api/Color/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ApiResponse> updateColor(TblColor tblColor)
        {

            _context.Entry(tblColor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                var ApiResponse = await response.ApiResult("OK", new { id = tblColor.Id }, "Update Record");
                return ApiResponse;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var ApiResponse = await response.ApiResult("FAILED", new { error = ex }, "Error");
                return ApiResponse;
            }


        }

        // POST: api/Color
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ApiResponse> AddColor(TblColor tblColor)
        {
            _context.TblColor.Add(tblColor);
            await _context.SaveChangesAsync();
            var ApiResponse = await response.ApiResult("OK", new { id = tblColor.Id }, "Add Record");
            return ApiResponse;
        }

        // DELETE: api/Color/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblColor>> DeleteTblColor(long id)
        {
            var tblColor = await _context.TblColor.FindAsync(id);
            if (tblColor == null)
            {
                return NotFound();
            }

            _context.TblColor.Remove(tblColor);
            await _context.SaveChangesAsync();

            return tblColor;
        }

        private bool TblColorExists(long id)
        {
            return _context.TblColor.Any(e => e.Id == id);
        }
    }
}
