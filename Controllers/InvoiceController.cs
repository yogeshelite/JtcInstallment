using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using jtcinstallment.Api.Entity;
using jtcinstallment.Api.Models;
using Microsoft.AspNetCore.Http.Features;
using System.Security.Permissions;
using jtcinstallment.Api.Controllers;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace jtccarsales.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public InvoiceController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Invoice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblInvoice>>> GetTblInvoice()
        {
            return await _context.TblInvoice.ToListAsync();
        }
        // GET: api/Invoice
        [HttpGet]
        public async Task<ApiResponse> InvoiceGeneratedList()
        {
            var currencyList = await _context.TblCurrencyMaster.ToListAsync();
            var salemanList = await _context.TblUserMaster.ToListAsync();
            var customerList = await _context.TblCustomerMaster.ToListAsync();
            var stockList = await _context.TblStock.ToListAsync();
            var productList = await _context.TblProduct.ToListAsync();
            var colorList = await _context.TblColor.ToListAsync();
            var productStocklist = (from ls in stockList
                                    join lp in productList on ls.ProductId equals lp.Id
                                    join lc in colorList on ls.ColorId equals lc.Id
                                    select new
                                    {
                                        StockNumber = ls.StockNumber,
                                        Fuel = lp.Fuel,
                                        ChassisType = lp.ChassisType,
                                        Drive = lp.Drive,
                                        Color = lc.Name
                                    }).ToList();
            var items = await _context.TblInvoice.Where(i => i.Status == "Sale").ToListAsync();
            var item = (from it in items
                        select new
                        {

                            StockNumber = it.StockNumber,
                            ProductName = "Product Name",
                            // Customer="Customer",
                            //SalesMan="SalesMan",
                            Status = it.Status,
                            SaleReffNo = "SaleReffNO",
                            SaleDate = it.SaleDate,
                            SalePrice = it.SalePrice,
                            PaymentStatus = it.PaymentStatus,
                            PaidAmount = it.PaidAmount,
                            BalanceAmount = it.BalanceAmount,
                            IndividualInvoiceNumber = it.IndividualInvoiceNumber,
                            InvoiceNumber = it.InvoiceNumber,
                            NotifyParty = it.NotifyParty,
                            ConsigneeName = it.ConsigneeName,
                            ConsigneeAddress = it.ConsigneeAddress,
                            CFS = it.Cfs,
                            Detail = productStocklist.Where(i => i.StockNumber == it.StockNumber),
                            Customer = customerList.Where(i => i.Id == it.CustomerId).FirstOrDefault().CustomerName,
                            Salesman = salemanList.Where(i => i.Id == it.UserId).FirstOrDefault().UserName,
                            CurrencyName = currencyList.Where(i => i.Id == it.CurrencyId).FirstOrDefault().Name,
                            CancelDate = it.CancelDate
                        }).OrderByDescending(i => i.SaleDate).ToList();
            var ApiResponse = await response.ApiResult("OK", item, "Record Found");

            return ApiResponse;
        }
        [HttpGet]
        public async Task<ApiResponse> InvoiceCancelList()
        {
            var currencyList = await _context.TblCurrencyMaster.ToListAsync();
            var salemanList = await _context.TblUserMaster.ToListAsync();
            var customerList = await _context.TblCustomerMaster.ToListAsync();
            var stockList = await _context.TblStock.ToListAsync();
            var productList = await _context.TblProduct.ToListAsync();
            var colorList = await _context.TblColor.ToListAsync();
            var productStocklist = (from ls in stockList
                                    join lp in productList on ls.ProductId equals lp.Id
                                    join lc in colorList on ls.ColorId equals lc.Id
                                    select new
                                    {
                                        StockNumber = ls.StockNumber,
                                        Fuel = lp.Fuel,
                                        ChassisType = lp.ChassisType,
                                        Drive = lp.Drive,
                                        Color = lc.Name
                                    }).ToList();
            var items = await _context.TblInvoice.Where(i => i.Status == "Cancel" && i.IndividualInvoiceNumber == null).ToListAsync();
            var item = (from it in items
                        select new
                        {

                            StockNumber = it.StockNumber,
                            ProductName = "Product Name",
                            // Customer="Customer",
                            //SalesMan="SalesMan",
                            Status = it.Status,
                            SaleReffNo = "SaleReffNO",
                            SaleDate = it.SaleDate,
                            SalePrice = it.SalePrice,
                            PaymentStatus = it.PaymentStatus,
                            PaidAmount = it.PaidAmount,
                            BalanceAmount = it.BalanceAmount,
                            IndividualInvoiceNumber = it.IndividualInvoiceNumber,
                            InvoiceNumber = it.InvoiceNumber,
                            NotifyParty = it.NotifyParty,
                            ConsigneeName = it.ConsigneeName,
                            ConsigneeAddress = it.ConsigneeAddress,
                            CFS = it.Cfs,
                            Detail = productStocklist.Where(i => i.StockNumber == it.StockNumber),
                            Customer = customerList.Where(i => i.Id == it.CustomerId).FirstOrDefault().CustomerName,
                            Salesman = salemanList.Where(i => i.Id == it.UserId).FirstOrDefault().UserName,
                            CurrencyName = currencyList.Where(i => i.Id == it.CurrencyId).FirstOrDefault().Name,
                            CancelDate = it.CancelDate
                        }).OrderByDescending(i => i.SaleDate).ToList();
            var ApiResponse = await response.ApiResult("OK", item, "Record Found");

            return ApiResponse;
        }
        // GET: api/Invoice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblInvoice>> GetTblInvoice(long id)
        {
            var tblInvoice = await _context.TblInvoice.FindAsync(id);

            if (tblInvoice == null)
            {
                return NotFound();
            }

            return tblInvoice;
        }


        // PUT: api/Invoice/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblInvoice(long id, TblInvoice tblInvoice)
        {
            if (id != tblInvoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblInvoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblInvoiceExists(id))
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

        // POST: api/Invoice
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ApiResponse> AddSale(TblInvoice tblInvoice)
        {
            //
            //[NotMapped] Sample Code 
            // public object InstallmentDetail { get; set; }
            //
            //
            //[NotMapped]
            //public string PaymentMode { get; set; }
            //
            //List<Testcalss> res = tblInvoice.InstallmentDetail as List<Testcalss>;
            List<TblInstallment> installmentDetail = JsonConvert.DeserializeObject<List<TblInstallment>>(tblInvoice.InstallmentDetail.ToString());
            try
            {
                for (int i = 0; i < installmentDetail.Count; i++)
                {
                    TblInvoice objInvoice = new TblInvoice();
                    objInvoice.UserId = tblInvoice.UserId;
                    objInvoice.CurrencyId = tblInvoice.CurrencyId;
                    objInvoice.CountryId = tblInvoice.CountryId;
                    objInvoice.CustomerId = tblInvoice.CustomerId;
                    objInvoice.Comment = tblInvoice.Comment;
                    objInvoice.PaymentMode = installmentDetail[i].PaymentMode;
                    objInvoice.StockNumber = installmentDetail[i].StockNumber;
                    objInvoice.SalePrice = Convert.ToDecimal(installmentDetail[i].SalePrice);
                    objInvoice.SaleDate = DateTime.Now;
                    if (installmentDetail[i].PaymentMode == "CASH")
                        objInvoice.PaymentStatus = "Paid";
                    else
                        objInvoice.PaymentStatus = "INSTALLMENT";
                    objInvoice.PaidAmount= Convert.ToDecimal(installmentDetail[i].SalePrice);
                    objInvoice.BalanceAmount = 0;
                    objInvoice.Status = "Sale";
                    long lastInvoiceid = 0;
                    try
                    {
                        // _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[tbl_Invoice] ON");

                        _context.TblInvoice.Add(objInvoice);
                        await _context.SaveChangesAsync();
                        lastInvoiceid = objInvoice.Id;
                        var currentmonthShort = DateTime.Now.ToString("MMM-dd");
                        var invoiceNumber = "INV-"+currentmonthShort + "-" + String.Format("{0:D4}", lastInvoiceid);
                        objInvoice.InvoiceNumber = invoiceNumber;
                        _context.Entry(objInvoice).Property(x => x.InvoiceNumber).IsModified = true;
                        await _context.SaveChangesAsync();
                       
                        //tblInvoice.Id=0;
                        // _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[tbl_Invoice] OFF");


                        if (installmentDetail[i].PaymentMode == "INSTALLMENT")
                        {
                            TblInstallment objInstallment = new TblInstallment();
                            objInstallment.InvoiceNumber = lastInvoiceid.ToString();
                            objInstallment.StockNumber = installmentDetail[i].StockNumber;
                            objInstallment.CustomerId = tblInvoice.CustomerId;
                            objInstallment.SalemanId = tblInvoice.UserId;
                            objInstallment.SalePrice = installmentDetail[i].SalePrice;
                            objInstallment.DownPayment = installmentDetail[i].DownPayment;
                            objInstallment.TimeDurationYears = installmentDetail[i].TimeDurationYears;
                            objInstallment.TotalInstallment = installmentDetail[i].TotalInstallment;
                            objInstallment.TaxPer = installmentDetail[i].TaxPer;
                            objInstallment.TaxAmount = installmentDetail[i].TaxAmount;
                            objInstallment.FinalAmount = installmentDetail[i].FinalAmount;
                            objInstallment.InstallAmount = installmentDetail[i].InstallAmount;
                            objInstallment.Installmentmode = installmentDetail[i].Installmentmode;
                            objInstallment.Day = installmentDetail[i].Day;
                            objInstallment.CreatedDate = DateTime.Now;
                            _context.TblInstallment.Add(objInstallment);
                            await _context.SaveChangesAsync();
                            var Currentyear = DateTime.Now.Year;
                            var currentmonth = DateTime.Now.Month;
                            var currday = DateTime.Now.Day;
                            DateTime installmentDate = new DateTime();
                            for (int j = 0; j < installmentDetail[i].TotalInstallment; j++)
                            {
                                TblInstallmentDetail objinstallmentDetail = new TblInstallmentDetail();
                                
                                decimal TaxAmount = 0;
                                decimal pendingPayment = Convert.ToDecimal(installmentDetail[i].SalePrice - installmentDetail[i].DownPayment);
                                int timeperiod = Convert.ToInt32(installmentDetail[i].TimeDurationYears);
                                switch (installmentDetail[i].Installmentmode)
                                {
                                    case
                                        "YEAR":
                                        Currentyear ++;
                                        installmentDate = new DateTime(Currentyear, currentmonth, Convert.ToInt32(installmentDetail[i].Day));
                                        // TimeSpan aMonth = new System.TimeSpan(365, 0, 0, 0);
                                        //installmentDate.Add(aMonth);
                                        TaxAmount = Convert.ToDecimal((pendingPayment / timeperiod) * Convert.ToDecimal(installmentDetail[i].TaxPer) / 100);
                                        break;
                                    case
                                        "HALFYEAR":
                                        currentmonth = currentmonth + 6;
                                        if (currentmonth > 12)
                                        {
                                            Currentyear++;
                                           var addcurrentmonth = currentmonth % 12;
                                            installmentDate = new DateTime(Currentyear, addcurrentmonth, Convert.ToInt32(installmentDetail[i].Day));

                                        }
                                        else
                                        {
                                            installmentDate = new DateTime(Currentyear, currentmonth, Convert.ToInt32(installmentDetail[i].Day));
                                        }
                                        //  TimeSpan aMonthHalf = new System.TimeSpan(180, 0, 0, 0);
                                        //installmentDate.Add(aMonthHalf);
                                        TaxAmount = Convert.ToDecimal((pendingPayment / (timeperiod * 2)) * Convert.ToDecimal(installmentDetail[i].TaxPer) / 100);

                                        break;
                                    case
                                        "MONTHLY":
                                        currentmonth++;
                                        if (currentmonth > 12)
                                        {
                                            currentmonth = currentmonth % 12;
                                            Currentyear++;
                                            installmentDate = new DateTime(Currentyear, currentmonth, Convert.ToInt32(installmentDetail[i].Day));

                                        }
                                        else
                                        {
                                            installmentDate = new DateTime(Currentyear, currentmonth, Convert.ToInt32(installmentDetail[i].Day));
                                        }
                                        //TimeSpan aMonthM = new System.TimeSpan(30, 0, 0, 0);
                                        //installmentDate.Add(aMonthM);
                                        TaxAmount = Convert.ToDecimal((pendingPayment / (timeperiod * 12)) * Convert.ToDecimal(installmentDetail[i].TaxPer) / 100);

                                        break;
                                }
                                objinstallmentDetail.InstallmentDate = installmentDate;
                                objinstallmentDetail.InstallmentId = objInstallment.Id;
                                objinstallmentDetail.DueDate = installmentDate.AddDays(15);
                                objinstallmentDetail.PaymentStatus = "PENDING";
                                objinstallmentDetail.TaxPer = installmentDetail[i].TaxPer;
                                objinstallmentDetail.TaxAmount = TaxAmount;
                                objinstallmentDetail.FinalAmount = installmentDetail[i].InstallAmount;
                                objinstallmentDetail.PaidAmount = 0;
                                objinstallmentDetail.CreatedDate = DateTime.Now;

                                _context.TblInstallmentDetail.Add(objinstallmentDetail);
                                await _context.SaveChangesAsync();
                            }
                        }
                        //tblInvoice.Id = 0;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        var ApiResponseCatch = await response.ApiResult("FAILED", ex, "Error ");
                        return ApiResponseCatch;
                    }
                }
                var ApiResponse = await response.ApiResult("OK", "Data Save Installment", "Success ");
                return ApiResponse;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var ApiResponseCatch = await response.ApiResult("FAILED", ex, "Error ");
                return ApiResponseCatch;
            }

            //  return CreatedAtAction("GetTblInvoice", new { id = tblInvoice.Id }, tblInvoice);
        }

        // DELETE: api/Invoice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblInvoice>> DeleteTblInvoice(long id)
        {
            var tblInvoice = await _context.TblInvoice.FindAsync(id);
            if (tblInvoice == null)
            {
                return NotFound();
            }

            _context.TblInvoice.Remove(tblInvoice);
            await _context.SaveChangesAsync();

            return tblInvoice;
        }

        private bool TblInvoiceExists(long id)
        {
            return _context.TblInvoice.Any(e => e.Id == id);
        }
    }
}
