using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WonderfulWinds.Scraper.Model.Common;
using System.Text.RegularExpressions;

namespace WonderfulWinds.Scraper.Model.Entities
{

    public class MenuItem
    {
        public string SynopsisHtml { get; set; }
        public string Title { get; set; }
        public string BaseUri { get; set; }
        public Uri Href { get; set; }
        public List<CatalogueItem> Items { get; set; }


        public static HtmlDocument InMemoryModel = null;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var it in Items)
            {
                sb.Append(Title + "|" + it.ToString() + Environment.NewLine);
            }
            return sb.ToString();
        }

        public MenuItem(string baseUrl, string title, string hRef)
        {
            BaseUri = baseUrl;
            Title = title;
            Href = new Uri(BaseUri + @"/" + hRef);
            HtmlWeb web = new HtmlWeb()
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding("ISO-8859-1")
            };
            InMemoryModel = web.Load(Href.AbsoluteUri);
            GetCatalogueItems();
        }

        public bool GetCatalogueItems()
        {
            Console.WriteLine(Title);
            var node = InMemoryModel.GetElementbyId("pageSynopsis");
            if (node == null)
            {
                return false;
            }
            SynopsisHtml = HtmlEntity.DeEntitize(node.InnerHtml);

            //node = InMemoryModel.GetElementbyId("mainColumn");
            //var node1 = node.SelectSingleNode("div[@class='content']");
            //if (node1 == null)
            //    return false;

            //var node2 = node1.SelectSingleNode("div[@class='inner']");
            //if (node2 == null)
            //    return false;


            Items = new List<CatalogueItem>();

            var itemNodes = InMemoryModel.DocumentNode.SelectNodes("//table[contains(@id, 'anchor')]");
            if (itemNodes == null)
            {
                Console.WriteLine(string.Format("No anchor elements with catalogue items in {0}", Title));
                return false;
            }
            else
            {
                var count = itemNodes.Count;
                Console.WriteLine(string.Format("Found {0} catalogue items", count));
                foreach (var it in itemNodes)
                {
                    var cat = new CatalogueItem();


                    var rows = it.SelectNodes("tr");
                    if (rows == null)
                    {
                        rows = it.SelectNodes("tbody/tr");
                        if (rows == null)
                            return false;
                    }
                    int rowNum = 0;
                    Console.WriteLine(string.Format("Found {0} rows", rows.Count));
                    if (rows.Count != 5)
                    {
                        Console.WriteLine("Can't cope with tables with not 5 rows.");
                    }
                    int rowIndex = 0;
                    foreach (var row in rows)
                    {
                        // just get the pure html
                        switch (rowIndex)
                        {
                            case 0:
                                cat.TitleHtml = HtmlEntity.DeEntitize(row.InnerHtml);
                                break;
                            case 1:
                                cat.BodyHtml = HtmlEntity.DeEntitize(row.InnerHtml);
                                break;
                            case 2:
                                cat.PriceHtml = HtmlEntity.DeEntitize(row.InnerHtml);
                                break;
                        }
                        rowIndex++;
                        var columns = row.SelectNodes("td");
                        int colNum = 0;
                        foreach (var column in columns)
                        {

                            CatalogueItem.GetNewVersionInfo(cat, column);

                            CatalogueItem.GetGrading(cat, column);

                            CatalogueItem.GetDuration(cat, column);

                            //CatalogueItem.GetPrice(cat, column);

                            if (rowNum == 0 && colNum == 0)
                            {
                                var tit = column.SelectSingleNode(".//strong").InnerHtml;
                                var arr = tit.Split(' ');
                                cat.Code = arr[0];
                                cat.Title = HtmlEntity.DeEntitize(column.SelectSingleNode(".//strong").InnerHtml.Substring(cat.Code.Length, tit.Length - cat.Code.Length));
                                Console.WriteLine(cat.Title);
                            }
                            if (rowNum == 1 && colNum == 0)
                            {
                                //ProcessTextFields(it, cat);

                            }
                            if (rowNum == 1 && colNum == 0)
                            {
                                //var special = column.SelectSingleNode(".//strong");
                                //if (special != null)
                                //    cat.StrongText = special.InnerHtml;
                                cat.GetResourceFiles(column);


                                //    var descNode = column.SelectSingleNode("p");
                                //    if (descNode != null)
                                //    {
                                //        cat.Description = StringHandler.CleanUp(descNode.InnerText);
                                //    }
                            }
                            var priceNode = row.SelectSingleNode(".//div[contains (@id,'pricediv')]");
                            if (priceNode != null)
                            {
                                cat.Price = StringHandler.CleanUp(priceNode.InnerText);
                            }
                            //var postageNode = row.SelectSingleNode(".//div[contains (@id,'postagediv')]");
                            //if (postageNode != null)
                            //{
                            //    cat.Postage = StringHandler.CleanUp(postageNode.InnerText);
                            //    if (!string.IsNullOrEmpty(cat.Postage))
                            //    {
                            //    }
                            //}

                            colNum++;
                        }
                        rowNum++;
                    }
                    Items.Add(cat);

                }
#if DEBUG
                Logging.Write(this.ToString());
#endif
                return true;
            }
            //}
            //else
            //{
            //    Console.WriteLine("No mainwrapper");
            //}
            //return false;
        }



        private static void ProcessTextFields(HtmlNode it, CatalogueItem cat)
        {
            foreach (HtmlNode txt in it.SelectNodes(".//text()[normalize-space(.) != '']"))
            {
                //if (txt.InnerText.Trim().ToUpper().Contains("GRADING"))
                //{
                //    cat.Grading = StringHandler.CleanUp(txt.InnerText.Trim());
                //}

                //if (txt.InnerText.Trim().ToUpper().Contains("PLEASE NOTE"))
                //{
                //    cat.PleaseNote = StringHandler.CleanUp(txt.InnerText.Trim());
                //}
                //if (txt.InnerText.Trim().ToUpper().Contains("DURATION"))
                //{
                //    cat.Duration = StringHandler.CleanUp(txt.InnerText.Trim());
                //}
            }
        }


    }
}
