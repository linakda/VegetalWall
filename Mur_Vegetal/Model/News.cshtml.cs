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
    public class NewsModel : PageModel{

        public class News
        {
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
        public void OnGet(){
            Answer = Query.Get("http://10.34.160.10:4001/api/web/events");
            var result = JsonConvert.DeserializeObject<List<News>>(Answer);
        }
    }
}
