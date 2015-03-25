using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WonderfulWinds.Scraper.Model.Common
{
    public static class StringHandler
    {

        //public static string RemoveDiacritics(this string s)
        //{
        //    // split accented characters into surrogate pairs
        //    IEnumerable<char> chars = s.Normalize(NormalizationForm.FormD);
        //    // remove all non-ASCII characters – i.e. the accents
        //    return new string(chars.Where(c => c < 0x7f && !char.IsControl(c)).ToArray());
        //}
        public static string CleanUp (string message)
        {
            var newMessage = string.Empty;
            foreach (var s in message)
            {
                if ((int)s < 0x7f && (int)s>=0x20)
                {
                    newMessage+=s;
                }
                else
                {
                    newMessage+=' ';
                }
            }
            message = newMessage;
            message = message.Replace("&nbsp;", " ");
            message = message.Replace("&pound;", "£");
            message = message.Replace("&#163;", "£");

            return message;
            //RegexOptions options = RegexOptions.None;
            //Regex regex = new Regex(@"[ ]{2,}", options);
            //return regex.Replace(message, @" ");
        }
    }
}
