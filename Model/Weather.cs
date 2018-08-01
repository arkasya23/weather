using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WpfApp2.Model
{
    public class Weather
    {
        public  string city;
        public  string country;
        public static string APIKEY { get; private set; }
        public string clouds;
        public string description;
        public double mainTemp;
        public double mainPressure;
        public double mainHumidity;
        public double minTemp;
        public double maxTemp;
        public Weather()
        {
            city = "";
            country = "";
            clouds = "";
            description = "";
            mainHumidity = 0;
            mainTemp = 0;
            minTemp = 0;
            maxTemp = 0;
            mainPressure = 0;

        }
        public void CalculateFields()
        {
            APIKEY = "8ca63c98ee859769cf5318d36ff6574e";
            string result;
            JObject jsonResult;
            String st = $"http://api.openweathermap.org/data/2.5/forecast?id=524901&APPID={APIKEY}";
            String st3 = $"http://api.openweathermap.org/data/2.5/weather?q=Bucharest,ro&APPID={APIKEY}";
            String st2 = $"http://api.openweathermap.org/data/2.5/weather?q={this.city},{this.country}&APPID={APIKEY}";
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(st2);
                result = json.ToString();
                jsonResult = JObject.Parse(json);

            }

            JArray mainWeather = (JArray)jsonResult["weather"];
            clouds = mainWeather[0]["main"].ToString();
            description = mainWeather[0]["description"].ToString();


            mainTemp = jsonResult["main"]["temp"].Value<double>();
            mainPressure = jsonResult["main"]["pressure"].Value<double>();
            mainHumidity = jsonResult["main"]["humidity"].Value<double>();
            minTemp = jsonResult["main"]["temp_min"].Value<double>();
            maxTemp = jsonResult["main"]["temp_max"].Value<double>();

            mainTemp -= 273.0;
            minTemp -= 273.0;
            maxTemp -= 273.0;
        }
    }
}