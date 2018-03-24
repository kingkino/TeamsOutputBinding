using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsOutputBinding
{ 
    public class TeamsMessage
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("sections")]
        public Section[] Sections { get; set; }
        [JsonProperty("potentialAction")]
        public Potentialaction[] PotentialAction { get; set; }
        public override string ToString()
        {
            return $"{Title}, {Text}";
        }
    }

    public class Section
    {
        [JsonProperty("activityTitle")]
        public string ActivityTitle { get; set; }
        [JsonProperty("activitySubtitle")]
        public string ActivitySubtitle { get; set; }
        [JsonProperty("activityImage")]
        public string ActivityImage { get; set; }
        [JsonProperty("facts")]
        public Fact[] Facts { get; set; }
        [JsonProperty("potentialAction")]
        public bool PotentialAction { get; set; }
    }

    public class Fact
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Potentialaction
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("inputs")]
        public Input[] Inputs { get; set; }
        [JsonProperty("actions")]
        public Action[] Actions { get; set; }
    }

    public class Input
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("isMultiline")]
        public bool IsMultiline { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("isMultiSelect")]
        public string IsMultiSelect { get; set; }
        [JsonProperty("choices")]
        public Choice[] Choices { get; set; }
    }

    public class Choice
    {
        [JsonProperty("display")]
        public string Display { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Action
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("target")]
        public string Target { get; set; }
    }

}
