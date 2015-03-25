using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using WonderfulWinds.Scraper.Model.Common;

namespace WonderfulWinds.Scraper.Model.Entities
{

    public class CatalogueItem
    {

        public CatalogueItem()
        {
            New = false;
            //Urls = new List<SampleUrl>();
        }

        public string Code { get; set; }
        public string Title { get; set; }
        //public string Description { get; set; }
        //public string StrongText { get; set; }
        public string Grading { get; set; }
        public string Duration { get; set; }
        public bool New { get; set; }
        //public List<SampleUrl> Urls { get; set; }
        public SampleUrl VideoUrl { get; set; }
        public SampleUrl SoundUrl { get; set; }
        public SampleUrl PrintUrl { get; set; }

        public string Price { get; set; }
        //public string Postage { get; set; }
        //public string PleaseNote { get; set; }

        public string TitleHtml { get; set; }
        public string BodyHtml { get; set; }
        public string PriceHtml { get; set; }


        public override string ToString()
        {
          
            
            return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", Code, Title, Duration, Grading, New, Price,VideoUrl,SoundUrl,PrintUrl);
        }


        public static void GetGrading(CatalogueItem cat, HtmlNode column)
        {
            var reg = new Regex(@"GRADING:([\d -])*");
            var matches = reg.Matches(column.InnerText.ToUpper());
            if (matches.Count > 0)
                cat.Grading = matches[0].Value.Substring(8, matches[0].Value.Length - 8);
        }

        public static void GetDuration(CatalogueItem cat, HtmlNode column)
        {
            var reg = new Regex(@"DURATION:([\d-' ])*");
            var matches = reg.Matches(column.InnerText.ToUpper());
            if (matches.Count > 0)
                cat.Duration = matches[0].Value.Substring(9, matches[0].Value.Length - 9);
        }



        public static void GetNewVersionInfo(CatalogueItem cat, HtmlNode column)
        {
            if (column.InnerText.ToUpper().Contains("*NEW VERSION*"))
            {
                cat.New = true;
            }

        }

        /// <summary>
        /// Extract pdfs and mp3s
        /// </summary>
        /// <param name="cat"></param>
        /// <param name="links"></param>
        public void GetResourceFiles(HtmlNode column)
        {
            var links = column.SelectNodes(".//a");

            if (links != null)
            {
                foreach (var link in links)
                {
                    var atts = link.Attributes;
                    foreach (var att in atts)
                    {
                        if (att.Name == "href" && att.Value.ToUpper().Contains("HTTP://"))
                        {
                            if (att.Value.ToUpper().Contains(".MP3"))
                            {
                                SoundUrl = new SampleUrl() { Url = att.Value, Description = StringHandler.CleanUp(link.InnerText) };
                            }
                            if (att.Value.ToUpper().Contains(".PDF"))
                            {
                                PrintUrl = new SampleUrl() { Url = att.Value, Description = StringHandler.CleanUp(link.InnerText) };
                            }
                            if (att.Value.ToUpper().Contains("YOUTUBE"))
                            {
                                VideoUrl = new SampleUrl() { Url = att.Value, Description = StringHandler.CleanUp(link.InnerText) };
                            }

                            //Urls.Add(new SampleUrl() { Url = att.Value, Description = StringHandler.CleanUp(link.InnerText) });
                        }
                       
                    }
                }
            
            }
        }
    }
}
