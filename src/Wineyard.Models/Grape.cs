namespace Wineyard.Models
{
    public class Grape
    {
#pragma warning disable CS8618 // Required by EF.
        private Grape() { }
#pragma warning restore CS8618 // Required by EF.

        public Grape(string name)
        {
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}