using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Mur_Vegetal.Pages
{
    public class StaticscreenModel : PageModel
    {
        public class Sensors
        {
            public int idSensor { get; set; }
            public int idSensorType { get; set; }
            public List<string> project { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int sensorDate { get; set; }
            public int lastSampleDate { get; set; }
            public List<object> batteryLevel { get; set; }
            public bool battery { get; set; }
            public int sleepTime { get; set; }
            public List<object> action { get; set; }
            public int version { get; set; }
            public int timeOut { get; set; }
            public bool isWorking { get; set; }
            public string id { get; set; }
        }

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

        public class Medias
        {
            public string name { get; set; }
            public int beginningDate { get; set; }
            public int endingDate { get; set; }
            public string video { get; set; }
            public string image { get; set; }
            public string id { get; set; }
        }

        public class Social
        {
            public string username { get; set; }
            public string pageWidget { get; set; }
            public string widget { get; set; }
            public string id { get; set; }
        }
        public string _ResultViewWall {get; private set;}
        public string _ResultViewNews { get; private set; }
        public string _ResultViewCountdown {get; private set;}
        public string _ResultViewMedias {get; private set;}
        public string _ResultViewSocialnetworks {get; private set;}


        public void OnGet()
        {
            
            //Request Wall
            var requestWall = Query.Get("http://iotdata.yhdf.fr/api/web/sensors");
            if(requestWall == "Error" || String.IsNullOrEmpty(requestWall)){
                _ResultViewWall = "<div class=\"wall-block box\">Error Api</div>";
            }
            else {
                var result = JsonConvert.DeserializeObject<List<Sensors>>(requestWall);
                _ResultViewWall = "";
                foreach(var e in result){
                    if(e.idSensorType==0){
                        _ResultViewWall += "<div class=\"wall-block box\"> <div class=\"info\"> <div class=\"air-icon\"><img src=\"/images/icones/air.png\"/></div> <div class=\"air-text\">Qualité de l'air :  </div> </div> <div class=\"chart air-chart\"> <script>graph.lineChart(\"air-chart\", tab_temp, 1);</script> </div>  </div>";
                    }
                    if(e.idSensorType==1){
                        _ResultViewWall += "<div class=\"wall-block box\"> <div class=\"info\"> <div class=\"temp-icon\"><img src=\"/images/icones/thermo.png\"/></div> <div class=\"temp-text\">Température :  </div> </div> <div class=\"chart temp-chart\">  <script>graph.lineChart(\"temp-chart\", tab_temp, 0);</script>  </div> </div>";
                    }
                    if(e.idSensorType==2){
                        _ResultViewWall += "<div class=\"wall-block box\"> <div class=\"info\"> <div class=\"pression-icon\"><img src=\"/images/icones/pression.png\"/></div> <div class=\"pression-text\">Commande pompe :  </div> </div> <div class=\"chart pression-chart\">  <script>graph.lineChart(\"pression-chart\", tab_temp, 1);</script> </div> </div>";
                    }
                    if(e.idSensorType==3){
                        _ResultViewWall += "<div class=\"wall-block box\"> <div class=\"info\"> <div class=\"hydro-icon\"><img src=\"/images/icones/hydro.png\"/></div> <div class=\"hydro-text\">Humidité :  </div> </div> <div class=\"chart hydro-chart\"> <script>graph.lineChart(\"hydro-chart\", tab_temp, 1);</script> </div> </div>";
                    }
                    if(e.idSensorType==4){
                        _ResultViewWall += "<div class=\"wall-block box\">  <div class=\"info\"> <div class=\"pr-icon\"><img src=\"/images/icones/pression_ruche.png\"/></div> <div class=\"pr-text\">Pression ruche :  </div>  </div> <div class=\"chart pr-chart\">  <script>graph.lineChart(\"pr-chart\", tab_temp, 1);</script> </div> </div> ";
                    }
                    if(e.idSensorType==5){
                        _ResultViewWall += " <div class=\"wall-block box\"> <div class=\"info\"> <div class=\"mouv-icon\"><img src=\"/images/icones/mouvement.png\"/></div>  <div class=\"mouv-text\">Flux entrant/sortant :  </div> </div> <div class=\"chart mouv-chart\"> <script>graph.columnChart(\"mouv-chart\", tab_temp);</script>  </div> </div>";
                    }
                    if(e.idSensorType==6){
                        _ResultViewWall += " <div class=\"wall-block box\"> <div class=\"info\"> <div class=\"tr-icon\"><img src=\"/images/icones/thermo_ruche.png\"/></div> <div class=\"tr-text\">Température ruche :  </div> </div> <div class=\"chart tr-chart\" <script>graph.lineChart(\"tr-chart\", tab_temp, 1);</script>> </div> </div>";
                    }
                }
            }
            
            //Request News
            var requestNews = Query.Get("http://iotdata.yhdf.fr/api/web/events");
            if(requestNews=="Error" || String.IsNullOrEmpty(requestNews)){
                _ResultViewNews = "<div class=\"news-block box\">Error Api</div>";
            }
            else{
                var result = JsonConvert.DeserializeObject<List<News>>(requestNews);
                _ResultViewNews = "";
                var currentTimeStamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                foreach(var e in result){
                    if (e.beginningDate <= currentTimeStamp && e.endingDate >= currentTimeStamp){
                        if(String.IsNullOrEmpty(e.text)){
                            _ResultViewNews += "<div class=\"news-block\"><div class=\"news-image box\"><img src=\"data:image;base64, "+e.eventImage+"\"/></div></div>";
                        }
                        else {
                            _ResultViewNews += "<div class=\"news-block\"><div class=\"news-image box\"><img src=\"data:image;base64, "+e.eventImage+"\"/></div><div class=\"news-text box\">"+e.text+"</div></div>";
                        }
                    }
                    else {
                    }
                }
            }


            //Request Countdown
            var requestCountdown = Query.Get("http://iotdata.yhdf.fr/api/web/countdowns");
            if(requestCountdown=="Error" || String.IsNullOrEmpty(requestCountdown)){
                _ResultViewCountdown = "<div class=\" countdown-block box\">Error Api</div>";
            }
            else {
                var result = JsonConvert.DeserializeObject<List<CountDown>>(requestCountdown);
                _ResultViewCountdown = "";
                var currentTimeStamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                CountDown lastCountdown;
                foreach(var e in result){
                    lastCountdown = e;
                    if(lastCountdown.endingDateEvent > e.endingDateCountdown){
                        lastCountdown = e;
                    }
                    if (lastCountdown.beginningDateEvent <= currentTimeStamp && lastCountdown.endingDateEvent >= currentTimeStamp){
                        _ResultViewCountdown = "<div class=\"countdown-block\"> <div class=\"countdown-image box\"> <img class=\"mur\" src=\"data:image/png;base64, " +lastCountdown.image + "\" alt=" + lastCountdown.name + " >   </div>  <div class=\"countdown-text box\"> " +lastCountdown.text+ "<div id=\"countdown-display\"> </div> <script> countDown(\" " + lastCountdown.endingDateCountdown + "  \",\"countdown-display\"); </script> </div> </div>";
                    }
                    else {
                    }            
                }
            }

            //Request Media
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

            //Request Socialnetworks
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