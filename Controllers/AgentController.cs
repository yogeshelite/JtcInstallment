using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jtcinstallment.Api.Entity;
using jtcinstallment.Api.Models;
using System.Reflection.Emit;

namespace jtcinstallment.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public AgentController(jtc_installmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ApiResponse> AllAgent()
        {
            var listAgentMaster = await _context.TblAgentMaster.ToListAsync();
            var listCompany = await _context.TblCompany.ToListAsync();
            var items = (from lam in listAgentMaster
                        join lc in listCompany on lam.CompanyId equals lc.Id
                        select new { Id = lam.Id,
                            AgentName = lam.AgentName,
                            ContactPerson=lam.ContactPerson,
                            AgentAddress=lam.AgentAddress,
                            Fax=lam.Fax,
                            Phone=lam.Phone,
                            Telephone=lam.Telephone,
                            Email=lam.Email,
                            RecordDate=lam.RecordDate,
                            UpdateDate=lam.UpdateDate,
                            DeleteStatus=lam.DeleteStatus,
                            CompanyId=lam.CompanyId,
                            CompanyName=listCompany.Where(i=>i.Id==lam.CompanyId).FirstOrDefault().CompanyName
                        }
                        ).ToList();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");

            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> GetAgentById(TblAgentMaster objAgent)
        {
            var items =await _context.TblAgentMaster.FindAsync(objAgent.Id);
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");

            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> AddAgent(TblAgentMaster objAgent)
        {
            _context.TblAgentMaster.Add(objAgent);
            await _context.SaveChangesAsync();
            var ApiResponse = await response.ApiResult("OK", objAgent.Id, "Add Agent");
                        return ApiResponse;
        }

        [HttpPost]
        public async Task<ApiResponse> UpdateAgent(TblAgentMaster tblAgentMaster)
        {
            _context.Entry(tblAgentMaster).State = EntityState.Modified;
            _context.Entry(tblAgentMaster).Property(x => x.RecordDate).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var ApiResponseError = await response.ApiResult("FAILED", "", "Agent Error Found");
                return ApiResponseError;
            }

            var ApiResponse = await response.ApiResult("OK", tblAgentMaster.Id, "Update Agent");
            return ApiResponse;
        }
        // GET: api/Agent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAgentMaster>>> GetTblAgentMaster()
        {
            return await _context.TblAgentMaster.ToListAsync();
        }

        // GET: api/Agent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAgentMaster>> GetTblAgentMaster(long id)
        {
            var tblAgentMaster = await _context.TblAgentMaster.FindAsync(id);

            if (tblAgentMaster == null)
            {
                return NotFound();
            }

            return tblAgentMaster;
        }

        // PUT: api/Agent/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAgentMaster(long id, TblAgentMaster tblAgentMaster)
        {
            if (id != tblAgentMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblAgentMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAgentMasterExists(id))
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

        // POST: api/Agent
        [HttpPost]
        public async Task<ActionResult<TblAgentMaster>> PostTblAgentMaster(TblAgentMaster tblAgentMaster)
        {
            _context.TblAgentMaster.Add(tblAgentMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblAgentMaster", new { id = tblAgentMaster.Id }, tblAgentMaster);
        }

        // DELETE: api/Agent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblAgentMaster>> DeleteTblAgentMaster(long id)
        {
            var tblAgentMaster = await _context.TblAgentMaster.FindAsync(id);
            if (tblAgentMaster == null)
            {
                return NotFound();
            }

            _context.TblAgentMaster.Remove(tblAgentMaster);
            await _context.SaveChangesAsync();

            return tblAgentMaster;
        }

        private bool TblAgentMasterExists(long id)
        {
            return _context.TblAgentMaster.Any(e => e.Id == id);
        }
    }
}
