using System.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SudhaEnterpriseBarCodeAPI.Models;
using SudhaEnterpriseBarCodeAPI.Controllers.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SudhaEnterpriseBarCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarCodeInfoController : ControllerBase
    {
         private Db dbop = new Db();
        string msg = String.Empty;

        // GET: api/<BarCodeInfoController>
        [HttpGet]
        public List<BarcodeInfo> Get()
        {
            BarcodeInfo barcodinfo = new BarcodeInfo();
            barcodinfo.type = "get";
            DataSet ds = dbop.BarcodeInfoGet(barcodinfo, out msg);
            List<BarcodeInfo> list = new List<BarcodeInfo>();
            //foreach (DataRow dr in ds.Tables)
             foreach (DataRow dr in ds.Tables[0].Rows)
                {
                list.Add(new BarcodeInfo
                {
                    Id = Convert.ToInt32(dr["id"]),
                    Guid_Id = (dr["Guid_Id"]).ToString(),
                    BarCode = (dr["BarCode"]).ToString(),
                    BarCodeDescription = (dr["BarCodeDescription"]).ToString(),
                    BarCodePack = Convert.ToInt32(dr["BarCodePack"]),
                    BarCodeCreatedDate = Convert.ToDateTime(dr["BarCodeCreatedDate"]),
                    Created_Date = Convert.ToDateTime(dr["Created_Date"]),
                    Active = Convert.ToInt32(dr["active"]),
                    type = (dr["Type"]).ToString()
                });
            }
            return list;
        }

        // GET api/<BarCodeInfoController>/5
        [HttpGet("{id}")]
        public List<BarcodeInfo> Get(int id)
        {
            BarcodeInfo barcodinfo = new BarcodeInfo();
            barcodinfo.type = "getid";
            DataSet ds = dbop.BarcodeInfoGet(barcodinfo, out msg);
            List<BarcodeInfo> list = new List<BarcodeInfo>();
           // foreach (DataRow dr in ds.Tables)
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                list.Add(new BarcodeInfo
                {
                    Id = Convert.ToInt32(dr["id"]),
                    Guid_Id = (dr["Guid_Id"]).ToString(),
                    BarCode = (dr["BarCode"]).ToString(),
                    BarCodeDescription = (dr["BarCodeDescription"]).ToString(),
                    BarCodePack = Convert.ToInt32(dr["BarCodePack"]),
                    BarCodeCreatedDate = Convert.ToDateTime(dr["BarCodeCreatedDate"]),
                    Created_Date = Convert.ToDateTime(dr["Created_Date"]),
                    Active = Convert.ToInt32(dr["active"]),
                    type = (dr["Type"]).ToString()
                });
            }

            return list;
        }

        // POST api/<BarCodeInfoController>
        [HttpPost]
        public string Post([FromBody] BarcodeInfo barcodeinfo)
        {

            string msg = string.Empty;
            try
            {
                msg = dbop.BarcodeInfoOut(barcodeinfo);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // PUT api/<BarCodeInfoController>/5
        [HttpPut("{id}")]
        public string Update(int id,[FromBody] BarcodeInfo barcodeinfo)
        {
            string msg = string.Empty;
            try
            {
                barcodeinfo.Id = Convert.ToInt32(id);
                msg = dbop.BarcodeInfoOut(barcodeinfo);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        // DELETE api/<BarCodeInfoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string msg = string.Empty;
            try
            {
                BarcodeInfo barcodeinfo = new BarcodeInfo();    
                barcodeinfo.Id = id;
                barcodeinfo.type = "delete";
                msg = dbop.BarcodeInfoOut(barcodeinfo);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
