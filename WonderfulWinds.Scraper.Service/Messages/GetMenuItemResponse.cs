using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WonderfulWinds.Scraper.Model.Entities;

namespace WonderfulWinds.Scraper.Service.Messages
{
    public class GetMenuItemResponse:ResponseBase
    {
        public MenuItem Item { get; set; }
    }
}