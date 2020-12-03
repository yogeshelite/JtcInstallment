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

namespace jtccarsales.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public ProductController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ApiResponse> AllProduct()
        {
            var categoryList = await _context.TblCategoryMaster.ToListAsync();
            var varientname = categoryList.Where(i => i.Type == "Variant").Select(i => i.CategoryType).FirstOrDefault();
            var productList = await _context.TblProduct.ToListAsync();

            var items = (from pl in productList
                         select new
                         {
                             prodictid = pl.Id,
                             productType = pl.ProductType,
                             typeid = pl.Typeid,
                             modelid = pl.ModelId,
                             makerid = pl.MakerId,
                             chassisType = pl.ChassisType,
                             drive = pl.Drive,
                             fule = pl.Fuel,
                             noOfDoor = pl.NoOfDoors,
                             noOfSeat = pl.NoOfSeats,
                             engine_cc = pl.EngineCc,
                             makername = categoryList.Where(i => i.Id == pl.MakerId).Select(i => i.CategoryType).FirstOrDefault() != null ? categoryList.Where(i => i.Id == pl.MakerId).Select(i => i.CategoryType).FirstOrDefault() : "N/A"
,
                             modelname = categoryList.Where(i => i.Id == pl.ModelId && i.Type == "ModelMaster").Select(i => i.CategoryType).FirstOrDefault() != null ? categoryList.Where(i => i.Id == pl.ModelId && i.Type == "ModelMaster").Select(i => i.CategoryType).FirstOrDefault() : "N/A"
,
                             type = categoryList.Where(i => i.Id == pl.Typeid && i.Type == "TypeMaster").Select(i => i.CategoryType).FirstOrDefault() != null ? categoryList.Where(i => i.Id == pl.Typeid && i.Type == "TypeMaster").Select(i => i.CategoryType).FirstOrDefault() : "N/A"
,
                             variant = categoryList.Where(i => i.Id == pl.VariantId && i.Type == "Variant").Select(i => i.CategoryType).FirstOrDefault() != null ? categoryList.Where(i => i.Id == pl.VariantId && i.Type == "Variant").Select(i => i.CategoryType).FirstOrDefault() : "N/A"

                         }).OrderBy(i => i.makername).ToList();
            var ApiResponse = await response.ApiResult("OK", items, "Product Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> ProductById(TblProduct objproduct)
        {

            var categoryList = await _context.TblCategoryMaster.ToListAsync();

            var varientname = categoryList.Where(i => i.Type == "Variant").Select(i => i.CategoryType).FirstOrDefault();
            var productList = await _context.TblProduct.ToListAsync();
            var colorlist = await _context.TblColor.ToListAsync();
            var items = (from pl in productList
                         select new
                         {
                             prodictid = pl.Id,
                             productType = pl.ProductType,
                             typeid = pl.Typeid,
                             modelid = pl.ModelId,
                             makerid = pl.MakerId,
                             variantid = pl.VariantId,
                             makername = categoryList.Where(i => i.Id == pl.MakerId).Select(i => i.CategoryType).FirstOrDefault() != null ? "N/A" : categoryList.Where(i => i.Id == pl.MakerId).Select(i => i.CategoryType).FirstOrDefault(),
                             modelname = categoryList.Where(i => i.Id == pl.ModelId && i.Type == "ModelMaster").Select(i => i.CategoryType).FirstOrDefault() != null ? "N/A" : categoryList.Where(i => i.Id == pl.ModelId && i.Type == "ModelMaster").Select(i => i.CategoryType).FirstOrDefault(),
                             type = categoryList.Where(i => i.Id == pl.Typeid && i.Type == "TypeMaster").Select(i => i.CategoryType).FirstOrDefault() != null ? "N/A" : categoryList.Where(i => i.Id == pl.Typeid && i.Type == "TypeMaster").Select(i => i.CategoryType).FirstOrDefault(),
                             variant = categoryList.Where(i => i.Id == pl.VariantId && i.Type == "Variant").Select(i => i.CategoryType).FirstOrDefault() != null ? "N/A" : categoryList.Where(i => i.Id == pl.VariantId && i.Type == "Variant").Select(i => i.CategoryType).FirstOrDefault(),
                             noofsheats = pl.NoOfSeats,
                             noofdoor = pl.NoOfDoors,
                             fuel = pl.Fuel,
                             drive = pl.Drive,
                             chassisType = pl.ChassisType,
                             engine_cc = pl.EngineCc
                         }).Where(i => i.prodictid == objproduct.Id).OrderBy(i => i.makername).ToList();
            var ApiResponse = await response.ApiResult("OK", items, "Product Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> addProduct(TblProduct tblProduct)
        {
            _context.TblProduct.Add(tblProduct);
            await _context.SaveChangesAsync();

            var ApiResponse = await response.ApiResult("OK", new { id = tblProduct.Id }, "Add Product Successfull");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> UpdateProduct(TblProduct tblProduct)
        {

            _context.Entry(tblProduct).State = EntityState.Modified;
            _context.Entry(tblProduct).Property(i => i.RecordDate).IsModified = false;
            try
            {
                await _context.SaveChangesAsync();
                var ApiResponse = await response.ApiResult("OK", new { id = tblProduct.Id }, "Update Product Successfull");
                return ApiResponse;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var ApiResponse = await response.ApiResult("FAILED", new { id = tblProduct.Id }, "Error in update product");
                return ApiResponse;
            }


        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProduct>>> GetTblProduct()
        {
            return await _context.TblProduct.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblProduct>> GetTblProduct(long id)
        {
            var tblProduct = await _context.TblProduct.FindAsync(id);

            if (tblProduct == null)
            {
                return NotFound();
            }

            return tblProduct;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProduct(long id, TblProduct tblProduct)
        {
            if (id != tblProduct.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProductExists(id))
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

        // POST: api/Product
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TblProduct>> PostTblProduct(TblProduct tblProduct)
        {
            _context.TblProduct.Add(tblProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblProduct", new { id = tblProduct.Id }, tblProduct);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblProduct>> DeleteTblProduct(long id)
        {
            var tblProduct = await _context.TblProduct.FindAsync(id);
            if (tblProduct == null)
            {
                return NotFound();
            }

            _context.TblProduct.Remove(tblProduct);
            await _context.SaveChangesAsync();

            return tblProduct;
        }

        private bool TblProductExists(long id)
        {
            return _context.TblProduct.Any(e => e.Id == id);
        }
    }
}
