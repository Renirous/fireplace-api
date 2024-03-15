﻿using Newtonsoft.Json.Serialization;
using System.Text.Json;

namespace FireplaceApi.Api.Tools
{
    public class KebabCaseNamingPolicy : JsonNamingPolicy
    {
        private readonly SnakeCaseNamingStrategy _newtonsoftSnakeCaseNamingStrategy = new SnakeCaseNamingStrategy();

        public static KebabCaseNamingPolicy Instance { get; } = new KebabCaseNamingPolicy();

        public override string ConvertName(string name)
        {
            return _newtonsoftSnakeCaseNamingStrategy.GetPropertyName(name, false).Replace("_", "-");
        }
    }
}
