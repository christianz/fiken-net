namespace Fiken.Net
{
    public class FikenAttachment
    {
        public string FileName { get; set; }
        public string Comment { get; set; }
        public bool AttachToPayment { get; set; }
        public bool AttachToSale { get; set; }
    }
}
