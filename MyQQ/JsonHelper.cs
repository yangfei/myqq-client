﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQQ
{
    public static class JsonHelper
    {
        private static readonly JsonSerializerSettings MyJsonSerializerSettings;

        static JsonHelper()
        {
            MyJsonSerializerSettings = new JsonSerializerSettings();
            IsoDateTimeConverter dateTimeConverter = new IsoDateTimeConverter();
            dateTimeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            MyJsonSerializerSettings.Converters.Add(dateTimeConverter);
        }

        public static T DeserializeObject<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(json, MyJsonSerializerSettings);
        }

        public static string SerializeObject<T>(T data)
        {
            return JsonConvert.SerializeObject(data, MyJsonSerializerSettings);
        }
    }
}
