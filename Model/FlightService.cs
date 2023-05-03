using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace pandaAPI.Model
{
	public class FlightService
	{
        //Hosted web API REST Service base url
        string Baseurl = "https://airlabs.co/api/v9/";
        string API_KEY = "&api_key=28b1cda9-24ff-4c3d-8f83-2195d132f66e";

        public async Task<List<Flight>> GetDelaysAsync(string? type, string? airline_icao)
        {
            List<Flight> delaysInfo = new List<Flight>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                String url = "delays?delay=30&type=departures";

                if (type == "arr")
                    url += "&arr_iata=LTN&";
                else if (type == "dep")
                    url += "&dep_iata=LTN&";

                if (airline_icao != null)
                    url += ("&airline_icao=" + airline_icao);

                String fullURL = url + API_KEY;

                //Sending request to find web api REST service resource using HttpClient
                HttpResponseMessage Res = await client.GetAsync(fullURL);

                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var FlightResponse = Res.Content.ReadAsStringAsync().Result;
                    // https://stackoverflow.com/questions/69498727/how-to-get-a-specific-field-from-response 
                    FlightResponse = JObject.Parse(FlightResponse)["response"].ToString();
                    //Deserializing the response recieved from web api and storing into the Flights list
                    delaysInfo = JsonConvert.DeserializeObject<List<Flight>>(FlightResponse).ToList();
                }
            }

            return await Task.FromResult(delaysInfo.ToList());
        }

        public async Task<List<Flight>> GetFlightsAsync(string? type, string? airline_icao)
        {
            List<Flight> delaysInfo = new List<Flight>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                String urlArrivals = "delays?delay=30&type=departures&arr_iata=LTN";
                String urlDepartures = "delays?delay=30&type=departures&dep_iata=LTN";
                String fullURL;

                if (airline_icao != null)
                {
                    urlArrivals += ("&airline_icao=" + airline_icao) + API_KEY;
                    urlDepartures += ("&airline_icao=" + airline_icao) + API_KEY;
                }
                else
                {
                    urlArrivals += API_KEY;
                    urlDepartures += API_KEY;
                }


                if (type is null)
                {
                    HttpResponseMessage ResArrivals = await client.GetAsync(urlArrivals);
                    HttpResponseMessage ResDepartures = await client.GetAsync(urlDepartures);

                    //Checking the response is successful or not which is sent using HttpClient
                    if (ResArrivals.IsSuccessStatusCode && ResDepartures.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var ArrivalsResponse = ResArrivals.Content.ReadAsStringAsync().Result;
                        var DeparturesResponse = ResDepartures.Content.ReadAsStringAsync().Result;
                        ArrivalsResponse = JObject.Parse(ArrivalsResponse)["response"].ToString();
                        DeparturesResponse = JObject.Parse(DeparturesResponse)["response"].ToString();
                        //Deserializing the response recieved from web api and storing into the Flights list
                        delaysInfo = JsonConvert.DeserializeObject<List<Flight>>(ArrivalsResponse).ToList();
                        delaysInfo.AddRange(JsonConvert.DeserializeObject<List<Flight>>(DeparturesResponse).ToList());
                    }
                }
                else if (type == "arr")
                {
                    HttpResponseMessage Res = await client.GetAsync(urlArrivals);

                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var FlightResponse = Res.Content.ReadAsStringAsync().Result;
                        // https://stackoverflow.com/questions/69498727/how-to-get-a-specific-field-from-response 
                        FlightResponse = JObject.Parse(FlightResponse)["response"].ToString();
                        //Deserializing the response recieved from web api and storing into the Flights list
                        delaysInfo = JsonConvert.DeserializeObject<List<Flight>>(FlightResponse).ToList();
                    }
                }

                else if (type == "dep")
                {
                    HttpResponseMessage Res = await client.GetAsync(urlDepartures);

                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var FlightResponse = Res.Content.ReadAsStringAsync().Result;
                        // https://stackoverflow.com/questions/69498727/how-to-get-a-specific-field-from-response 
                        FlightResponse = JObject.Parse(FlightResponse)["response"].ToString();
                        //Deserializing the response recieved from web api and storing into the Flights list
                        delaysInfo = JsonConvert.DeserializeObject<List<Flight>>(FlightResponse).ToList();
                    }
                }
            }

            return await Task.FromResult(delaysInfo.ToList());
        }
    }
}

