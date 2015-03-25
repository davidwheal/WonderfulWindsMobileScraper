using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WonderfulWinds.Scraper.Service.Messages
{
    public class ResponseBase
    {
        public string StatusText { get; set; }
        public int StatusCode { get; set; }
    }
}