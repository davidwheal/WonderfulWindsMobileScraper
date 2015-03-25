using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WonderfulWinds.Scraper.Service.Messages
{
    public class GetMenuItemCountResponse : ResponseBase
    {
        public int Count { get; set; }
    }
}