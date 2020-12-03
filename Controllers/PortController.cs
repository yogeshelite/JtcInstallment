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
    public class PortController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public PortController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Port
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPortMaster>>> GetTblPortMaster()
        {
            return await _context.TblPortMaster.ToListAsync();
        }
        // GET: api/Port
        [HttpGet]
        public async Task<ApiResponse> AllPort()
        {
            var items= await _context.TblPortMaster.OrderBy(i=>i.PortName).ToListAsync();
            var ApiResponse = await response.ApiResult("OK", items, "Data Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> AllPortCountryWise(TblPortMaster tblPort)
        {
           // var items = await _context.TblPortMaster.Where(i=>i.CountryId==tblPort.CountryId).OrderBy(i => i.PortName).ToListAsync();
            var items = await _context.TblPortMaster.ToListAsync();
            var ApiResponse = await response.ApiResult("OK", items, "Data Found");
            return ApiResponse;
        }
        [HttpGet]
        public async Task<ApiResponse> AllPortAgentList()
        {
            var listPort = await _context.TblPortMaster.ToListAsync();
            var listcountry = await _context.TblCountryMaster.ToListAsync();
            var listPortAgent = await _context.TblPortAgent.ToListAsync();
            var listAgentName = await _context.TblAgentMaster.ToListAsync();
            var AgentItem = (from pa in listPortAgent
                             join an in listAgentName on pa.AgentId equals an.Id
                             select new {id=an.Id,agentName=an.AgentName ,portId=pa.PortId}).ToList();
            var portItem = (from lp in listPort
                            join lc in listcountry on lp.CountryId equals lc.Id
                            select new {id=lp.Id,
                                portName=lp.PortName,
                            countryId=lp.CountryId,
                            countryName=lc.CountryName,
                            agents= AgentItem.Where(i=>i.portId==lp.Id)
                            }).ToList();
            var ApiResponse = await response.ApiResult("OK", portItem, "Data Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> GetPortById(TblPortMaster tblObj)
        {
            var listPort = await _context.TblPortMaster.ToListAsync();
            var listcountry = await _context.TblCountryMaster.ToListAsync();
            var listPortAgent = await _context.TblPortAgent.ToListAsync();
            var listAgentName = await _context.TblAgentMaster.ToListAsync();
            var AgentItem = (from pa in listPortAgent
                             join an in listAgentName on pa.AgentId equals an.Id
                             select new { id = an.Id, agentName = an.AgentName, portId = pa.PortId }).ToList();
            var portItem = (from lp in listPort
                            join lc in listcountry on lp.CountryId equals lc.Id
                            select new
                            {
                                id = lp.Id,
                                portName = lp.PortName,
                                countryId = lp.CountryId,
                                countryName = lc.CountryName,
                                agents = AgentItem.Where(i => i.portId == lp.Id)
                            }).Where(i=>i.id==tblObj.Id).ToList();
            var ApiResponse = await response.ApiResult("OK", portItem, "Data Found");
            return ApiResponse;
        }
        // GET: api/Port/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPortMaster>> GetTblPortMaster(long id)
        {
            var tblPortMaster = await _context.TblPortMaster.FindAsync(id);

            if (tblPortMaster == null)
            {
                return NotFound();
            }

            return tblPortMaster;
        }
        [HttpPost]
        public async Task<ApiResponse> updatePort( TblPortMaster tblPortMaster)
        {
            
            _context.Entry(tblPortMaster).State = EntityState.Modified;
            _context.Entry(tblPortMaster).Property(i=>i.RecordDate).IsModified =false;

            try
            {
                await _context.SaveChangesAsync();
                var listPortAgent = await  _context.TblPortAgent.Where(i=>i.PortId==tblPortMaster.Id).ToListAsync();
               
                _context.TblPortAgent.RemoveRange(listPortAgent);
                await _context.SaveChangesAsync();
                for (int i = 0; i < tblPortMaster.AgentArray.Length; i++)
                {
                    TblPortAgent obj = new TblPortAgent();
                    obj.AgentId = tblPortMaster.AgentArray[i];
                    obj.PortId = tblPortMaster.Id;
                    _context.TblPortAgent.Add(obj);
                    await _context.SaveChangesAsync();
                }
                var ApiResponse = await response.ApiResult("OK", "", "Port Update");
                return ApiResponse;

            }
            catch (DbUpdateConcurrencyException)
            {
                var ApiResponseError = await response.ApiResult("OK", "", "Port Update");
                return ApiResponseError;
            }

                    
                         }
        // PUT: api/Port/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPortMaster(long id, TblPortMaster tblPortMaster)
        {
            if (id != tblPortMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblPortMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPortMasterExists(id))
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

        // POST: api/Port
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblPortMaster>> PostTblPortMaster(TblPortMaster tblPortMaster)
        {
            _context.TblPortMaster.Add(tblPortMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPortMaster", new { id = tblPortMaster.Id }, tblPortMaster);
        }
        [HttpPost]
        public async Task<ApiResponse> AddPort(TblPortMaster tblPortMaster)
        {
            _context.TblPortMaster.Add(tblPortMaster);
            await _context.SaveChangesAsync();
            for (int i = 0; i < tblPortMaster.AgentArray.Length; i++)
            {
                TblPortAgent obj = new TblPortAgent();
                obj.AgentId = tblPortMaster.AgentArray[i];
                obj.PortId = tblPortMaster.Id;
                _context.TblPortAgent.Add(obj);
                await _context.SaveChangesAsync();
            }
            var ApiResponse = await response.ApiResult("OK", "", "Add Port");
            return ApiResponse;
        }

        // DELETE: api/Port/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblPortMaster>> DeleteTblPortMaster(long id)
        {
            var tblPortMaster = await _context.TblPortMaster.FindAsync(id);
            if (tblPortMaster == null)
            {
                return NotFound();
            }

            _context.TblPortMaster.Remove(tblPortMaster);
            await _context.SaveChangesAsync();

            return tblPortMaster;
        }

        private bool TblPortMasterExists(long id)
        {
            return _context.TblPortMaster.Any(e => e.Id == id);
        }
    }
}
