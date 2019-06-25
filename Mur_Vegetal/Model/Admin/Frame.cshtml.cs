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
    public class FrameAdminModel : PageModel
    {
        public class Frame
        {
            public int onScreenTime { get; set; }
            public bool isOnScreen { get; set; }
            public string name { get; set; }
            public int carrousselTime { get; set; }
            public string id { get; set; }
        }
        public string Answer { get; private set; }
        public void OnGet()
        {
            Answer = Query.Get("http://10.34.160.10:4001/api/web/tables");
            var result = JsonConvert.DeserializeObject<List<Frame>>(Answer);
        }
    }
}