using System;
namespace pandaAPI.Model
{
	public class Flight
	{
		//
        public string? airline_iata {get; set;}
        public string? airline_icao {get; set;}
        public string? flight_iata {get; set;}
        public string? flight_icao {get; set;}
        //
        public string? flight_number {get; set;}
        public string? dep_iata {get; set;}
        public string? dep_icao {get; set;}
        public string? dep_terminal {get; set;}
        public string? dep_gate {get; set;}
        public string? dep_time {get; set;}
        //
        public string? dep_time_utc {get; set;}
        public string? dep_estimated {get; set;}
        //
        public string? dep_estimated_utc {get; set;}
        public string? dep_actual {get; set;}
        //
        public string? dep_actual_utc {get; set;}
        public string? arr_iata {get; set;}
        public string? arr_icao {get; set;}
        public string? arr_terminal {get; set;}
        public string? arr_gate {get; set;}
        //
        public string? arr_baggage {get; set;}
        public string? arr_time {get; set;}
        //
        public string? arr_time_utc {get; set;}
        public string? arr_estimated {get; set;}
        //
        public string? arr_estimated_utc {get; set;}
        //
        public string? cs_airline_iata {get; set;}
        //
        public string? cs_flight_number {get; set;}
        //
        public string? cs_flight_iata {get; set;}
        public string? status {get; set;}
        public int? duration {get; set;}
        public int? delayed {get; set;}
        public int? dep_delayed {get; set;}
        public int? arr_delayed {get; set;}
        public string? aircraft_icao {get; set;}
        //
        public string? arr_time_ts {get; set;}
        //
        public string? dep_time_ts {get; set;}
        //
        public string? arr_estimated_ts {get; set;}
        //
        public string? dep_estimated_ts {get; set;}
        //
        public string? dep_actual_ts {get; set;}
	}
}

