using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;

namespace ElevatorMedia
{
    [TestClass]
    public class StreamerTest
    {
        [TestMethod]
        public void TestCall()
        {
            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://api.weatherapi.com/v1/forecast.json")
                    .Respond("application/json", "{\"location\":{\"name\":\"Newark\",\"region\":\"New Jersey\",\"country\":\"USA\",\"lat\":40.71,\"lon\":-74.21,\"tz_id\":\"America/New_York\",\"localtime_epoch\":1597880635,\"localtime\":\"2020-08-19 19:43\"},\"current\":{\"last_updated_epoch\":1597879807,\"last_updated\":\"2020-08-19 19:30\",\"temp_c\":22.8,\"temp_f\":73,\"is_day\":1,\"condition\":{\"text\":\"Sunny\",\"icon\":\"//cdn.weatherapi.com/weather/64x64/day/113.png\",\"code\":1000},\"wind_mph\":5.6,\"wind_kph\":9,\"wind_degree\":110,\"wind_dir\":\"ESE\",\"pressure_mb\":1014,\"pressure_in\":30.4,\"precip_mm\":0.3,\"precip_in\":0.01,\"humidity\":100,\"cloud\":0,\"feelslike_c\":24.9,\"feelslike_f\":76.9,\"vis_km\":16,\"vis_miles\":9,\"uv\":5,\"gust_mph\":8.1,\"gust_kph\":13},\"forecast\":{\"forecastday\":[{\"date\":\"2020-08-19\",\"date_epoch\":1597795200,\"day\":{\"maxtemp_c\":24.2,\"maxtemp_f\":75.6,\"mintemp_c\":17,\"mintemp_f\":62.6,\"avgtemp_c\":22.4,\"avgtemp_f\":72.3,\"maxwind_mph\":7.6,\"maxwind_kph\":12.2,\"totalprecip_mm\":3.6,\"totalprecip_in\":0.14,\"avgvis_km\":9.4,\"avgvis_miles\":5,\"avghumidity\":71,\"daily_will_it_rain\":1,\"daily_chance_of_rain\":\"83\",\"daily_will_it_snow\":0,\"daily_chance_of_snow\":\"0\",\"condition\":{\"text\":\"Moderate or heavy rain shower\",\"icon\":\"//cdn.weatherapi.com/weather/64x64/day/356.png\",\"code\":1243},\"uv\":5},\"astro\":{\"sunrise\":\"06:12 AM\",\"sunset\":\"07:48 PM\",\"moonrise\":\"06:30 AM\",\"moonset\":\"08:36 PM\"}}]},\"alert\":{\"headline\":\"Coastal Flood Statement issued August 19 at 4:31AM EDT until August 19 at 10:00PM EDT by NWS\",\"msgtype\":\"Alert\",\"severity\":\"Unknown\",\"urgency\":\"Unknown\",\"areas\":\"Southern Nassau; Southern Queens\",\"category\":\"Met\",\"certainty\":\"Unknown\",\"event\":\"Coastal Flood Statement\",\"note\":\"Alert for Southern Nassau; Southern Queens (New York) Issued by the National Weather Service\",\"effective\":\"2020-08-19T20:00:00-04:00\",\"expires\":\"2020-08-19T22:00:00-04:00\",\"desc\":\"* WHAT...Less than one half foot of inundation above ground level\nexpected in vulnerable areas near the waterfront and shoreline.\n* WHERE...Southern Nassau and Southern Queens Counties.\n* WHEN...This evening.\n* IMPACTS...Brief minor flooding is possible in the most vulnerable\nlocations near the waterfront and shoreline.\",\"instruction\":\"Do not drive through flooded roadways.\"}}"); // Respond with JSON
            //create new object streamer
            Streamer s = new Streamer(mockHttp, "07112");
            Assert.AreNotEqual(s.getCall(), null);
        }

        [TestMethod]
        public void TestContent()
        {
            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();

            mockHttp.When("http://api.weatherapi.com/v1/forecast.json")
                    .Respond("application/json", "{\"location\":{\"name\":\"Newark\",\"region\":\"New Jersey\",\"country\":\"USA\",\"lat\":40.71,\"lon\":-74.21,\"tz_id\":\"America/New_York\",\"localtime_epoch\":1597880635,\"localtime\":\"2020-08-19 19:43\"},\"current\":{\"last_updated_epoch\":1597879807,\"last_updated\":\"2020-08-19 19:30\",\"temp_c\":22.8,\"temp_f\":73,\"is_day\":1,\"condition\":{\"text\":\"Sunny\",\"icon\":\"//cdn.weatherapi.com/weather/64x64/day/113.png\",\"code\":1000},\"wind_mph\":5.6,\"wind_kph\":9,\"wind_degree\":110,\"wind_dir\":\"ESE\",\"pressure_mb\":1014,\"pressure_in\":30.4,\"precip_mm\":0.3,\"precip_in\":0.01,\"humidity\":100,\"cloud\":0,\"feelslike_c\":24.9,\"feelslike_f\":76.9,\"vis_km\":16,\"vis_miles\":9,\"uv\":5,\"gust_mph\":8.1,\"gust_kph\":13},\"forecast\":{\"forecastday\":[{\"date\":\"2020-08-19\",\"date_epoch\":1597795200,\"day\":{\"maxtemp_c\":24.2,\"maxtemp_f\":75.6,\"mintemp_c\":17,\"mintemp_f\":62.6,\"avgtemp_c\":22.4,\"avgtemp_f\":72.3,\"maxwind_mph\":7.6,\"maxwind_kph\":12.2,\"totalprecip_mm\":3.6,\"totalprecip_in\":0.14,\"avgvis_km\":9.4,\"avgvis_miles\":5,\"avghumidity\":71,\"daily_will_it_rain\":1,\"daily_chance_of_rain\":\"83\",\"daily_will_it_snow\":0,\"daily_chance_of_snow\":\"0\",\"condition\":{\"text\":\"Moderate or heavy rain shower\",\"icon\":\"//cdn.weatherapi.com/weather/64x64/day/356.png\",\"code\":1243},\"uv\":5},\"astro\":{\"sunrise\":\"06:12 AM\",\"sunset\":\"07:48 PM\",\"moonrise\":\"06:30 AM\",\"moonset\":\"08:36 PM\"}}]},\"alert\":{\"headline\":\"Coastal Flood Statement issued August 19 at 4:31AM EDT until August 19 at 10:00PM EDT by NWS\",\"msgtype\":\"Alert\",\"severity\":\"Unknown\",\"urgency\":\"Unknown\",\"areas\":\"Southern Nassau; Southern Queens\",\"category\":\"Met\",\"certainty\":\"Unknown\",\"event\":\"Coastal Flood Statement\",\"note\":\"Alert for Southern Nassau; Southern Queens (New York) Issued by the National Weather Service\",\"effective\":\"2020-08-19T20:00:00-04:00\",\"expires\":\"2020-08-19T22:00:00-04:00\",\"desc\":\"* WHAT...Less than one half foot of inundation above ground level\nexpected in vulnerable areas near the waterfront and shoreline.\n* WHERE...Southern Nassau and Southern Queens Counties.\n* WHEN...This evening.\n* IMPACTS...Brief minor flooding is possible in the most vulnerable\nlocations near the waterfront and shoreline.\",\"instruction\":\"Do not drive through flooded roadways.\"}}"); // Respond with JSON
            //create new object streamer
            Streamer s = new Streamer(mockHttp, "07112");
            Assert.IsTrue(s.getContent().Contains("div"));
        }
    }
}
