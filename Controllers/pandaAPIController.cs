using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using pandaAPI.Model;

namespace pandaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class pandaAPIController : ControllerBase
{
    private readonly ILogger<pandaAPIController> _logger;

    public pandaAPIController(ILogger<pandaAPIController> logger)
    {
        _logger = logger;
    }

    [HttpGet("delays/arrivals")]
    public async Task<Delay> GetArrivalsAsync(String? airline_icao)
    {
        List<Flight>? flightInfo;
        FlightService flightService = new FlightService();
        string type = "arr";

        flightInfo = await flightService.GetDelaysAsync(type, airline_icao);
        Delay delay = Delay.SetDelay(flightInfo);
        delay.type = type;
        delay.airline_icao = airline_icao;

        return delay;
    }

    [HttpGet("delays/departures")]
    public async Task<Delay> GetDeparturesAsync(String? airline_icao)
    {
        List<Flight>? flightInfo;
        FlightService flightService = new FlightService();
        string type = "dep";

        flightInfo = await flightService.GetDelaysAsync(type, airline_icao);
        Delay delay = Delay.SetDelay(flightInfo);
        delay.type = type;
        delay.airline_icao = airline_icao;

        return delay;
    }

    [HttpGet("delays")]
    public async Task<DelayFlight> GetDelaysAsync(String? type, String? airline_icao)
    {
        List<Flight>? flightInfo;
        FlightService flightService = new FlightService();

        flightInfo = await flightService.GetFlightsAsync(type, airline_icao);

        DelayFlight delay = DelayFlight.SetDelay(flightInfo);

        delay.type = type;
        delay.airline_icao = airline_icao;

        return delay;
    }

}

