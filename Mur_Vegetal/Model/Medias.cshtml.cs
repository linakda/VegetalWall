using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

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
        public string _ResultViewMedias {get; private set;}
        public void OnGet(){

            var requestMedia = Query.Get("http://iotdata.yhdf.fr/api/web/medias");
            if(requestMedia == "Error" || String.IsNullOrEmpty(requestMedia)){
                _ResultViewMedias = "<div class=\"media-block box \">Error Api</div> ";
            }
            else {
                var result = JsonConvert.DeserializeObject<List<Medias>>(requestMedia);
                _ResultViewMedias = "";
                var currentTimeStamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                foreach(var e in result){
                    if (e.beginningDate <= currentTimeStamp && e.endingDate >= currentTimeStamp){
                        if(e.image != ""){
                            _ResultViewMedias += "<div class=\"medias-block\"> <div class=\"medias-image box\"> <img src=\"data:image/png;base64, " +e.image + "\" alt=" + e.name + " > </div> </div>";
                        }
                        else if(e.video !=""){
                            string pattern = @"([a-zA-Z0-9]+)\z";
                            Match m = Regex.Match(e.video, pattern, RegexOptions.IgnoreCase);
                            if (m.Success){
                                _ResultViewMedias += "<div class=\"medias-block\"> <div class=\"medias-video box\"> <iframe src=\"https://www.youtube.com/embed/" + m.Groups[1].Value + " \" width=\"100%\" frameborder=\"0\" allowfullscreen></iframe> </div> </div>";
                            }
                            else {
                            }
                        }
                        else{}
                    }
                    else {
                    }
                }
            }
        }

    }
}
