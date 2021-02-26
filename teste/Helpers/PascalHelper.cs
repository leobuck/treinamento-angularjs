﻿using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Buffers;
using System.Text;


namespace teste.Helpers
{
    public class PascalCaseDictionaryKeyNamingStrategy : DefaultNamingStrategy
    {
        public PascalCaseDictionaryKeyNamingStrategy() : base() { this.ProcessDictionaryKeys = true; }

        public override string GetDictionaryKey(string key)
        {
            if (ProcessDictionaryKeys && !string.IsNullOrEmpty(key))
            {
                if (char.ToUpperInvariant(key[0]) != key[0])
                {
                    var builder = new StringBuilder(key);
                    builder[0] = char.ToUpperInvariant(key[0]);
                    return builder.ToString();
                }
            }
            return key;
        }
    }
}
