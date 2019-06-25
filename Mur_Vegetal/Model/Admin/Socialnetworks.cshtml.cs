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
    public class SocialnetworksAdminModel : PageModel
    {
        public class Social
        {
            public string username { get; set; }
            public string pageWidget { get; set; }
            public string widget { get; set; }
            public string id { get; set; }
        }
        public string Answer { get; private set; }
        public void OnGet()
        {
            Answer = Query.Get("http://iotdata.yhdf.fr/api/web/socials");
            var result = JsonConvert.DeserializeObject<List<Social>>(Answer);
        }
    }
}