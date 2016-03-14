namespace Fiken.Net
{
    public class FikenOrderLine
    {
        /// <summary>
        /// A description of the line (product name, etc.)
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// [REQUIRED] The net price in øre
        /// </summary>
        public int NetPrice { get; set; }

        /// <summary>
        /// [REQUIRED] The VAT (MVA) in øre
        /// </summary>
        public int Vat { get; set; }

        /// <summary>
        /// The income account, if not provided a sensible default is chosen
        /// </summary>
        public FikenAccount IncomeAccount { get; set; }

        /// <summary>
        /// [REQUIRED] One of "HIGH", "MEDIUM", "LOW", "EXEMPT", "OUTSIDE", "NONE". "HIGH" is the most common.
        /// </summary>
        public string VatType { get; set; }
    }
}
