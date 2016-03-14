using System;

namespace Fiken.Net
{
    public class FikenProduct
    {
        public Uri Url { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public int IncomeAccount { get; set; }
        public string VatType { get; set; }
        public bool Active { get; set; }
    }
}
