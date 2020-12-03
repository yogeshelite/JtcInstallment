using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jtcinstallment.Api.Entity;
using jtcinstallment.Api.Models;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Abstractions.Internal;

namespace jtccarsales.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class YardController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public YardController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Yard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblYard>>> GetTblYard()
        {
            return await _context.TblYard.ToListAsync();
        }
        // GET: api/Yard
        [HttpGet]
        public async Task<ApiResponse> AllYard()
        {
            var listYard = await _context.TblYard.OrderBy(i => i.Name).ToListAsync();
            //  var AgentIdlist = (from ld in listYard select new { ld.AgentId }).ToList();
            var agentlist = await _context.TblAgentMaster.ToListAsync();
            var portlist = await _context.TblPortMaster.ToListAsync();
            var items = (from lY in listYard
                         select new
                         {
                             id = lY.Id,
                             name = lY.Name,
                             numberOfFreeDay = lY.NumberOfFreeDay,
                             handlingChages = lY.HandlingChages,
                             radiationCharges = lY.RadiationCharges,
                             godownCharges = lY.GodownCharges,
                             otherCharges = lY.OtherCharges,
                             portlist = portlist.Where(i => ConvertStringToIntList(lY.PortId).Contains(Convert.ToInt32(i.Id))),
                             agentlist = agentlist.Where(i => ConvertStringToIntList(lY.AgentId).Contains(Convert.ToInt32(i.Id))),

                             portid = lY.PortId
                         }).ToList();


            var ApiResponse = await response.ApiResult("OK", items, "Data Found");
            return ApiResponse;
        }
        public List<Int32> ConvertStringToIntList(string stringAgentid)
        {
            List<int> listAgentid = new List<int>();

            if (stringAgentid != null)
            {
                string[] arryAgentid = stringAgentid.Split(',').ToArray();

                for (int i = 0; i < arryAgentid.Length; i++)
                {
                    listAgentid.Add(Convert.ToInt32(arryAgentid[i]));
                }
            }
            return listAgentid;
        }
        // GET: api/Yard/5
        [HttpPost]
        public async Task<ApiResponse> GetYardById(TblYard objyard)
        {
            var listYard = await _context.TblYard.Where(i => i.Id == objyard.Id).ToListAsync();
            var listYardlocation = await _context.TblYardLocation.Where(i => i.YardId == objyard.Id).ToListAsync();
            var items = (from ly in listYard
                         join lyl in listYardlocation on ly.Id equals lyl.YardId
                         select new
                         {
                             id = ly.Id,
                             name = ly.Name,
                             numberOfFreeDay = ly.NumberOfFreeDay,
                             agentId = ly.AgentId,
                             portId = ly.PortId,
                             handlingChages = ly.HandlingChages,
                             radiationCharges = ly.RadiationCharges,
                             godownCharges = ly.GodownCharges,
                             otherCharges = ly.OtherCharges,
                             countryId = lyl.CountryId
                         }).ToList();
         

            var ApiResponse = await response.ApiResult("OK", items, "Data Found");
            return ApiResponse;
        }

        // PUT: api/Yard/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ApiResponse> UpdateYard(TblYard tblYard)
        {
            _context.Entry(tblYard).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                var tblYardlocation = await _context.TblYardLocation.Where(i => i.YardId == tblYard.Id).ToListAsync();

                _context.TblYardLocation.RemoveRange(tblYardlocation);
                await _context.SaveChangesAsync();
                TblYardLocation objYardLocation = new TblYardLocation();
                objYardLocation.YardId = tblYard.Id;
                objYardLocation.CountryId = tblYard.CountryId;
                objYardLocation.LocationDiscription = tblYard.LocationDescription;
                _context.TblYardLocation.Add(objYardLocation);
                await _context.SaveChangesAsync();
                var ApiResponse = await response.ApiResult("OK", tblYard, "Data Found");
                return ApiResponse;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var ApiResponse = await response.ApiResult("FAILED", ex, "Error in update");
                return ApiResponse;
            }


        }

        // POST: api/Yard
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ApiResponse> AddYard(TblYard tblYard)
        {
            _context.TblYard.Add(tblYard);
            await _context.SaveChangesAsync();
            TblYardLocation objYardLocation = new TblYardLocation();
            objYardLocation.YardId = tblYard.Id;
            objYardLocation.CountryId = tblYard.CountryId;
            objYardLocation.LocationDiscription = tblYard.LocationDescription;
            _context.TblYardLocation.Add(objYardLocation);
            await _context.SaveChangesAsync();
            var ApiResponse = await response.ApiResult("OK", new { id = tblYard.Id }, "Add Yard");
            return ApiResponse;
        }

        // DELETE: api/Yard/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblYard>> DeleteTblYard(long id)
        {
            var tblYard = await _context.TblYard.FindAsync(id);
            if (tblYard == null)
            {
                return NotFound();
            }

            _context.TblYard.Remove(tblYard);
            await _context.SaveChangesAsync();

            return tblYard;
        }

        private bool TblYardExists(long id)
        {
            return _context.TblYard.Any(e => e.Id == id);
        }
    }
}
