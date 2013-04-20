namespace DIBS.Client
{
    public interface IDibsPost
    {
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
    }
}