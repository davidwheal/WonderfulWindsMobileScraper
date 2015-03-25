using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WonderfulWinds.Scraper.Service.Messages
{
    public class GetMenuItemsResponse : ResponseBase
    {
        public List<string> Items { get; set; }
    }
}