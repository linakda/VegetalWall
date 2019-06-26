using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace Mur_Vegetal.Pages{
    public class MediasAdminModel : PageModel{
         public class Medias{
            public string name { get; set; }
            public int beginningDate { get; set; }
            public int endingDate { get; set; }
            public string video { get; set; }
            public string image { get; set; }
            public string id { get; set; }
        }
        public string _ResultViewAdminMedias { get; private set; }
        public List <Medias> Result { get; private set; }
        public void OnGet(){

            var requestMedia = Query.Get("http://iotdata.yhdf.fr/api/web/medias");
            if(requestMedia == "Error" || String.IsNullOrEmpty(requestMedia)){
                _ResultViewAdminMedias = "<div class=\"medias-param\"> Error Api </div>";
            }
            else {
                Result = JsonConvert.DeserializeObject<List<Medias>>(requestMedia); 
            }
        }

        public void OnPost(){
            var emailAddress = Request.Form["name"];
            Console.WriteLine(emailAddress);
            OnGet();
        }
    }
}