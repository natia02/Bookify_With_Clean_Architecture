namespace Bookify.Domain.Shared;

public record Currency
{
    internal static readonly Currency None = new("");
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Eur = new("EUR");

    public string Code { get; init; }
    private Currency(string code) => Code = code;
    
    public static readonly IReadOnlyCollection<Currency> All =
    [
        Usd,
        Eur
    ];
    
    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code.Equals(code, StringComparison.OrdinalIgnoreCase))
               ?? throw new ApplicationException($"Currency with code {code} not found.");
    }
}