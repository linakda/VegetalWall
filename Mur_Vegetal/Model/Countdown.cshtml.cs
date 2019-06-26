using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Mur_Vegetal.Pages
{
    public class CountdownModel : PageModel{

        public class CountDown{
            public string text { get; set; }
            public string name { get; set; }
            public int endingDateEvent { get; set; }
            public int beginningDateEvent { get; set; }
            public int endingDateCountdown { get; set; }
            public int position { get; set; }
            public object image { get; set; }
            public string id { get; set; }
        }
        public string _ResultViewCountdown {get; private set;}
        public void OnGet(){

            var requestCountdown = Query.Get("http://iotdata.yhdf.fr/api/web/countdowns");
            if(requestCountdown=="Error" || String.IsNullOrEmpty(requestCountdown)){
                _ResultViewCountdown = "<div class=\" countdown-block box\">Error Api</div>";
            }
            else {
                var result = JsonConvert.DeserializeObject<List<CountDown>>(requestCountdown);
                _ResultViewCountdown = "";
                var currentTimeStamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                CountDown lastCountdown;
                foreach(var e in result){
                    lastCountdown = e;
                    if(lastCountdown.endingDateEvent > e.endingDateCountdown){
                        lastCountdown = e;
                    }
                    if (lastCountdown.beginningDateEvent <= currentTimeStamp && lastCountdown.endingDateEvent >= currentTimeStamp){
                        _ResultViewCountdown = "<div class=\"countdown-block\"> <div class=\"countdown-image box\"> <img class=\"mur\" src=\"data:image/png;base64, " +lastCountdown.image + "\" alt=" + lastCountdown.name + " >   </div>  <div class=\"countdown-text box\"> " +lastCountdown.text+ "<div id=\"countdown-display\"> </div> <script> countDown(\" " + lastCountdown.endingDateCountdown + "  \",\"countdown-display\"); </script> </div> </div>";
                    }
                    else {
                    }            
                }
            }
        }
    }
}
