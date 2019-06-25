using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Mur_Vegetal.Pages{
    public class FrameAdminModel : PageModel{
        public class Frame{
            public int onScreenTime { get; set; }
            public bool isOnScreen { get; set; }
            public string name { get; set; }
            public int carrousselTime { get; set; }
            public string id { get; set; }
        }
        public string _ResultViewAdminFrame {get; private set;}

        public void OnGet(){
            var result = JsonConvert.DeserializeObject<List<Frame>>(Query.Get("http://iotdata.yhdf.fr/api/web/tables"));
            _ResultViewAdminFrame = "";
            foreach(var e in result){
                if (e.isOnScreen == true){
                    _ResultViewAdminFrame = "<div class=\"frame-param\"><legend class=\"frame-name\">"+e.name+"</legend><div class=\"param-disp\"><label class=\"param-disp\">Affichage </label><input type=\"checkbox\" class=\"param-disp\" checked></div><div class=\"param-disptime\"><label class=\"param-disptime\">Temps d'affichage : </label><input list=\"Sec\" type=\"text\" class=\"param-disptime\" placeholder=\"En secondes\" value=\""+e.onScreenTime+"\"><datalist id=\"Sec\"><option value=\"10\"></option><option value=\"20\"></option><option value=\"30\"></option><option value=\"40\"></option><option value=\"50\"></option><option value=\"60\"></option><option value=\"120\"></option></datalist></div><div class=\"param-carroussel\"> <label class=\"param-carroussel\">Temps d'affichage du carroussel : </label> <input list=\"Sec\" type=\"text\" class=\"param-carroussel\" placeholder=\"En secondes\" value=\""+e.carrousselTime+"\"> <datalist id=\"Sec\"> <option value=\"10\"></option> <option value=\"20\"></option> <option value=\"30\"></option> <option value=\"40\"></option> <option value=\"50\"></option> <option value=\"60\"></option> <option value=\"120\"></option> </datalist> </div> <div class=button> <button class=\"button-apply\"> Valider </button> </div> </div>";
                }
                else {
                    _ResultViewAdminFrame = "<div class=\"frame-param\"><legend class=\"frame-name\">"+e.name+"</legend><div class=\"param-disp\"><label class=\"param-disp\">Affichage </label><input type=\"checkbox\" class=\"param-disp\"></div><div class=\"param-disptime\"><label class=\"param-disptime\">Temps d'affichage : </label><input list=\"Sec\" type=\"text\" class=\"param-disptime\" placeholder=\"En secondes\" value=\""+e.onScreenTime+"\"><datalist id=\"Sec\"><option value=\"10\"></option><option value=\"20\"></option><option value=\"30\"></option><option value=\"40\"></option><option value=\"50\"></option><option value=\"60\"></option><option value=\"120\"></option></datalist></div><div class=\"param-carroussel\"> <label class=\"param-carroussel\">Temps d'affichage du carroussel : </label> <input list=\"Sec\" type=\"text\" class=\"param-carroussel\" placeholder=\"En secondes\" value=\""+e.carrousselTime+"\"> <datalist id=\"Sec\"> <option value=\"10\"></option> <option value=\"20\"></option> <option value=\"30\"></option> <option value=\"40\"></option> <option value=\"50\"></option> <option value=\"60\"></option> <option value=\"120\"></option> </datalist> </div> <div class=button> <button class=\"button-apply\"> Valider </button> </div> </div>";
                }
            }
        }
    }
}