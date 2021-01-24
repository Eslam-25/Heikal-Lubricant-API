﻿using Newtonsoft.Json;

namespace lubricant_api.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public string InnerException { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}