using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;

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
        public string _ResultViewSocialnetworks {get; private set;}
        public void OnGet()
        {
            var requestSocial = Query.Get("http://iotdata.yhdf.fr/api/web/socials");
            if(requestSocial=="Error" || String.IsNullOrEmpty(requestSocial)){
                _ResultViewSocialnetworks = "<div style=\"color:green; \"> Error Api </div>";
            }
            else{
                var result = JsonConvert.DeserializeObject<List<Social>>(requestSocial);
                _ResultViewSocialnetworks = "";
                foreach(var e in result){
                    if(e.pageWidget == "socialnetworks"){
                        _ResultViewSocialnetworks += "<script src=\"https://snapwidget.com/js/snapwidget.js\"></script> <iframe src=\" " + e.widget + " \" class=\"snapwidget-widget\" allowtransparency=\"true\" frameborder=\"0\" scrolling=\"no\" style=\"border:none; overflow:hidden; width:100%;\"></iframe>";

                    }
                }
            }
        }
    }
}
