using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;	
using System.Linq;

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
            var result = JsonConvert.DeserializeObject<List<CountDown>>(Query.Get("http://iotdata.yhdf.fr/api/web/countdowns"));
            _ResultViewCountdown = "";
            var currentTimeStamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            foreach(var e in result){
                if (e.beginningDateEvent <= currentTimeStamp && e.endingDateEvent >= currentTimeStamp){
                    _ResultViewCountdown = "<div class=\"countdown-block\"> <div class=\"countdown-image box\"> <img class=\"mur\" src=\"data:image/png;base64, " +e.image + "\" alt=" + e.name + " >   </div>  <div class=\"countdown-text box\"> " +e.text+ "<div id=\"countdown-display\"> </div> <script> countDown(\" " + e.endingDateEvent + "  \",\"countdown-display\"); </script> </div> </div>";
                }
                else {
                }            
            }
        }
    }
}
