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
    public class AttributeController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public AttributeController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Attribute
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAttribute>>> GetTblAttribute()
        {
            return await _context.TblAttribute.ToListAsync();
        }
        [HttpGet]
        public async Task<ApiResponse> AllAttribute()
        {
            //var items= await _context.TblAttribute.Where(i=>i.Type.Trim()== "Feature" && i.DeleteDate == null).OrderBy(i=>i.Name).ToListAsync();
            //  var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            //  return ApiResponse;
            var ApiResponse = await GetAllProduct();
            return ApiResponse;
        }

        // GET: api/Attribute/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAttribute>> GetTblAttribute(long id)
        {
            var tblAttribute = await _context.TblAttribute.FindAsync(id);

            if (tblAttribute == null)
            {
                return NotFound();
            }

            return tblAttribute;
        }

        // PUT: api/Attribute/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAttribute(long id, TblAttribute tblAttribute)
        {
            if (id != tblAttribute.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblAttribute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAttributeExists(id))
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

        // POST: api/Attribute
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ApiResponse> AddAttribute(TblAttribute tblAttribute)
        {
            try
            {
                _context.TblAttribute.Add(tblAttribute);
                await _context.SaveChangesAsync();
                var ApiResponse = await GetAllProduct();
                return ApiResponse;
            }
            catch (Exception ex)
            {
                var ApiResponse = await response.ApiResult("FAILED", ex, "Error Data Insert");
                  return ApiResponse;
            }
            // return CreatedAtAction("GetTblAttribute", new { id = tblAttribute.Id }, tblAttribute);
        }
        [HttpPost]
        public async Task<ApiResponse> UpdateAttribute(TblAttribute  obj)
        {

            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property(x => x.RecordDate).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
                
                var ApiResponse = await GetAllProduct();
                return ApiResponse;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var ApiResponse = await response.ApiResult("FALIED", ex, "Erro In Update ");
                return ApiResponse;
            }


        }

        [HttpPost]
        public async Task<ApiResponse> AttributeById(TblAttribute obj)
        {
            var AttributeList = await _context.TblAttribute.FindAsync(obj.Id);
            var ApiResponse = await response.ApiResult("OK", AttributeList, "Record Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> DeleteAttribute(TblAttribute obj)
        {
            //var tblCustomerMaster = await _context.TblCustomerMaster.FindAsync(tblCustomer.Id);
            _context.Entry(obj).Property(x => x.DeleteDate).IsModified = true;

            try
            {
                var response = await _context.SaveChangesAsync();

                var ApiResponse = await GetAllProduct();
                return ApiResponse;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var ApiResponse = await response.ApiResult("FALIED", ex, "Erro In Update ");
                return ApiResponse;
            }

        }
        [HttpPost]
        public async Task<ApiResponse> EnableDisableAttribute(TblAttribute obj)
        {
            //var tblCustomerMaster = await _context.TblCustomerMaster.FindAsync(tblCustomer.Id);
            //_context.Entry(obj).Property(x => x.status).IsModified = true;

            //try
            //{
            //    var response = await _context.SaveChangesAsync();

            //    var ApiResponse = await GetAllProduct();
            //    return ApiResponse;
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    var ApiResponse = await response.ApiResult("FALIED", ex, "Erro In Update ");
            //    return ApiResponse;
            //}
            var ApiResponse = await response.ApiResult("FALIED", "", "No OPeration  ");
                return ApiResponse;

        }

        // DELETE: api/Attribute/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblAttribute>> DeleteTblAttribute(long id)
        {
            var tblAttribute = await _context.TblAttribute.FindAsync(id);
            if (tblAttribute == null)
            {
                return NotFound();
            }

            _context.TblAttribute.Remove(tblAttribute);
            await _context.SaveChangesAsync();

            return tblAttribute;
        }

        private bool TblAttributeExists(long id)
        {
            return _context.TblAttribute.Any(e => e.Id == id);
        }
        private async Task<ApiResponse> GetAllProduct()
        {
            var items = await _context.TblAttribute.Where(i => i.Type.Trim() == "Feature" && i.DeleteDate == null).OrderBy(i => i.Name).ToListAsync();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }
    }
}
