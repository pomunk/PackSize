using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum HeadType
    {
        [EnumMember(Value = "Cut")]
        Cut,
        [EnumMember(Value = "Crease")]
        Crease
    }
}
