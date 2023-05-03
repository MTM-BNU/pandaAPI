using System;
namespace pandaAPI.Model
{
	public class FlightInfo
	{
        public string? airline_icao { get; set; }
        public string? flight_icao { get; set; }
        public string? dep_iata { get; set; }
        public string? arr_iata { get; set; }
        public string? dep_time { get; set; }
        public string? arr_time { get; set; }
        public int? delayed { get; set; }

        public FlightInfo(string? airline_icao, string? flight_icao, string? dep_iata,
            string? arr_iata, string? dep_time, string? arr_time, int? delayed)
        {
            this.airline_icao = airline_icao;
            this.flight_icao = flight_icao;
            this.dep_iata = dep_iata;
            this.arr_iata = arr_iata;
            this.dep_time = dep_time;
            this.arr_time = arr_time;
            this.delayed = delayed;
        }
    }
}

