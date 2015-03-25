using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WonderfulWinds.Scraper.Model.Entities
{
    public class SampleUrl
    {
        public string Url { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}][{1}]",Url,Description);
        }
    }
}
