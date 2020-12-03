using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jtcinstallment.Api.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using jtcinstallment.Api.Models;
using System.Collections;

namespace jtccarsales.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public StockController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Stock
        [HttpGet]
        public async Task<ApiResponse> AllStock()
        {
           var items =await _context.TblStock.ToListAsync();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");

            return ApiResponse;
        }

        // GET: api/Stock/5
        [HttpPost]
        public async Task<ApiResponse> GetTblStock(TblStock tblStockobj)
        {
            var tblStock = await _context.TblStock.FindAsync(tblStockobj.Id);

            var ApiResponse = await response.ApiResult("OK", tblStock, "Record Found");
            return ApiResponse;
        }

        // PUT: api/Stock/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblStock(long id, TblStock tblStock)
        {
            if (id != tblStock.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblStock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblStockExists(id))
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

        // POST: api/Stock
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ApiResponse> AddStock(TblStock tblStock)
        {
            var headd = Request.Headers["Auth"];
            _context.TblStock.Add(tblStock);
            await _context.SaveChangesAsync();
            var currentmonthShort = DateTime.Now.ToString("MMM-dd");
            var stockNumber = currentmonthShort+ "-"+String.Format("{0:D4}", tblStock.Id);
            tblStock.StockNumber = stockNumber;
            _context.Entry(tblStock).Property(x => x.StockNumber).IsModified = true;
            await _context.SaveChangesAsync();
            var ApiResponse = await response.ApiResult("OK", tblStock.Id, "Record Add");
            return ApiResponse;
            // return CreatedAtAction("GetTblStock", new { id = tblStock.Id }, tblStock);
        }
        [HttpPost]
        public async Task<ApiResponse> ImportStock(TblStock tblStock)
        {
            /// Sample Code 
           // [NotMapped]
            //public object StockImportDetail { get; set; }
            ///
            List<TblStock> ListStockImportDetail = JsonConvert.DeserializeObject<List<TblStock>>(tblStock.StockImportDetail.ToString());
            var DuplicateID = "";
            var currentStockID = "";
            try
            {
                var headd = Request.Headers["Auth"];
                for (int i = 0; i < ListStockImportDetail.Count; i++)
                {
                    currentStockID = "";
                    try
                    {
                        currentStockID = ListStockImportDetail[i].StockNumber;
                        var existingCount = _context.TblStock.Count(a => a.StockNumber == currentStockID);
                        if (existingCount == 0)
                        {
                            _context.TblStock.Add(ListStockImportDetail[i]);

                            await _context.SaveChangesAsync();
                        }
                        else {
                            DuplicateID += currentStockID + ",";
                        }
                        
                      
                        //ListStockImportDetail[i].StockNumber = tblStock.Id.ToString();
                        //_context.Entry(ListStockImportDetail[i]).Property(x => x.StockNumber).IsModified = true;
                        //await _context.SaveChangesAsync();
                    }
                    catch (Exception ex) {
                       
                        //continue; 
                    }
                }
                if (DuplicateID != null && DuplicateID!="")
                {
                    var ApiResponse = await response.ApiResult("FAILED", DuplicateID, "Record Import");
                    return ApiResponse;
                }
                else
                {
                    var ApiResponse = await response.ApiResult("OK", DuplicateID, "Record Import");
                    return ApiResponse;
                }
                //  _context.TblStock.Add(tblStock);
                //await _context.SaveChangesAsync();

                //var ApiResponse = await response.ApiResult("OK", DuplicateID, "Record Import");
                //return ApiResponse;
            }
            catch (Exception ex) {
                //DuplicateID += currentStockID + ",";
                var ApiResponseExp = await response.ApiResult("FAILED", ex.ToString(), "Record Import");
                return ApiResponseExp;

            }
           
            // return CreatedAtAction("GetTblStock", new { id = tblStock.Id }, tblStock);
        }
        [HttpPost]
        public async Task<ApiResponse> UpdateStock(TblStock tblStock)
        {
            _context.Entry(tblStock).State = EntityState.Modified;
            _context.Entry(tblStock).Property(x => x.RecordDate).IsModified = false;
            _context.Entry(tblStock).Property(x => x.StockNumber).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var ApiResponseCatch = await response.ApiResult("FAILED", "", "Bank Not Found");
                return ApiResponseCatch;
            }

            var ApiResponse = await response.ApiResult("OK", tblStock, "Record Update");
            return ApiResponse;
        }
        /// <summary>
        ///Post Api For Search Stock Detail By stock number  
        /// </summary>
        /// <param name="tblStock"></param>
        /// <returns></returns>
        [HttpPost]
        //public async Task<ActionResult<IEnumerable<TblStock>>> GetStockByNumber(TblStock tblStock)
        //{
        //    var tblStockResult = await _context.TblStock.Where(i=>i.StockNumber==tblStock.StockNumber).ToListAsync();

        //    if (tblStock == null)
        //    {
        //        return NotFound();
        //    }

        //    return tblStockResult;
        //}
        public async Task<ApiResponse> GetStockByNumber(TblStock tblStock)
        {
            ApiResponse response = new ApiResponse();
            string message = "Record Not Found";
            try
            {
                List<TblStock> listStock = new List<TblStock>();
                if (tblStock.StockNumber != "")
                {
                    var stockArray = tblStock.StockNumber.Split(',');

                    for (int i = 0; i < stockArray.Length; i++)
                    {
                        var stocknumber = stockArray[i].ToString();

                        var listinvoice = await _context.TblInvoice.Where(j => j.StockNumber==stocknumber).ToListAsync();
                        if (listinvoice.Count == 0)
                        {
                            List<TblStock> tblStockResult = await _context.TblStock.Where(j => j.StockNumber==stocknumber).ToListAsync();
                            listStock.AddRange(tblStockResult);
                        }
                    }
                    if (listStock.Count == 0)
                    {
                        //message;
                    }
                    else
                    {
                        message = "Record Found";

                    }

                }
                var ApiResponse = await response.ApiResult("OK", listStock, message);
                return ApiResponse;
            }
            catch (Exception ex)
            {
                var ApiResponse = await response.ApiResult("FAILED", "", ex.ToString());
                return ApiResponse;
            }
        }
        // DELETE: api/Stock/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblStock>> DeleteTblStock(long id)
        {
            var tblStock = await _context.TblStock.FindAsync(id);
            if (tblStock == null)
            {
                return NotFound();
            }

            _context.TblStock.Remove(tblStock);
            await _context.SaveChangesAsync();

            return tblStock;
        }

        private bool TblStockExists(long id)
        {
            return _context.TblStock.Any(e => e.Id == id);
        }
    }
}
