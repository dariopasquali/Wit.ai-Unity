﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WitaiUnity
{
    class O_NLP
    {
        public class RootObject
        {
            public string msg_id { get; set; }
            public string _text { get; set; }
            public string msg_body { get; set; }
            public _Outcome[] outcomes { get; set; }
        }

        public class _Outcome
        {
            public string _text { get; set; }
            public string intent { get; set; }
            public _Entities entities { get; set; }
            public double confidence { get; set; }
        }

        // You should add your custom entities here
        // Can be single or array, will always be cast to an array
        public class _Entities
        {


            [JsonConverter(typeof(JsonToArrayConverter<_Object>))]
            public _Object[] _object { get; set; }

            [JsonConverter(typeof(JsonToArrayConverter<_Target_Temperature>))]
            public _Target_Temperature[] target_temperature { get; set; }

            [JsonConverter(typeof(JsonToArrayConverter<_On_Off>))]
            public _On_Off[] on_off { get; set; }
        }

        /*
        public class _Target_Temperature
        {
            public int end { get; set; }
            public int start { get; set; }
            public string role { get; set; }
            public _Val value { get; set; }
            public string body { get; set; }
        }

        public class _Val
        {
            public double temperature { get; set; }
        }
        */

        public class _On_Off
        {
            public string value { get; set; }
        }

       

        public class _Target_Temperature
        {
            public double value { get; set; }
            public string type { get; set; }
            public string unit { get; set; }
        }



        public class _Object
        {
            public int end { get; set; }
            public int start { get; set; }
            public string value { get; set; }
            public string body { get; set; }
        }

        

        // Converts single values to arrays
        public class JsonToArrayConverter<T> : CustomCreationConverter<T[]>
        {
            public override T[] Create(Type objectType)
            {
                return new T[0];
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.StartArray)
                {
                    object result = serializer.Deserialize(reader, objectType);
                    return result;
                }
                else
                {
                    var resultObject = serializer.Deserialize<T>(reader);
                    return new T[] { resultObject };
                }
            }
        }
    }
}
