using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jtcinstallment.Api.Entity;
using jtcinstallment.Api.Models;
using Newtonsoft.Json;

namespace jtcinstallment.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public CompanyController(jtc_installmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ApiResponse> AllCompany()
        {
            var items = await _context.TblCompany.OrderByDescending(i=>i.Id).ToListAsync();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");

            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> AddCompany(TblCompany tblcompany)
        {
            var headd = Request.Headers["Auth"];
            _context.TblCompany.Add(tblcompany);
            await _context.SaveChangesAsync();
            
            var ApiResponse = await response.ApiResult("OK", tblcompany.Id, "Record Add");
            return ApiResponse;
            // return CreatedAtAction("GetTblStock", new { id = tblStock.Id }, tblStock);
        }
        [HttpPost]
        public async Task<ApiResponse> GetCompanyById(TblCompany tblcompany)
        {
            var items = await _context.TblCompany.FindAsync(tblcompany.Id);
           
            var ApiResponse = await response.ApiResult("OK", items, "Record Add");
            return ApiResponse;
            // return CreatedAtAction("GetTblStock", new { id = tblStock.Id }, tblStock);
        }
        // GET: api/Company
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCompany>>> GetTblCompany()
        {
            return await _context.TblCompany.ToListAsync();
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCompany>> GetTblCompany(long id)
        {
            var tblCompany = await _context.TblCompany.FindAsync(id);

            if (tblCompany == null)
            {
                return NotFound();
            }

            return tblCompany;
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCompany(long id, TblCompany tblCompany)
        {
            if (id != tblCompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCompanyExists(id))
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
        [HttpPost]
        public async Task<ApiResponse> UpdateCompany(TblCompany tblCompany)
        {
            _context.Entry(tblCompany).State = EntityState.Modified;
            _context.Entry(tblCompany).Property(x => x.RecordDate).IsModified = false;
           

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var ApiResponseCatch = await response.ApiResult("FAILED", ex, "Company Not Found");
                return ApiResponseCatch;
            }

            var ApiResponse = await response.ApiResult("OK", tblCompany, "Record Update");
            return ApiResponse;
        }
        // POST: api/Company
        [HttpPost]
        public async Task<ActionResult<TblCompany>> PostTblCompany(TblCompany tblCompany)
        {
            _context.TblCompany.Add(tblCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCompany", new { id = tblCompany.Id }, tblCompany);
        }

        // DELETE: api/Company/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblCompany>> DeleteTblCompany(long id)
        {
            var tblCompany = await _context.TblCompany.FindAsync(id);
            if (tblCompany == null)
            {
                return NotFound();
            }

            _context.TblCompany.Remove(tblCompany);
            await _context.SaveChangesAsync();

            return tblCompany;
        }

        private bool TblCompanyExists(long id)
        {
            return _context.TblCompany.Any(e => e.Id == id);
        }
    }
}
