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
    public class AuctionController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public AuctionController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Auction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAuctionMaster>>> GetTblAuctionMaster()
        {
            return await _context.TblAuctionMaster.ToListAsync();
        }
        // GET: api/Auction
        [HttpGet]
        public async Task<ApiResponse> AllAuction()
        {
          var items= await _context.TblAuctionMaster.ToListAsync();
            var ApiResponse = await response.ApiResult("OK", items, "Data Found");
            return ApiResponse;
        }
        // GET: api/Auction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAuctionMaster>> GetTblAuctionMaster(long id)
        {
            var tblAuctionMaster = await _context.TblAuctionMaster.FindAsync(id);

            if (tblAuctionMaster == null)
            {
                return NotFound();
            }

            return tblAuctionMaster;
        }

        // PUT: api/Auction/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAuctionMaster(long id, TblAuctionMaster tblAuctionMaster)
        {
            if (id != tblAuctionMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblAuctionMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAuctionMasterExists(id))
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

        // POST: api/Auction
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblAuctionMaster>> PostTblAuctionMaster(TblAuctionMaster tblAuctionMaster)
        {
            _context.TblAuctionMaster.Add(tblAuctionMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblAuctionMaster", new { id = tblAuctionMaster.Id }, tblAuctionMaster);
        }

        // DELETE: api/Auction/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblAuctionMaster>> DeleteTblAuctionMaster(long id)
        {
            var tblAuctionMaster = await _context.TblAuctionMaster.FindAsync(id);
            if (tblAuctionMaster == null)
            {
                return NotFound();
            }

            _context.TblAuctionMaster.Remove(tblAuctionMaster);
            await _context.SaveChangesAsync();

            return tblAuctionMaster;
        }

        private bool TblAuctionMasterExists(long id)
        {
            return _context.TblAuctionMaster.Any(e => e.Id == id);
        }
    }
}
