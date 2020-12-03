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
    public class VesselController : ControllerBase
    {
        private readonly jtc_installmentContext _context;
        ApiResponse response = new ApiResponse();
        public VesselController(jtc_installmentContext context)
        {
            _context = context;
        }

        // GET: api/Vessel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblVesselMaster>>> GetTblVesselMaster()
        {
            return await _context.TblVesselMaster.ToListAsync();
        }
        // GET: api/Vessel
        [HttpGet]
        public async Task<ApiResponse> AllVessel()
        {

            var countrylist = await _context.TblCountryMaster.ToListAsync();
            var vesselnameList = await _context.TblVesselName.ToListAsync();
            var shippingAgentlist = await _context.TblShippingAgent.ToListAsync();
            var yardlist = await _context.TblYard.ToListAsync();
            var vesselmasterList = await _context.TblVesselMaster.ToListAsync();
            var items = (from vm in vesselmasterList
                         select new
                         {
                             id = vm.Id,
                             vesselname = vesselnameList.Where(i => i.Id == vm.VesselNameId).Select(i => i.VesselName).FirstOrDefault(),
                             voyageno = vm.VoyageNo,
                             vesseltype = vm.VesselType,
                             ispackagedeal = vm.IsPackageDeal,
                             noofcontainer = vm.NoOfContainer,
                             yardname = yardlist.Where(i => vm.YardId.Contains((i.Id).ToString())).Select(i => i.Name),
                             source = countrylist.Where(i => i.Id == vm.SourceCountryId).Select(i => i.CountryName),
                             destination = countrylist.Where(i => i.Id == vm.DestinationCountryId).Select(i => i.CountryName),
                             shippingagent = shippingAgentlist.Where(i => vm.ShippingAgentid.Contains((i.Id).ToString())).Select(i => i.ShippingAgentName),
                             etddate = vm.Etddate,
                             lastofconsigneedate = vm.LastConsigneDate,
                             lastofcfsdate = vm.LastCfsdate
                         }).ToList();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> VesselSourcePort(TblVesselMaster tblvessel)
        {
            var vesselnameList = await _context.TblVesselName.ToListAsync();
            var portlist = await _context.TblPortMaster.ToListAsync();
            var vesselroutlist = await _context.TblVesselRoute.ToListAsync();
            var vesselmasterList = await _context.TblVesselMaster.ToListAsync();
            var items = (from vm in vesselmasterList
                         join vr in vesselroutlist on vm.Id equals vr.VesselMasterId
                         join pl in portlist on vr.PortId equals pl.Id
                         join vn in vesselnameList on vm.VesselNameId equals vn.Id
                         where vm.Id == tblvessel.Id && vr.Type == "Source"
                         select new
                         {
                             vesselname = vn.VesselName,
                             portname = pl.PortName,
                             lastputtingdate = vr.LastPuttingdate,

                         }).ToList();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }
        [HttpPost]
        public async Task<ApiResponse> VesselDestinationPort(TblVesselMaster tblvessel)
        {
            var vesselnameList = await _context.TblVesselName.ToListAsync();
            var portlist = await _context.TblPortMaster.ToListAsync();
            var vesselroutlist = await _context.TblVesselRoute.ToListAsync();
            var vesselmasterList = await _context.TblVesselMaster.ToListAsync();
            var items = (from vm in vesselmasterList
                         join vr in vesselroutlist on vm.Id equals vr.VesselMasterId
                         join pl in portlist on vr.PortId equals pl.Id
                         join vn in vesselnameList on vm.VesselNameId equals vn.Id
                         where vm.Id == tblvessel.Id && vr.Type == "Destination"
                         select new
                         {
                             vesselname = vn.VesselName,
                             portname = pl.PortName,
                             lastputtingdate = vr.LastPuttingdate,

                         }).ToList();
            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }
        // GET: api/Vessel/5
        [HttpPost]
        public async Task<ApiResponse> GetVesselMasterById(TblVesselMaster objVessel)
        {
            var listvesselroute = await _context.TblVesselRoute.ToListAsync();
            var listVesselMaster = await _context.TblVesselMaster.ToListAsync();
            var items = (from lvm in listVesselMaster


                         select new
                         {
                             id = lvm.Id,
                             vesselNameId = lvm.VesselNameId,
                             voyageNo = lvm.VoyageNo,
                             vesselType = lvm.VesselType,
                             isPackageDeal = lvm.IsPackageDeal,
                             noOfContainer = lvm.NoOfContainer,
                             yardId = lvm.YardId,
                             shippingAgentid = lvm.ShippingAgentid,
                             sourceCountryId = lvm.SourceCountryId,
                             destinationCountryId = lvm.DestinationCountryId,
                             eTDDate = lvm.Etddate,
                             lastConsigneDate = lvm.LastConsigneDate,
                             lastCFSDate = lvm.LastCfsdate,
                             recordDate = lvm.RecordDate,
                             updateDate = lvm.UpdateDate,
                             deleteDate = lvm.DeleteDate
                            ,
                             vesselRoute = listvesselroute.Where(i => i.VesselMasterId == objVessel.Id)
                         }).Where(i => i.id == objVessel.Id).ToList();

            var ApiResponse = await response.ApiResult("OK", items, "Record Found");
            return ApiResponse;
        }

        // PUT: api/Vessel/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ApiResponse> updateVesselMaster(TblVesselMaster tblVesselMaster)
        {
            _context.Entry(tblVesselMaster).State = EntityState.Modified;
            _context.Entry(tblVesselMaster).Property(i=>i.RecordDate).IsModified = false;
            try
            {
                await _context.SaveChangesAsync();
                //remove vessel Route
                var listVesselRoute = await _context.TblVesselRoute.Where(i=>i.VesselMasterId==tblVesselMaster.Id).ToListAsync();
                
                _context.TblVesselRoute.RemoveRange(listVesselRoute);
                await _context.SaveChangesAsync();
                List<TblVesselRoute> vesselRouteDetail = JsonConvert.DeserializeObject<List<TblVesselRoute>>(tblVesselMaster.VesselRouteDetail.ToString());
                for (int i = 0; i < vesselRouteDetail.Count; i++)
                {
                    TblVesselRoute objVesselRoute = new TblVesselRoute();
                    objVesselRoute.PortId = vesselRouteDetail[i].PortId;
                    objVesselRoute.VesselMasterId = tblVesselMaster.Id;
                    objVesselRoute.Type = vesselRouteDetail[i].Type;
                    objVesselRoute.LastPuttingdate = vesselRouteDetail[i].LastPuttingdate;
                    _context.TblVesselRoute.Add(objVesselRoute);
                    await _context.SaveChangesAsync();
                }
                var ApiResponse = await response.ApiResult("OK", "", "Record Update");
                return ApiResponse;
            }
            catch (DbUpdateConcurrencyException ex)
            {

                var ApiResponseEX = await response.ApiResult("OK", ex, "Record Found");
                return ApiResponseEX;
            }


        }

        // POST: api/Vessel
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ApiResponse> AddVesselMaster(TblVesselMaster tblVesselMaster)
        {
            _context.TblVesselMaster.Add(tblVesselMaster);
            await _context.SaveChangesAsync();
            List<TblVesselRoute> vesselRouteDetail = JsonConvert.DeserializeObject<List<TblVesselRoute>>(tblVesselMaster.VesselRouteDetail.ToString());
            for (int i = 0; i < vesselRouteDetail.Count; i++)
            {
                TblVesselRoute objVesselRoute = new TblVesselRoute();
                objVesselRoute.PortId = vesselRouteDetail[i].PortId;
                objVesselRoute.VesselMasterId = tblVesselMaster.Id;
                objVesselRoute.Type = vesselRouteDetail[i].Type;
                objVesselRoute.LastPuttingdate = vesselRouteDetail[i].LastPuttingdate;
                _context.TblVesselRoute.Add(objVesselRoute);
                await _context.SaveChangesAsync();
            }
            var ApiResponse = await response.ApiResult("OK", new { id = tblVesselMaster.Id }, "Record Add ");
            return ApiResponse;

        }

        // DELETE: api/Vessel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblVesselMaster>> DeleteTblVesselMaster(long id)
        {
            var tblVesselMaster = await _context.TblVesselMaster.FindAsync(id);
            if (tblVesselMaster == null)
            {
                return NotFound();
            }

            _context.TblVesselMaster.Remove(tblVesselMaster);
            await _context.SaveChangesAsync();

            return tblVesselMaster;
        }

        private bool TblVesselMasterExists(long id)
        {
            return _context.TblVesselMaster.Any(e => e.Id == id);
        }
    }
}
