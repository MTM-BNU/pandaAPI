using System;
namespace pandaAPI.Model
{
	public class Delay
	{
        public String airport_iata { get; set; } = "LTN";
		public String? airline_icao { get; set; }
		public String type { get; set; }
		public int delay_average { get; set; }
		public int flight_count { get; set; }
        public int delay_30 { get; set; }
		public int delay_45 { get; set; }
		public int delay_60 { get; set; }
		public int delay_75 { get; set; }
		public int delay_90 { get; set; }

		public Delay(String? airline_icao, String type, int delay_average, int flight_count,
            int delay_30, int delay_45, int delay_60, int delay_75, int delay_90)
		{
			this.airline_icao = airline_icao;
			this.type = type;
			this.delay_average = delay_average;
			this.delay_30 = delay_30;
			this.delay_45 = delay_45;
			this.delay_60 = delay_60;
			this.delay_75 = delay_75;
			this.delay_90 = delay_90;
            this.flight_count = flight_count;
        }

		public static Delay SetDelay(List<Flight> flights)
		{
            int? totalDelay = 0;
            int? averageDelay = 0;
            int delay_30 = 0;
            int delay_45 = 0;
            int delay_60 = 0;
            int delay_75 = 0;
            int delay_90 = 0;

            foreach (var flight in flights)
            {
                totalDelay += flight.delayed;

                if (flight.delayed >= 30 && flight.delayed < 45)
                {
                    delay_30++;
                }
                else if (flight.delayed >= 45 && flight.delayed < 60)
                {
                    delay_45++;
                }
                else if (flight.delayed >= 60 && flight.delayed < 75)
                {
                    delay_60++;
                }
                else if (flight.delayed >= 75 && flight.delayed < 90)
                {
                    delay_75++;
                }
                else if (flight.delayed >= 90)
                {
                    delay_90++;
                }
            }

            int totalFlights = flights.Count;
            averageDelay = totalDelay / totalFlights;

            return new Delay(null, "", (int)averageDelay, totalFlights, delay_30, delay_45, delay_60, delay_75, delay_90);
        }
    }
}

