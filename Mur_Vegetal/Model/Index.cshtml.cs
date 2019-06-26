using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Mur_Vegetal.Pages
{
    public class IndexModel : PageModel
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

        public class Social
        {
            public string username { get; set; }
            public string pageWidget { get; set; }
            public string widget { get; set; }
            public string id { get; set; }
        }
        public void OnGet()
        {
            var result = JsonConvert.DeserializeObject<List<Sensors>>(Query.Get("http://iotdata.yhdf.fr/api/web/sensors"));

        }
    }
}
