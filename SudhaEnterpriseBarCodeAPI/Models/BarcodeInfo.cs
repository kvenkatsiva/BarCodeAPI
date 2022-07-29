using System.Data.SqlTypes;
using System.Data.Sql;
namespace SudhaEnterpriseBarCodeAPI.Controllers.Models
{
    public class BarcodeInfo
    {
        public int Id { get; set; } = 0;
        public string Guid_Id { get; set; }
        public string BarCode { get; set; } = "";
        public string BarCodeDescription { get; set; } = "";
        public int BarCodePack { get; set; } = 0;
        public DateTime? ExpiryDate { get; set; }
        public DateTime FormattedExpiryDate
        {
            get
            {
                return ExpiryDate != null && ExpiryDate.ToString().Length > 0
                                            ? DateTime.Parse(ExpiryDate.ToString())
                                             : new DateTime();
            }
        }
        public DateTime BarCodeCreatedDate { get; set; }
        public DateTime Created_Date { get; set; }
        public int Active { get; set; }= 0;
        public string type { get; set; } = "";
    }
}
