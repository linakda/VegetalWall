using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;


namespace Mur_Vegetal.Pages
{
    public class SocialnetworksAdminModel : PageModel{
        public class Social{
            public string username { get; set; }
            public string pageWidget { get; set; }
            public string widget { get; set; }
            public string id { get; set; }
        }
        
        public List <Social> Result { get; private set; }
        public bool IsError { get; private set; }
        public void OnGet(){
            var requestSocialnetworks = Query.Get("http://iotdata.yhdf.fr/api/web/socials");
            if(requestSocialnetworks == "Error" || String.IsNullOrEmpty(requestSocialnetworks)){
                IsError = true;
            }
            else{
                IsError = false;
                Result = JsonConvert.DeserializeObject<List<Social>>(requestSocialnetworks); 
            }
        }

        public void OnPost(){
            var username = Request.Form["username"];
            var pageWidget = Request.Form["pagewidget"];
            var widget = Request.Form["widget"];
            var submit = Request.Form["submit"];
            var id = Request.Form["id"];
            if(submit == "edit"){
                Social toEdit = new Social();
                toEdit.widget = widget;
                toEdit.pageWidget = pageWidget;
                toEdit.username = username;
                toEdit.id = id;
                var data =  JsonConvert.SerializeObject(toEdit);
                var result = Query.Put("http://iotdata.yhdf.fr/api/web/socials/"+toEdit.id,data);
            }
            OnGet();
        }
    }
}