using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;

namespace Mur_Vegetal.Pages{
    public class FrameAdminModel : PageModel{
        public class Frame{
            public int onScreenTime { get; set; }
            public bool isOnScreen { get; set; }
            public string name { get; set; }
            public int carrousselTime { get; set; }
            public string id { get; set; }
        }

        public List <Frame> Result { get; private set; }
        public bool IsError { get; private set; }
        public void OnGet(){
            var requestFrame = Query.Get("http://iotdata.yhdf.fr/api/web/tables");
            if(requestFrame == "Error" || String.IsNullOrEmpty(requestFrame)){
                IsError = true;
            }
            else{
                IsError = false;
                Result = JsonConvert.DeserializeObject<List<Frame>>(requestFrame); 
            }
        }
    }
}