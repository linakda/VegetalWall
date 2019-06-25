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
    public class MediasModel : PageModel{
        public class Medias
        {
            public string name { get; set; }
            public int beginningDate { get; set; }
            public int endingDate { get; set; }
            public string video { get; set; }
            public string image { get; set; }
            public string id { get; set; }
        }
        public string Answer { get; private set; }
        public string _ResultViewMedias {get; private set;}
        public void OnGet(){
            Answer = Query.Get("http://iotdata.yhdf.fr/api/web/medias");
            var result = JsonConvert.DeserializeObject<List<Medias>>(Answer);
            _ResultViewMedias = "";
            foreach(var e in result){
                if(e.image != ""){
                    _ResultViewMedias += "<div class=\"medias-block\"> <div class=\"medias-image box\"> <img src=\"data:image/png;base64, " +e.image + "\" alt=" + e.name + " > </div> </div>";
                }
                else if(e.video !=""){
                    _ResultViewMedias += "<div class=\"medias-block\"> <div class=\"medias-video box\"> <iframe src=\" " + e.video + " \" width=\"100%\" frameborder=\"0\" allowfullscreen></iframe> </div> </div>";
                }
                else{}
            }
        }

    }
}
