using System;
using System.Collections.Generic;

namespace Fiken.Net
{
    public class FikenCreateInvoice
    {
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }
        public string OurReference { get; set; }
        public FikenCreateInvoiceCustomer Customer { get; set; }
        public Uri BankAccountUrl { get; set; }
        public List<FikenCreateInvoiceLine> Lines { get; set; }
    }
}
