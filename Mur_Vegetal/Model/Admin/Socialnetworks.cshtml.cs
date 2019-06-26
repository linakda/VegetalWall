using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


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
        public string _ResultViewAdminSocialnetworks { get; private set; }

        public void OnGet()
        {
            var result = JsonConvert.DeserializeObject<List<Social>>(Query.Get("http://iotdata.yhdf.fr/api/web/socials"));
            _ResultViewAdminSocialnetworks = "";
            foreach(var e in result){
                _ResultViewAdminSocialnetworks += "<div class=\"home-param\"> <legend class=\"home-name\"> Page : " +e.pageWidget + "</legend> <div class=\"page-param\"> <label class=\"page-param\">Nom de page : </label> <input type=\"text\" class=\"page-param\" placeholder=\" " + e.pageWidget + "  \"> </div> <div class=\"widget-param\"> <label class=\"widget-param\">Lien widget : </label> <input type=\"text\" class=\"widget-param\" placeholder=\" " +e.widget + " \"> </div> <div class=button> <button class=\"button-apply\"> Valider </button> </div> </div>";
            }
        }
    }
}