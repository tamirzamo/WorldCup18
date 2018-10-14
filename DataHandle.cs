// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var rounds = Rounds.FromJson(jsonString);

namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Rounds
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rounds")]
        public Round[] RoundsRounds { get; set; }
    }

    public partial class Round
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("matches")]
        public Match[] Matches { get; set; }
    }

    public partial class Match
    {
        [JsonProperty("num")]
        public long Num { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("team1")]
        public Team Team1 { get; set; }

        [JsonProperty("team2")]
        public Team Team2 { get; set; }

        [JsonProperty("score1")]
        public long? Score1 { get; set; }

        [JsonProperty("score2")]
        public long? Score2 { get; set; }

        [JsonProperty("score1i")]
        public object Score1I { get; set; }

        [JsonProperty("score2i")]
        public object Score2I { get; set; }

        [JsonProperty("goals1", NullValueHandling = NullValueHandling.Ignore)]
        public Goals[] Goals1 { get; set; }

        [JsonProperty("goals2", NullValueHandling = NullValueHandling.Ignore)]
        public Goals[] Goals2 { get; set; }

        [JsonProperty("group", NullValueHandling = NullValueHandling.Ignore)]
        public string Group { get; set; }

        [JsonProperty("stadium")]
        public Stadium Stadium { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("timezone")]
        public Timezone Timezone { get; set; }

        [JsonProperty("score1et")]
        public long? Score1Et { get; set; }

        [JsonProperty("score2et")]
        public long? Score2Et { get; set; }

        [JsonProperty("score1p")]
        public object Score1P { get; set; }

        [JsonProperty("score2p")]
        public object Score2P { get; set; }

        [JsonProperty("knockout", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Knockout { get; set; }
    }

    public partial class Goals
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("minute")]
        public long Minute { get; set; }

        [JsonProperty("score1")]
        public long Score1 { get; set; }

        [JsonProperty("score2")]
        public long Score2 { get; set; }

        [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
        public long? Offset { get; set; }

        [JsonProperty("penalty", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Penalty { get; set; }

        [JsonProperty("owngoal", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Owngoal { get; set; }
    }

    public partial class Stadium
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Team
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public enum Timezone { Utc2, Utc3, Utc4, Utc5 };

    public partial class Rounds
    {
        public static Rounds FromJson(string json) => JsonConvert.DeserializeObject<Rounds>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Rounds self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                TimezoneConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TimezoneConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Timezone) || t == typeof(Timezone?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "UTC+2":
                    return Timezone.Utc2;
                case "UTC+3":
                    return Timezone.Utc3;
                case "UTC+4":
                    return Timezone.Utc4;
                case "UTC+5":
                    return Timezone.Utc5;
            }
            throw new Exception("Cannot unmarshal type Timezone");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Timezone)untypedValue;
            switch (value)
            {
                case Timezone.Utc2:
                    serializer.Serialize(writer, "UTC+2");
                    return;
                case Timezone.Utc3:
                    serializer.Serialize(writer, "UTC+3");
                    return;
                case Timezone.Utc4:
                    serializer.Serialize(writer, "UTC+4");
                    return;
                case Timezone.Utc5:
                    serializer.Serialize(writer, "UTC+5");
                    return;
            }
            throw new Exception("Cannot marshal type Timezone");
        }

        public static readonly TimezoneConverter Singleton = new TimezoneConverter();
    }
}
