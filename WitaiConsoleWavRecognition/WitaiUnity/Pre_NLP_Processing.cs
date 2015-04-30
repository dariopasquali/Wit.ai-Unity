using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WitaiUnity
{
    static class Pre_NLP_Processing
    {
        public static string preprocessText(string text)
        {
            // Max length is 255
            if (text.Length > 255)
            {
                text = text.Substring(0, 255);
            }

            // Convert spaces etc
            string modtext = HttpUtility.UrlPathEncode(text);

            return modtext;
        }
    }
}
