namespace Wineyard.Models
{
    public record Wine(
        string WineryName,
        string Label,
        string CountryName,
        ushort Vintage)
    {
        public IEnumerable<Grape>? Grapes { get; set; } = null;
    }
}
