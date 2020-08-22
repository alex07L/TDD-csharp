using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorMedia
{
    class Streamer
    {
        private HttpClient request;
        private String zipcode;

        public Streamer(HttpMessageHandler handle, String zipcode) {
            this.request = new HttpClient(handle);
            this.zipcode = zipcode;
        }
        public String getContent()
        {
            dynamic dyna = getCall();
            //return html content
            return "<div>"+ dyna["current"]["temp_c"]+"</div>";
        }

        public object getCall()
        {
            var response = request.GetAsync("http://api.weatherapi.com/v1/forecast.json?key=2b23e7071c304d53b82160733203007&q="+zipcode+"&day=1").Result;
            //get body response
            var json = response.Content.ReadAsStringAsync();
            //convert to a json object 
            return JsonConvert.DeserializeObject(json.Result);
        }
    }
}
