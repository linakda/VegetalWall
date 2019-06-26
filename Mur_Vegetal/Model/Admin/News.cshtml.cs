using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Mur_Vegetal.Pages
{
    public class NewsAdminModel : PageModel{
         public class News{
            public string name { get; set; }
            public int eventDate { get; set; }
            public int beginningDate { get; set; }
            public string eventImage { get; set; }
            public int endingDate { get; set; }
            public string text { get; set; }
            public int position { get; set; }
            public string id { get; set; }
        }
        public string _ResultViewAdminNews { get; private set; }
        public void OnGet(){
            var result = JsonConvert.DeserializeObject<List<News>>(Query.Get("http://iotdata.yhdf.fr/api/web/events"));
            _ResultViewAdminNews = "";
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            foreach(var e in result){
                var endingDate = epoch.AddSeconds(e.endingDate).ToString("yyyy-MM-dd");
                var beginningDate = epoch.AddSeconds(e.beginningDate).ToString("yyyy-MM-dd");
                _ResultViewAdminNews += "<div class=\"news-param\"> <legend class=\"news-name\">"+e.name+"</legend> <div class=\"param-name\"> <label class=\"param-name\">Nom de l'événement : </label> <input type=\"text\" class=\"param-name\" placeholder=\"Ex: JPO\" value=\""+e.name+"\"> </div> <div class=\"param-text\"> <label class=\"param-text\">Texte : </label> <textarea class=\"param-text\" rows=\"5\" cols=\"60\" placeholder=\"Entrez votre texte\">"+e.text+"</textarea> </div> <div class=\"param-img\"> <label class=\"param-img\">Image : </label> <img class=\"param-img\" src=\"data:image/png;base64, " +e.eventImage + "\" alt=" + e.name + " ><span><img src=\"data:image/png;base64, "+e.eventImage+"\" alt=\""+e.name+"\"></span> </div> <div class=\"param-start-date\"> <label class=\"param-start-date\">Date de début : </label> <input class=\"param-start-date\" type=\"date\" value=\""+beginningDate+"\"> </div> <div class=\"param-end-date\"> <label class=\"param-end-date\">Date de fin : </label> <input class=\"param-end-date\" type=\"date\" value=\""+endingDate+"\"> </div> <div class=button> <button class=\"button-delete\"> Supprimer </button> <button class=\"button-apply\"> Valider </button> </div> </div>";
            }
        }
    }
}