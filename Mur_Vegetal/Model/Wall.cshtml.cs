using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Mur_Vegetal.Pages
{
    public class WallModel : PageModel
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
        
        public string Answer { get; private set; }
        public string _ResultViewWall {get; private set;}

        public void OnGet()
        {
         
            var result = JsonConvert.DeserializeObject<List<Sensors>>(Query.Get("http://iotdata.yhdf.fr/api/web/sensors"));
            _ResultViewWall = "";
            foreach(var e in result){
                if(e.idSensorType==0){
                    _ResultViewWall += "<div class=\"wall-block box\"> <div class=\"info\"> <div class=\"air-icon\"><img class=\"i1\" src=\"/images/icones/air.png\"/></div> <div class=\"air-text\">Qualité de l'air :  </div> </div> <div class=\"chart air-chart\"> <script>graph.lineChart(\"air-chart\", tab_temp, 1);</script> </div>  </div>";
                }
                if(e.idSensorType==1){
                    _ResultViewWall += "<div class=\"wall-block box\"> <div class=\"info\"> <div class=\"temp-icon\"><img class=\"i1\" src=\"/images/icones/thermo.png\"/></div> <div class=\"temp-text\">Température :  </div> </div> <div class=\"chart temp-chart\">  <script>graph.lineChart(\"temp-chart\", tab_temp, 0);</script>  </div> </div>";
                }
                if(e.idSensorType==2){
                    _ResultViewWall += "<div class=\"wall-block box\"> <div class=\"info\"> <div class=\"pression-icon\"><img class=\"i1\" src=\"/images/icones/pression.png\"/></div> <div class=\"pression-text\">Commande pompe :  </div> </div> <div class=\"chart pression-chart\">  <script>graph.lineChart(\"pression-chart\", tab_temp, 1);</script> </div> </div>";
                }
                if(e.idSensorType==3){
                    _ResultViewWall += "<div class=\"wall-block box\"> <div class=\"info\"> <div class=\"hydro-icon\"><img class=\"i1\" src=\"/images/icones/hydro.png\"/></div> <div class=\"hydro-text\">Humidité :  </div> </div> <div class=\"chart hydro-chart\"> <script>graph.lineChart(\"hydro-chart\", tab_temp, 1);</script> </div> </div>";
                }
                if(e.idSensorType==4){
                    _ResultViewWall += "<div class=\"wall-block box\">  <div class=\"info\"> <div class=\"pr-icon\"><img class=\"i1\" src=\"/images/icones/pression_ruche.png\"/></div> <div class=\"pr-text\">Pression ruche :  </div>  </div> <div class=\"chart pr-chart\">  <script>graph.lineChart(\"pr-chart\", tab_temp, 1);</script> </div> </div> ";
                }
                if(e.idSensorType==5){
                    _ResultViewWall += " <div class=\"wall-block box\"> <div class=\"info\"> <div class=\"mouv-icon\"><img class=\"i1\" src=\"/images/icones/mouvement.png\"/></div>  <div class=\"mouv-text\">Flux entrant/sortant :  </div> </div> <div class=\"chart mouv-chart\"> <script>graph.columnChart(\"mouv-chart\", tab_temp);</script>  </div> </div>";
                }
                if(e.idSensorType==6){
                    _ResultViewWall += " <div class=\"wall-block box\"> <div class=\"info\"> <div class=\"tr-icon\"><img class=\"i1\" src=\"/images/icones/thermo_ruche.png\"/></div> <div class=\"tr-text\">Température ruche :  </div> </div> <div class=\"chart tr-chart\" <script>graph.lineChart(\"tr-chart\", tab_temp, 1);</script>> </div> </div>";
                }
            }
        }
    }
}
