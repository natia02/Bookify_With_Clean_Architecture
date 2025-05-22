using System.Runtime.InteropServices.JavaScript;

namespace Bookify.Domain.Abstractions;

public record Error(string Code, String Name)
{
    public static Error None = new(string.Empty, string.Empty);
    public static Error NullValue = new("Error.NullValue", "Noll value was provided");
}