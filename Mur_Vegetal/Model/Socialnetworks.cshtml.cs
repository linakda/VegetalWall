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
    public class SocialnetworksModel : PageModel
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
            Answer = Query.Get("http://10.34.160.10:4001/api/web/socials");
            var result = JsonConvert.DeserializeObject<List<Social>>(Answer);
            foreach(var elts in result){
                Console.Write("IdSensors : " + elts.username);
                Console.Write("Type : " + elts.pageWidget);
                Console.Write("projet : " + elts.widget);
                Console.Write("Name : " + elts.id);
            }
        }
    }
}
