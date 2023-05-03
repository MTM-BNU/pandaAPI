using System;
namespace pandaAPI.Model
{
    public class DelayFlight
    {
        public String airport_iata { get; set; } = "LTN";
        public String? airline_icao { get; set; }
        public String type { get; set; }
        public int flight_count { get; set; }
        public List<FlightInfo> flights {get; set;}

        public DelayFlight(List<FlightInfo> flights)
		{
            this.flights = flights;
		}

        public static DelayFlight SetDelay(List<Flight> flights)
        {
            List<FlightInfo> delayed = new List<FlightInfo>();

            foreach (var flight in flights)
            {
                var f = new FlightInfo(flight.airline_icao, flight.flight_icao, flight.dep_iata,
                    flight.arr_iata, flight.dep_time, flight.arr_time, flight.delayed);

                delayed.Add(f);
            }

            DelayFlight delayList = new DelayFlight(delayed);

            delayList.flight_count = flights.Count;

            return delayList;
        }
	}
}

