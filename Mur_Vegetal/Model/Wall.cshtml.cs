using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;	
using System.Linq;

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

        public void OnGet()
        {
            Answer = Query.Get("http://10.34.160.10:4001/api/web/sensors");
            var result = JsonConvert.DeserializeObject<List<Sensors>>(Answer);
            foreach(var elts in result){
                Console.Write("IdSensors : " + elts.idSensor);
                Console.Write("Type : " + elts.idSensorType);
                Console.Write("projet : " + elts.project);
                Console.Write("Name : " + elts.name);
                Console.Write("description : " + elts.description);
                Console.Write("date : " + elts.sensorDate);
                Console.Write("detnier truc : " + elts.lastSampleDate);
                Console.Write("état batterie : " + elts.batteryLevel[0]);
                Console.Write("batterie : " + elts.battery);
                Console.Write("sleepTime : " + elts.sleepTime);
                Console.Write("Action : " + elts.action);
                Console.Write("Version : " + elts.version);
                Console.Write("TimeOUt : " + elts.timeOut);
                Console.Write("Fonctionne : " + elts.isWorking);
                Console.Write("id : " + elts.id);
            }
        }
    }
}
