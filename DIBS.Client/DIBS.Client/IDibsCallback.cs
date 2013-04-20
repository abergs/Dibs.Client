namespace DIBS.Client
{
    public interface IDibsCallback
    {
        string Acquirer { get; set; }

        [CamelCase]
        string ActionCode { get; set; }

        [CamelCase]
        string CardNumberMasked { get; set; }

        [CamelCase]
        string CardTypeName { get; set; }

        [CamelCase]
        string ExpMonth { get; set; }

        [CamelCase]
        string ExpYear { get; set; }

        string Status { get; set; }
        string Transaction { get; set; }
        string Amount { get; set; }
        string OrderId { get; set; }
        string Currency { get; set; }
        string Merchant { get; set; }

        [IgnoreHashing]
        string MAC { get; set; }

        string AcceptReturnUrl { get; set; }
        string CancelReturnUrl { get; set; }
        string CallbackUrl { get; set; }
        string Language { get; set; }

        [IgnoreHashing("1")]
        string Test { get; set; }

        string GenerateHMAC(string key);
    }
}