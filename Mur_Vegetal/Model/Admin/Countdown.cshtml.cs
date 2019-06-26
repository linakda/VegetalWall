using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Mur_Vegetal.Pages
{
    public class CountdownAdminModel : PageModel{
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

         public List <CountDown> Result { get; private set; }

         public bool IsError { get; private set; }
        public void OnGet(){
            var requestCountdown = Query.Get("http://iotdata.yhdf.fr/api/web/countdowns");
            if(requestCountdown == "Error" || String.IsNullOrEmpty(requestCountdown)){
                IsError = true;
            }
            else{
                IsError = false;
                Result = JsonConvert.DeserializeObject<List<CountDown>>(requestCountdown); 
            }
        }
    }
}