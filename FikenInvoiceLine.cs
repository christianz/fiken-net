using System;

namespace Fiken.Net
{
    public class FikenInvoiceLine
    {
        /// <summary>
        /// Net amount in øre
        /// </summary>
        public int Net { get; set; }
        
        public int NetAmount => Net;
        public int VatAmount => Vat;
        public int GrossAmount => Gross;

        /// <summary>
        /// VAT (MVA) amount in øre
        /// </summary>
        public int Vat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int VatType { get; set; }

        public int VatPercent { get; set; }

        public int UnitNetAmount => UnitPrice;

        public string Description { get; set; }
        public string Comment { get; set; }

        public Uri ProductUrl => Product;

        /// <summary>
        /// Gross amount (=net + vat) in øre
        /// </summary>
        public int Gross { get; set; }

        /// <summary>
        /// VAT in percent (e.g. 25)
        /// </summary>
        public int VatInPercent { get; set; }

        /// <summary>
        /// Price per unit in øre
        /// </summary>
        public int UnitPrice { get; set; }

        /// <summary>
        /// Unit quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Link to product if product-line
        /// </summary>
        public Uri Product { get; set; }

        /// <summary>
        /// Invoice account for accounting purposes (e.g. '3000')
        /// </summary>
        public string IncomeAccount { get; set; }
    }
}
