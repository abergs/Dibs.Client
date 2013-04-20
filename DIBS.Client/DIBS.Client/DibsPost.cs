namespace DIBS.Client
{
    public class DibsPost : DibsBase, IDibsPost
    {
        public string Amount { get; set; }
        public string OrderId { get; set; }
        public string Currency { get; set; }
        public string Merchant { get; set; }

        [IgnoreHashing]
        public string MAC { get; set; }

        public string AcceptReturnUrl { get; set; }
        public string CancelReturnUrl { get; set; }
        public string CallbackUrl { get; set; }
        public string Language { get; set; }

        [IgnoreHashing("1")]
        public string Test { get; set; }
    }
}