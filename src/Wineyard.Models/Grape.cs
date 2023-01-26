namespace Wineyard.Models
{
    public record Grape(string Name)
    {
        public IEnumerable<Wine>? Wines { get; set; } = null;
    }
}