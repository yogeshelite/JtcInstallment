using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jtcinstallment.Api.Models
{
    public class ApiResponse
    {
        public String ResultStatus { get; set; }
        //public IEnumerable<T> ResultData { get; set; }
        public dynamic ResultData { get; set; }
        public String Message { get; set; }
        public int StatusCode { get; set; }
        public async Task<ApiResponse> ApiResult(string ResStatus, dynamic ResData, string message)
        {
            ApiResponse response = new ApiResponse();
            try
            {

                response.Message = message;
                response.ResultData = ResData;
                response.ResultStatus = ResStatus;

                response.StatusCode = 200;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.ToString();
                response.ResultData = "";
                response.ResultStatus = "FAILED";

                response.StatusCode = 200;
                return response;
            }
        }
    }
}
