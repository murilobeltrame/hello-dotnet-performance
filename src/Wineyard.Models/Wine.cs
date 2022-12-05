﻿namespace Wineyard.Models
{
    public class Wine
    {
#pragma warning disable CS8618 // Required by EF.
        private Wine() { }
#pragma warning restore CS8618 // Required by EF.

        public Wine(string wineryName, string label, string countryName, ICollection<Grape> grapes, ushort vintage)
        {
            WineryName = wineryName;
            Label = label;
            CountryName = countryName;
            Grapes = grapes;
            Vintage = vintage;
        }

        public Guid Id { get; private set; }
        public string WineryName { get; private set; }
        public string Label { get; private set; }
        public string CountryName { get; private set; }
        public ICollection<Grape> Grapes { get; private set; }
        public ushort Vintage { get; private set; }
    }
}