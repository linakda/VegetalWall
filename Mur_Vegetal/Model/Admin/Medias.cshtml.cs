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
        public void OnGet(){
            var result = JsonConvert.DeserializeObject<List<Medias>>(Query.Get("http://iotdata.yhdf.fr/api/web/medias"));
            _ResultViewAdminMedias = "";
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            foreach(var e in result){
                var beginningDate = epoch.AddSeconds(e.beginningDate).ToString("yyyy-MM-dd");
                var endingDate = epoch.AddSeconds(e.endingDate).ToString("yyyy-MM-dd");
                if(e.image != ""){
                    _ResultViewAdminMedias += "<div class=\"medias-param\"> <legend class=\"medias-name\">"+e.name+"</legend> <div class=\"param-name\"> <label class=\"param-name\">Nom de la photo : </label> <input type=\"text\" class=\"param-name\" placeholder=\"Ex: JPO\" value=\""+e.name+"\"> </div> <div class=\"param-img\"> <label class=\"param-img\">Image : </label> <img class=\"param-img\" src=\"data:image/png;base64, "+e.image+"\"><span><img src\"data:image/png;base64, "+e.image+"\" alt=\""+e.name+"\"></span> </div><div class=\"param-start-date\"> <label class=\"param-start-date\">Date de début : </label> <input class=\"param-start-date\" type=\"date\" value=\""+beginningDate+"\"> </div> <div class=\"param-end-date\"> <label class=\"param-end-date\">Date de fin : </label> <input class=\"param-end-date\" type=\"date\" value=\""+endingDate+"\"> </div> <div class=button> <button class=\"button-delete\"> Supprimer </button> <button class=\"button-apply\"> Valider </button> </div> </div>";
                }
                else if(e.video !=""){
                    _ResultViewAdminMedias += "<div class=\"medias-param\"> <legend class=\"medias-name\">"+e.name+"</legend> <div class=\"param-name\"> <label class=\"param-name\">Nom de la photo : </label> <input type=\"text\" class=\"param-name\" placeholder=\"Ex: JPO\" value=\""+e.name+"\"> </div> <div class=\"param-video\"> <label class=\"param-video\">Video : </label> <input type=\"text\" class=\"param-video\" placeholder=\"Ex: https://www.youtube.com/watch?v=WIIAbl7pBnI\" value=\""+e.video+"\"> </div> <div class=\"param-start-date\"> <label class=\"param-start-date\">Date de début : </label> <input class=\"param-start-date\" type=\"date\" value=\""+beginningDate+"\"> </div> <div class=\"param-end-date\"> <label class=\"param-end-date\">Date de fin : </label> <input class=\"param-end-date\" type=\"date\" value=\""+endingDate+"\"> </div> <div class=button> <button class=\"button-delete\"> Supprimer </button> <button class=\"button-apply\"> Valider </button> </div> </div>";
                }
                else {}
            }
        }
    }
}