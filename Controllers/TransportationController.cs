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
    public class TransportationController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public TransportationController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Transportation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblTransportation>>> GetTblTransportation()
        {
            return await _context.TblTransportation.ToListAsync();
        }
        [HttpPost]
        public async Task<ApiResponse> TransportationByPortAuction(TblTransportation tbltransportation)
        {
            var companylist = await _context.TblCompany.Distinct().ToListAsync();
            var transportList= await _context.TblTransportation.Where(i=>i.SourceId==tbltransportation.SourceId && i.DesstinationId==tbltransportation.DesstinationId && i.TypeId==tbltransportation.TypeId).ToListAsync();
            var items = (from tl in transportList
                         select new
                         {
                             id = tl.Id,
                             name = companylist.Where(i => i.Id == tl.CompanyId).Select(i=>i.CompanyName).FirstOrDefault()
                         }).ToList();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }

        // GET: api/Transportation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblTransportation>> GetTblTransportation(long id)
        {
            var tblTransportation = await _context.TblTransportation.FindAsync(id);

            if (tblTransportation == null)
            {
                return NotFound();
            }

            return tblTransportation;
        }

        // PUT: api/Transportation/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTransportation(long id, TblTransportation tblTransportation)
        {
            if (id != tblTransportation.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblTransportation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTransportationExists(id))
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

        // POST: api/Transportation
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblTransportation>> PostTblTransportation(TblTransportation tblTransportation)
        {
            _context.TblTransportation.Add(tblTransportation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblTransportation", new { id = tblTransportation.Id }, tblTransportation);
        }

        // DELETE: api/Transportation/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblTransportation>> DeleteTblTransportation(long id)
        {
            var tblTransportation = await _context.TblTransportation.FindAsync(id);
            if (tblTransportation == null)
            {
                return NotFound();
            }

            _context.TblTransportation.Remove(tblTransportation);
            await _context.SaveChangesAsync();

            return tblTransportation;
        }

        private bool TblTransportationExists(long id)
        {
            return _context.TblTransportation.Any(e => e.Id == id);
        }
    }
}
