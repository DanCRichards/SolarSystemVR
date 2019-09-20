﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using IS320;
//
//    var bodies = Bodies.FromJson(jsonString);

namespace IS320
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Bodies
    {
        [JsonProperty("bodies")]
        public List<Body> BodiesBodies { get; set; }
    }

    public partial class Body
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("englishName")]
        public string EnglishName { get; set; }

        [JsonProperty("isPlanet")]
        public bool IsPlanet { get; set; }

        [JsonProperty("moons")]
        public List<Moon> Moons { get; set; }

        [JsonProperty("semimajorAxis")]
        public long SemimajorAxis { get; set; }

        [JsonProperty("perihelion")]
        public long Perihelion { get; set; }

        [JsonProperty("aphelion")]
        public long Aphelion { get; set; }

        [JsonProperty("eccentricity")]
        public double Eccentricity { get; set; }

        [JsonProperty("inclination")]
        public double Inclination { get; set; }

        [JsonProperty("mass")]
        public Mass Mass { get; set; }

        [JsonProperty("vol")]
        public Vol Vol { get; set; }

        [JsonProperty("density")]
        public double Density { get; set; }

        [JsonProperty("gravity")]
        public double Gravity { get; set; }

        [JsonProperty("escape")]
        public double Escape { get; set; }

        [JsonProperty("meanRadius")]
        public double MeanRadius { get; set; }

        [JsonProperty("equaRadius")]
        public double EquaRadius { get; set; }

        [JsonProperty("polarRadius")]
        public double PolarRadius { get; set; }

        [JsonProperty("flattening")]
        public double Flattening { get; set; }

        [JsonProperty("dimension")]
        public string Dimension { get; set; }

        [JsonProperty("sideralOrbit")]
        public double SideralOrbit { get; set; }

        [JsonProperty("sideralRotation")]
        public double SideralRotation { get; set; }

        [JsonProperty("aroundPlanet")]
        public AroundPlanet AroundPlanet { get; set; }

        [JsonProperty("discoveredBy")]
        public string DiscoveredBy { get; set; }

        [JsonProperty("discoveryDate")]
        public string DiscoveryDate { get; set; }

        [JsonProperty("alternativeName")]
        public string AlternativeName { get; set; }

        [JsonProperty("rel")]
        public Uri Rel { get; set; }
    }

    public partial class AroundPlanet
    {
        [JsonProperty("planet")]
        public string Planet { get; set; }

        [JsonProperty("rel")]
        public Uri Rel { get; set; }
    }

    public partial class Mass
    {
        [JsonProperty("massValue")]
        public double MassValue { get; set; }

        [JsonProperty("massExponent")]
        public long MassExponent { get; set; }
    }

    public partial class Moon
    {
        [JsonProperty("moon")]
        public string MoonMoon { get; set; }

        [JsonProperty("rel")]
        public Uri Rel { get; set; }
    }

    public partial class Vol
    {
        [JsonProperty("volValue")]
        public double VolValue { get; set; }

        [JsonProperty("volExponent")]
        public long VolExponent { get; set; }
    }

    public partial class Bodies
    {
        public static Bodies FromJson(string json) => JsonConvert.DeserializeObject<Bodies>(json, IS320.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Bodies self) => JsonConvert.SerializeObject(self, IS320.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
