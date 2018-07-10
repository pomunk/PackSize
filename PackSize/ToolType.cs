using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace PackSize
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ToolType
    {
        [EnumMember(Value = "Cross-Cut")]
        Cross_Cut,
        [EnumMember(Value = "Long-Cut")]
        Long_Cut
    }
}
