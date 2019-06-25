using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;

namespace Mur_Vegetal.Pages
{
    public class NewsModel : PageModel{

        public class News{
            public string name { get; set; }
            public int eventDate { get; set; }
            public int beginningDate { get; set; }
            public string eventImage { get; set; }
            public int endingDate { get; set; }
            public string text { get; set; }
            public int position { get; set; }
            public string id { get; set; }
        }
        public string Answer { get; private set; }

        public string _ResultViewNews { get; private set; }
        public void OnGet(){
            //Answer = Query.Get("http://iotdata.yhdf.fr/api/web/events");
            var result = JsonConvert.DeserializeObject<List<News>>(Query.Get("http://iotdata.yhdf.fr/api/web/events"));
            _ResultViewNews = "";
            var currentTimeStamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            foreach(var e in result){
                /* if (){

                }
                else {

                }*/
                _ResultViewNews += "<div class=\"news-block\"><div class=\"news-image box\"><img src=\"data:image;base64, "+e.eventImage+"\"/></div><div class=\"news-text box\">"+e.text+"</div></div>";
            }
            _ResultViewNews = currentTimeStamp.ToString();;
        }
    }
}
