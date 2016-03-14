using System;

namespace Fiken.Net
{
    public class FikenCreateInvoiceLine
    {
        public int NetAmount { get; set; }
        public int VatAmount { get; set; }
        public int GrossAmount { get; set; }
        public string VatType { get; set; }
        public int? VatPercent { get; set; }
        public int UnitNetAmount { get; set; }
        public int DiscountPercent { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public Uri ProductUrl { get; set; }
        public string IncomeAccount { get; set; }
    }
}
