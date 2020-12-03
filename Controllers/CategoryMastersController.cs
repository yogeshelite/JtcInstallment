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
    public class CategoryMastersController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public CategoryMastersController(jtc_installmentContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AllCategory(TblCategoryMaster tblobj)
        {

            var items = await _context.TblCategoryMaster.Where(i => i.Type == tblobj.Type).ToListAsync();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AllModel(TblCategoryMaster tblobj)
        {
            var listmodel= await _context.TblCategoryMaster.ToListAsync();
            var listmodelInner= await _context.TblCategoryMaster.ToListAsync();
            var items = (from lm in listmodel
                        join lmi in listmodelInner on lm.Id equals lmi.ParentId
                        select new {id=lm.Id,makerName=lm.CategoryType,parentId=lm.ParentId,modelName=lmi.CategoryType,
                        type=lmi.Type,modelId=lmi.Id})
                        .Where(i => i.type == tblobj.Type).ToList();

            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddCategory(TblCategoryMaster tblCategoryMaster)
        {
            _context.TblCategoryMaster.Add(tblCategoryMaster);
            await _context.SaveChangesAsync();
            var ApiResponse = await response.ApiResult("OK", tblCategoryMaster.Id, " Add Record");
            return ApiResponse;
        }

        [HttpPost]
        public async Task<ApiResponse> UpdateCategory(TblCategoryMaster tblCategoryMaster)
        {
            _context.Entry(tblCategoryMaster).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                var ApiResponse = await response.ApiResult("OK", tblCategoryMaster.Id, " Update Record");
                return ApiResponse;
            }
            catch (DbUpdateConcurrencyException EX)
            {
                var ApiResponsError = await response.ApiResult("FAILED", EX, "Errro Updating");
                return ApiResponsError;
            }


        }

        // GET: api/CategoryMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCategoryMaster>>> GetTblCategoryMaster()
        {
            return await _context.TblCategoryMaster.ToListAsync();
        }

        // GET: api/CategoryMasters/5
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> GetCategoryById(TblCategoryMaster tblCategoryObj)
        {
            var tblCategoryMaster = await _context.TblCategoryMaster.FindAsync(tblCategoryObj.Id);

            var ApiResponse = await response.ApiResult("OK", tblCategoryMaster, " Add Record");
            return ApiResponse;
        }

        // PUT: api/CategoryMasters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCategoryMaster(long id, TblCategoryMaster tblCategoryMaster)
        {
            if (id != tblCategoryMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCategoryMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCategoryMasterExists(id))
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

        // POST: api/CategoryMasters
        [HttpPost]
        public async Task<ActionResult<TblCategoryMaster>> PostTblCategoryMaster(TblCategoryMaster tblCategoryMaster)
        {
            _context.TblCategoryMaster.Add(tblCategoryMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblCategoryMaster", new { id = tblCategoryMaster.Id }, tblCategoryMaster);
        }

        // DELETE: api/CategoryMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblCategoryMaster>> DeleteTblCategoryMaster(long id)
        {
            var tblCategoryMaster = await _context.TblCategoryMaster.FindAsync(id);
            if (tblCategoryMaster == null)
            {
                return NotFound();
            }

            _context.TblCategoryMaster.Remove(tblCategoryMaster);
            await _context.SaveChangesAsync();

            return tblCategoryMaster;
        }

        private bool TblCategoryMasterExists(long id)
        {
            return _context.TblCategoryMaster.Any(e => e.Id == id);
        }
    }
}
