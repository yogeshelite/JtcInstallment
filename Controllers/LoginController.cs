using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jtcinstallment.Api.Entity;
using jtcinstallment.Api.Models;

namespace jtcinstallment.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public LoginController(jtc_installmentContext context)
        {
            _context = context;
        }


        // POST: api/Login
        [HttpPost]
        public async Task<ApiResponse> Login(TblUserMaster objuser)
        {

          var loginDetail=  await _context.TblUserMaster.Where(i=>i.Email==objuser.Email &&i.Password==objuser.Password && i.Active==true && i.DeleteStatus==null).ToListAsync();
            if (loginDetail.Count == 1)
            {
                var listGroupMaster = await _context.TblGroupMaster.ToListAsync();
                var items = (from lu in loginDetail join lg in listGroupMaster on lu.UserTypeId equals lg.Id
                             select new { 
                             emailId=lu.Email,
                             userId=lu.Id,
                             userName=lu.UserName,
                             userTypeName=lg.GroupName,
                             userTypeId=lu.UserTypeId
                             })
                    .ToList();
                var ApiResponse = await response.ApiResult("OK", items, "Data Found");
                return ApiResponse;
            }
            else {
                var ApiResponse = await response.ApiResult("OK", "", "Email/Password Wrong");
                return ApiResponse;
            }
        }

        // GET: api/Login
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUserMaster>>> GetTblUserMaster()
        {
            return await _context.TblUserMaster.ToListAsync();
        }

        // GET: api/Login/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblUserMaster>> GetTblUserMaster(long id)
        {
            var tblUserMaster = await _context.TblUserMaster.FindAsync(id);

            if (tblUserMaster == null)
            {
                return NotFound();
            }

            return tblUserMaster;
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUserMaster(long id, TblUserMaster tblUserMaster)
        {
            if (id != tblUserMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblUserMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUserMasterExists(id))
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

        // POST: api/Login
        [HttpPost]
        public async Task<ActionResult<TblUserMaster>> PostTblUserMaster(TblUserMaster tblUserMaster)
        {
            _context.TblUserMaster.Add(tblUserMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblUserMaster", new { id = tblUserMaster.Id }, tblUserMaster);
        }

        // DELETE: api/Login/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblUserMaster>> DeleteTblUserMaster(long id)
        {
            var tblUserMaster = await _context.TblUserMaster.FindAsync(id);
            if (tblUserMaster == null)
            {
                return NotFound();
            }

            _context.TblUserMaster.Remove(tblUserMaster);
            await _context.SaveChangesAsync();

            return tblUserMaster;
        }

        private bool TblUserMasterExists(long id)
        {
            return _context.TblUserMaster.Any(e => e.Id == id);
        }
    }
}
