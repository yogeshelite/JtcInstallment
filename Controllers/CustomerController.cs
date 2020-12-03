using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jtcinstallment.Api.Entity;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Drawing;
using jtcinstallment.Api.Models;
using System.ComponentModel;
//using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Internal;

namespace jtccarsales.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public CustomerController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ApiResponse> AllCustomer()
        {
            try
            {
                var listcustomer = await _context.TblCustomerMaster.Where(i => i.DeleteStatus == null).OrderBy(i => i.CustomerName).ToListAsync();
                var ApiResponse = await response.ApiResult("OK", listcustomer, "Record Found");
                return ApiResponse;
            }
            catch (Exception ex)
            {
                var ApiResponseCatch = await response.ApiResult("OK", ex, "Error ");
                return ApiResponseCatch;
            }
        }
        // GET: api/Salesman
        [HttpGet]
        public async Task<ApiResponse> AllSalesman()
        {
            var listGroup = await _context.TblGroupMaster.ToListAsync();
            var listuser = await _context.TblUserMaster.ToListAsync();
            var item = (from lu in listuser
                        join lg in listGroup on lu.UserTypeId equals lg.Id
                        where lg.Id == 143
                        select new { id = lu.Id, name = lu.UserName }).ToList();
            var ApiResponse = await response.ApiResult("OK", item, "Record Found");
            return ApiResponse;
        }
        // Post: api/Customer/5
        [HttpPost]
        public async Task<ApiResponse> CustomerDetail(TblCustomerMaster tblCustomer)
        {
            var tblCustomerdata = await _context.TblCustomerMaster.FindAsync(tblCustomer.Id);

            var ApiResponse = await response.ApiResult("OK", tblCustomerdata, "Record Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> CustomerCanceledProduct(TblCustomerMaster tblCustomer)
        {

            var listStock = await _context.TblStock.ToListAsync();
            var listCurrency = await _context.TblCurrencyMaster.ToListAsync();
            var listInvoice = await _context.TblInvoice.Where(i => i.CustomerId.Equals(tblCustomer.Id)).ToListAsync();
            var listinvoiceHistory = await _context.TblInvoiceHistory.Where(i => i.CustomerId.Equals(tblCustomer.Id)).ToListAsync();
            var items = (from ls in listStock
                         join c in listCurrency on ls.CurrencyId equals c.Id
                         join li in listInvoice on ls.StockNumber equals li.StockNumber
                         join lih in listinvoiceHistory on li.StockNumber equals lih.StockNumber
                         where li.Status == "Cancel"
                         select new
                         {
                             Name = c.Name,
                             StockNumber = lih.StockNumber,
                             CancelDate = lih.CancelDate,
                             ChassisNumber = ls.ChassisNumber,
                             PaidAmount = lih.PaidAmount,
                             Comment = lih.Comment,
                             SalePrice = lih.SalePrice,
                             BalanceAmount = li.BalanceAmount
                         }).ToList();
            //var tblCustomerdata = await _context.TblCustomerMaster.FindAsync(tblCustomer.Id);

            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> ShippedProduct(TblCustomerMaster tblCustomer)
        {
            var listvessel = await _context.TblVesselName.ToListAsync();
            var listStock = await _context.TblStock.ToListAsync();
            var listCurrency = await _context.TblCurrencyMaster.ToListAsync();
            var listInvoice = await _context.TblInvoice.Where(i => i.CustomerId.Equals(tblCustomer.Id)).ToListAsync();
            var listship = await _context.TblShipment.ToListAsync();

            var items = (from ls in listStock
                         join c in listCurrency on ls.CurrencyId equals c.Id
                         join li in listInvoice on ls.StockNumber equals li.StockNumber
                         join lsh in listship on ls.StockNumber equals lsh.StockNumber
                         join lv in listvessel on lsh.VesselId equals lv.Id
                       //  where ls.ShipmentStatus == "Pass"

                         select new
                         {
                             Name = c.Name,
                             VesselName = lv.VesselName,
                             StockNumber = li.StockNumber,
                             ShipmentDate = lsh.ShipmentDate,
                             ChassisNumber = ls.ChassisNumber,
                             PaidAmount = li.PaidAmount,
                             Comment = li.Comment,
                             SalePrice = li.SalePrice,
                             BalanceAmount = li.BalanceAmount,
                             EtdDate = lsh.EtdDate,
                             EtaDate = lsh.EtaDate,
                             Status = li.Status
                         }).ToList();
            items.Where(i => i.Status == "Sale");
            //var tblCustomerdata = await _context.TblCustomerMaster.FindAsync(tblCustomer.Id);

            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> UnshippedProduct(TblCustomerMaster tblCustomer)
        {

            var listStock = await _context.TblStock.ToListAsync();
            var listCurrency = await _context.TblCurrencyMaster.ToListAsync();
            var listInvoice = await _context.TblInvoice.Where(i => i.CustomerId.Equals(tblCustomer.Id)).ToListAsync();
            //  var listship = await _context.TblShipment.ToListAsync();
            var items = (from ls in listStock
                         join c in listCurrency on ls.CurrencyId equals c.Id
                         join li in listInvoice on ls.StockNumber equals li.StockNumber
                         //join lsh in listship on ls.StockNumber equals lsh.StockNumber
                         //where ls.ShipmentStatus != "Pass"
                         select new
                         {
                             Date = ls.FirstRegistrationDate,
                             Name = c.Name,
                             InvoiceNumber = li.InvoiceNumber,
                             StockNumber = li.StockNumber,
                             EntryDate = li.EntryDate,
                             ChassisNumber = ls.ChassisNumber,
                             PaidAmount = li.PaidAmount,
                             Comment = li.Comment,
                             SalePrice = li.SalePrice,
                             BalanceAmount = li.BalanceAmount,
                             PaymentStatus = li.PaymentStatus,
                             UpdateDate = ls.UpdateDate,
                             Status = li.Status
                         }).Where(i => i.Status == "Sale").ToList();
            //var tblCustomerdata = await _context.TblCustomerMaster.FindAsync(tblCustomer.Id);

            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }

        [HttpPost]
        public async Task<ApiResponse> CustomerTT(TblCustomerMaster tblCustomer)
        {


            var listCurrency = await _context.TblCurrencyMaster.ToListAsync();
            var listCustomertt = await _context.TblCustomerTt.Where(i => i.Customerid.Equals(tblCustomer.Id)).ToListAsync();
            //  var listship = await _context.TblShipment.ToListAsync();
            var items = (from lct in listCustomertt
                         join c in listCurrency on lct.CurrencyId equals c.Id

                         select new
                         {
                             Date = lct.Ttdate,
                             Name = c.Name,
                             AdvanceRecieved = lct.AdvanceRecieved,
                             AdjustedAmount = 0,
                             Balance = 0,
                             TtreferenceNo = lct.TtreferenceNo,

                         }).ToList();
            //var tblCustomerdata = await _context.TblCustomerMaster.FindAsync(tblCustomer.Id);

            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }

        [HttpPost]
        public async Task<ApiResponse> CustomerById(TblCustomerMaster tblCustomer)
        {
            var tblCustomerMaster = await _context.TblCustomerMaster.FindAsync(tblCustomer.Id);
            var ApiResponse = await response.ApiResult("OK", tblCustomerMaster, "Record Found");
            return ApiResponse;
        }
        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCustomerMaster>> CustomerById(long id)
        {
            var tblCustomerMaster = await _context.TblCustomerMaster.FindAsync(id);

            if (tblCustomerMaster == null)
            {
                return NotFound();
            }

            return tblCustomerMaster;
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCustomerMaster(long id, TblCustomerMaster tblCustomerMaster)
        {
            if (id != tblCustomerMaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCustomerMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCustomerMasterExists(id))
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

        // POST: api/Customer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ApiResponse> AddCustomer(TblCustomerMaster tblCustomerMaster)
        {
            _context.TblCustomerMaster.Add(tblCustomerMaster);
            await _context.SaveChangesAsync();
            if (tblCustomerMaster.Imageurl != null)
            {
                await base64ImageSave(tblCustomerMaster, tblCustomerMaster.Id, "");
            }
            var ApiResponse = await AllCustomer();
            return ApiResponse;
        }

        [HttpPost]
        public async Task<ApiResponse> UpdateCustomer(TblCustomerMaster tblCustomerMaster)
        {

            _context.Entry(tblCustomerMaster).State = EntityState.Modified;
            _context.Entry(tblCustomerMaster).Property(x => x.RecordDate).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
                if (tblCustomerMaster.Imageurl != null)
                {
                    await base64ImageSave(tblCustomerMaster, tblCustomerMaster.Id, "");
                }
                var ApiResponse = await AllCustomer();
                return ApiResponse;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var ApiResponse = await response.ApiResult("FALIED", ex, "Erro In Update ");
                return ApiResponse;
            }


        }

        [HttpPost]
        public async Task<ApiResponse> DeleteCustomer(TblCustomerMaster tblCustomer)
        {
            //var tblCustomerMaster = await _context.TblCustomerMaster.FindAsync(tblCustomer.Id);
            _context.Entry(tblCustomer).Property(x => x.DeleteStatus).IsModified = true;

            try
            {
            var response=    await _context.SaveChangesAsync();

                var ApiResponse = await AllCustomer();
                return ApiResponse;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var ApiResponse = await response.ApiResult("FALIED", ex, "Erro In Update ");
                return ApiResponse;
            }

        }
        [HttpPost]
        public async Task<ApiResponse> EnableDisableCustomer(TblCustomerMaster tblCustomer)
        {
            //var tblCustomerMaster = await _context.TblCustomerMaster.FindAsync(tblCustomer.Id);
            _context.Entry(tblCustomer).Property(x => x.Active).IsModified = true;

            try
            {
                var response = await _context.SaveChangesAsync();

                var ApiResponse = await AllCustomer();
                return ApiResponse;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var ApiResponse = await response.ApiResult("FALIED", ex, "Erro In Update ");
                return ApiResponse;
            }

        }
        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblCustomerMaster>> DeleteTblCustomerMaster(long id)
        {
            var tblCustomerMaster = await _context.TblCustomerMaster.FindAsync(id);
            if (tblCustomerMaster == null)
            {
                return NotFound();
            }

            _context.TblCustomerMaster.Remove(tblCustomerMaster);
            await _context.SaveChangesAsync();

            return tblCustomerMaster;
        }

        private bool TblCustomerMasterExists(long id)
        {
            return _context.TblCustomerMaster.Any(e => e.Id == id);
        }
        private async Task<bool> base64ImageSave(TblCustomerMaster tblCustomerMaster, long lastid, string filetype)
        {
            try
            {
                var base64image = tblCustomerMaster.Imageurl;
                string x = base64image.Replace("data:image/jpeg;base64,", "");
                // Convert Base64 String to byte[]
                byte[] imageBytes = Convert.FromBase64String(x);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                // Convert byte[] to Image
                ms.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                var Filepath = @"customerimage/" + lastid + ".jpg";
                image.Save(Filepath, System.Drawing.Imaging.ImageFormat.Jpeg);
                tblCustomerMaster.Imageurl = Filepath;
                _context.TblCustomerMaster.Add(tblCustomerMaster);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var excp = ex;
            }
            return true;
        }
    }
}
