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
    public class CountdownModel : PageModel
    {

        public class CountDown
        {
            public string type { get; set; }
            public string title { get; set; }
            public int status { get; set; }
            public string traceId { get; set; }
        }
        public string Answer { get; private set; }
        public void OnGet()
        {
            Answer = Query.Get("http://10.34.160.10:4001/api/web/countdown");
            var result = JsonConvert.DeserializeObject<List<CountDown>>(Answer);
        }
    }
}
