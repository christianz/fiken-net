using System;
using System.Collections.Generic;

namespace Fiken.Net
{
    public class FikenSale
    {
        /// <summary>
        /// [REQUIRED] The date of sale
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// [REQUIRED] Either "CASH_SALE", "INVOICE", or "EXTERNAL_INVOICE"
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// [REQUIRED] Identifier. Max 50 characters
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// [REQUIRED] True if the sale has been marked as paid
        /// </summary>
        public bool Paid { get; set; }

        /// <summary>
        /// [REQUIRED] List of OrderLines
        /// </summary>
        public IEnumerable<FikenOrderLine> Lines { get; set; } 

        /// <summary>
        /// The account into which the payment has been made, e.g. "1920:10001"
        /// </summary>
        public string PaymentAccount { get; set; }

        /// <summary>
        /// Date of payment
        /// </summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// The related customer for this sale
        /// </summary>
        public Uri Customer { get; set; }

        public IEnumerable<FikenAttachment> GetAttachments()
        {
            yield break;
        }

        public IEnumerable<FikenPayment> GetPayments()
        {
            yield break;
        } 

        public void Save()
        {
            
        }
    }
}
