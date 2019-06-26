using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Mur_Vegetal.Pages
{
    public class CountdownAdminModel : PageModel{
        public class CountDown{
            public string text { get; set; }
            public string name { get; set; }
            public int endingDateEvent { get; set; }
            public int beginningDateEvent { get; set; }
            public int endingDateCountdown { get; set; }
            public int position { get; set; }
            public object image { get; set; }
            public string id { get; set; }
        }
         public string _ResultViewAdminCountdown {get; private set;}
        public void OnGet(){
            var result = JsonConvert.DeserializeObject<List<CountDown>>(Query.Get("http://iotdata.yhdf.fr/api/web/countdowns"));
            _ResultViewAdminCountdown = "";
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            foreach(var e in result){
                var endingDateCountdown = epoch.AddSeconds(e.endingDateCountdown).ToString("yyyy-MM-dd");
                var beginningDateEvent = epoch.AddSeconds(e.beginningDateEvent).ToString("yyyy-MM-dd");
                var endingDateEvent = epoch.AddSeconds(e.endingDateEvent).ToString("yyyy-MM-dd");
                _ResultViewAdminCountdown += "<div class=\"countdown-param\"> <legend class=\"coutndown-name\">"+e.name+"</legend> <div class=\"param-name\"> <label class=\"param-name\">Nom du compte à rebours : </label> <input type=\"text\" class=\"param-name\" placeholder=\"Ex: JPO\" value=\""+e.name+"\"> </div> <div class=\"param-text\"> <label class=\"param-text\">Texte : </label> <textarea class=\"param-text\" rows=\"5\" cols=\"60\" placeholder=\"Entrez votre texte\">"+e.text+"</textarea> </div> <div class=\"param-img\"> <label class=\"param-img\">Image : </label> <img class=\"mur\" src=\"data:image/png;base64, " +e.image + "\" alt=" + e.name + " > </div> <div class=\"param-start-date\"> <label class=\"param-start-date\">Date de début : </label> <input class=\"param-start-date\" type=\"date\" value=\""+beginningDateEvent+"\"> </div> <div class=\"param-end-date\"> <label class=\"param-end-date\">Date de fin : </label> <input class=\"param-end-date\" type=\"date\" value=\""+endingDateEvent+"\"> </div> <div class=\"param-countdown-date\"> <label class=\"param-end-date\">Date compteur : </label> <input class=\"param-end-date\" type=\"date\" value=\""+endingDateCountdown+"\"> </div> <div class=button> <button class=\"button-delete\"> Supprimer </button> <button class=\"button-apply\"> Valider </button> </div> </div>";
            }
        }
    }
}