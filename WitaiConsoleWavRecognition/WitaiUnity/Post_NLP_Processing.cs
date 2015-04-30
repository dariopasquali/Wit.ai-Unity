using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using System.Web;


namespace WitaiUnity
{
     
    
    static class Post_NLP_Processing
    {
        public static O_NLP.RootObject ParseData(string text)
        {
            // HTML-decode the string, in case it has been HTML encoded
            string jsonText = System.Web.HttpUtility.HtmlDecode(text);
            
            //Since object is reserved, put a _ in front
            jsonText = jsonText.Replace("\"object\" : {", "\"_object\" : {");
            

            //Deserialize into our class
            var rootObject = JsonConvert.DeserializeObject<O_NLP.RootObject>(jsonText);

            return rootObject;
        }
    }
}
