﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackSize
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TravelDirection
    {
        [EnumMember(Value = "Right")]
        Right,
        [EnumMember(Value = "Left")]
        Left,
        [EnumMember(Value = "Feed")]
        Feed
    }
}
