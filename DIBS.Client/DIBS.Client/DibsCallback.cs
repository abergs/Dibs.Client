namespace DIBS.Client
{
    public class DibsCallback : DibsPost
    {
        public string Acquirer { get; set; }

        [CamelCase]
        public string ActionCode { get; set; }

        [CamelCase]
        public string CardNumberMasked { get; set; }

        [CamelCase]
        public string CardTypeName { get; set; }

        [CamelCase]
        public string ExpMonth { get; set; }

        [CamelCase]
        public string ExpYear { get; set; }

        public string Status { get; set; }
        public string Transaction { get; set; }
    }
}