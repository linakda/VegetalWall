using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Query;

namespace Mur_Vegetal.Pages
{
    public class NewsModel : PageModel{
        public string Answer { get; private set; }
        public void OnGet(){
            //Answer = Query.Get("http://10.34.160.10:4001/api/web/sensors");
        }
    }
}
