using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;

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

         public List <CountDown> Result { get; private set; }

         public IFormFile ImageUpload { get; set; }

         public bool IsError { get; private set; }
        public void OnGet(){
            var requestCountdown = Query.Get("http://iotdata.yhdf.fr/api/web/countdowns");
            if(requestCountdown == "Error" || String.IsNullOrEmpty(requestCountdown)){
                IsError = true;
            }
            else{
                IsError = false;
                Result = JsonConvert.DeserializeObject<List<CountDown>>(requestCountdown); 
            }
        }

        public void OnPost(){
            var name = Request.Form["name"];
            var text = Request.Form["text"];
            var startdate = ((DateTimeOffset)DateTime.Parse(Request.Form["startdate"])).ToUnixTimeSeconds();
            var enddate = ((DateTimeOffset)DateTime.Parse(Request.Form["enddate"])).ToUnixTimeSeconds();
            var countdowndate = 0;//transform string to date
            var countdowntime = 0;//transform string to time
            var totalcountdown = 0 //mix date + time
            var submit = Request.Form["submit"];
            var id = Request.Form["id"];
            if(submit == "add"){
                CountDown toAdd = new CountDown();
                toAdd.name = name;
                toAdd.beginningDateEvent = Convert.ToInt32(startdate);
                toAdd.endingDateEvent = Convert.ToInt32(enddate);
                toAdd.endingDateCountdown = totalcountdown;
                toAdd.text = text;
                if (ImageUpload != null){
                    using (var ms = new MemoryStream()){
                    ImageUpload.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    toAdd.image = Convert.ToBase64String(fileBytes);
                    }
                }
                else {
                    toAdd.image = "";
                }
                var data =  JsonConvert.SerializeObject(toAdd);
                var result = Query.Post("http://iotdata.yhdf.fr/api/web/countdowns/",data);
            }
            else if(submit == "edit"){
                var image = Request.Form["image"];
                CountDown toEdit = new CountDown();
                if (!String.IsNullOrEmpty(image)){
                    toEdit.image = image;
                };
                else {
                    toEdit.image = "";
                }
                toEdit.text = text;
                toEdit.name = name;
                toEdit.beginningDateEvent = Convert.ToInt32(startdate);
                toEdit.endingDateEvent = Convert.ToInt32(enddate);
                toEdit.endingDateCountdown = totalcountdown;
                toEdit.id = id;
                var data =  JsonConvert.SerializeObject(toEdit);
                var result = Query.Put("http://iotdata.yhdf.fr/api/web/countdowns/"+toEdit.id,data);
            }
            else if (submit == "delete"){
                var result = Query.Delete("http://iotdata.yhdf.fr/api/web/countdowns/"+id);
            }
            OnGet();
        }
    }
}