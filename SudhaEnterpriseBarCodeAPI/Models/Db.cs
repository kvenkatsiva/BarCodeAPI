using System.Data;
using System.Data.SqlClient;
using SudhaEnterpriseBarCodeAPI.Controllers.Models;

namespace SudhaEnterpriseBarCodeAPI.Models
{
    public class Db
    {
        SqlConnection conn = new SqlConnection("Server=BMH2-C-000G8;Database=SudhaEnterprise;Trusted_Connection=true");
        //readonly SqlConnection conn = new SqlConnection("Data Source=BMH2-C-000G8;Initial Catalog=SudhaEnterprise;Integrated Security=True");

        public string BarcodeInfoOut(BarcodeInfo barcodeinfo)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("usp_GetBarCodeList");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", barcodeinfo.Id);
                com.Parameters.AddWithValue("@Guid_Id", barcodeinfo.Guid_Id);
                com.Parameters.AddWithValue("@BarCode", barcodeinfo.BarCode);
                com.Parameters.AddWithValue("@BarCodeDescription", barcodeinfo.BarCodeDescription);
                com.Parameters.AddWithValue("@BarCodePack", barcodeinfo.BarCodePack);
                com.Parameters.AddWithValue("@BarCodeCreatedDate", barcodeinfo.@BarCodeCreatedDate);
                com.Parameters.AddWithValue("@Created_Date", barcodeinfo.@Created_Date);
                com.Parameters.AddWithValue("@Active", barcodeinfo.@Active);
                com.Parameters.AddWithValue("@type", barcodeinfo.type);
                conn.Open();
                com.Connection = conn;
                com.ExecuteNonQuery();
                conn.Close();
                msg = "SUCCESS";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return msg;
        }

        //Get Records from the DB
        public DataSet BarcodeInfoGet(BarcodeInfo barcodeinfo, out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("usp_GetBarCodeList");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", barcodeinfo.Id);
                com.Parameters.AddWithValue("@Guid_Id", barcodeinfo.Guid_Id);
                com.Parameters.AddWithValue("@BarCode", barcodeinfo.BarCode);
                com.Parameters.AddWithValue("@BarCodeDescription", barcodeinfo.BarCodeDescription);
                com.Parameters.AddWithValue("@BarCodePack", barcodeinfo.BarCodePack);
                com.Parameters.AddWithValue("@BarCodeCreatedDate", barcodeinfo.@BarCodeCreatedDate);
                com.Parameters.AddWithValue("@Created_Date", barcodeinfo.@Created_Date);
                com.Parameters.AddWithValue("@Active", barcodeinfo.@Active);
                com.Parameters.AddWithValue("@type", barcodeinfo.type);
                conn.Open();
                com.Connection = conn;
                com.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";
                conn.Close();

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return ds;
        }

        //Update Record into the DB by using ID
        public DataSet BarcodeInfoUpdate(BarcodeInfo barcodeinfo,BarcodeInfo id,out string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("usp_UpdateBarCode");
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", barcodeinfo.Id);
                com.Parameters.AddWithValue("@Guid_Id", barcodeinfo.Guid_Id);
                com.Parameters.AddWithValue("@BarCode", barcodeinfo.BarCode);
                com.Parameters.AddWithValue("@BarCodeDescription", barcodeinfo.BarCodeDescription);
                com.Parameters.AddWithValue("@BarCodePack", barcodeinfo.BarCodePack);
                com.Parameters.AddWithValue("@BarCodeCreatedDate", barcodeinfo.@BarCodeCreatedDate);
                com.Parameters.AddWithValue("@Created_Date", barcodeinfo.@Created_Date);
                com.Parameters.AddWithValue("@Active", barcodeinfo.@Active);
                com.Parameters.AddWithValue("@type", barcodeinfo.type);
                conn.Open();
                com.Connection = conn;
                com.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "SUCCESS";
                conn.Close();

            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return ds;

        }
    }
}
