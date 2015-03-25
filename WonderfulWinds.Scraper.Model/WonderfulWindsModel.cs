using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WonderfulWinds.Scraper.Model.Common;
using WonderfulWinds.Scraper.Model.Entities;

namespace WonderfulWinds.Scraper.Model
{
    public class WonderfulWindsModel
    {
        private static HtmlDocument InMemoryModel = null;

        private static SortedList<int, MenuItem> ConvertedModel = null;

        public WonderfulWindsModel()
        {
            HtmlWeb web = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding("ISO-8859-1")
            };
            //CustomEncoding enc = new CustomEncoding();
            InMemoryModel = web.Load("http://www.wonderfulwinds.com/index.htm");
            ConvertedModel = ReadMenuItems();
        }

        private SortedList<int, MenuItem> ReadMenuItems()
        {
            var node = InMemoryModel.GetElementbyId("mainWrapper");
            var menuNodes = node.SelectNodes(".//span[@class='menuspan']");
            var hrefNodes = node.SelectNodes(".//a[@target='_parent']");
            var result = new SortedList<int, MenuItem>();
            int index = 0;
#if DEBUG
            Logging.Open();
#endif
            foreach (var menuNode in menuNodes)
            {
                result.Add(index, new MenuItem("http://www.wonderfulwinds.com", menuNode.ChildNodes[0].InnerHtml, hrefNodes[index].Attributes[1].Value));
                index++;
            }
            return result;
        }



        public int GetMenuCount()
        {
            return ConvertedModel.Count;
        }

        public List<string> GetMenu()
        {
            var menu = from v in ConvertedModel.Values select v.Title;
            return menu.ToList();
        }



        public MenuItem GetMenuItem(int index)
        {
            return ConvertedModel[index];
        }

    }
}
