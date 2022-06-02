using CommonDataDTO;
using FlightBLL;
using FlightDTO;
using Microsoft.AspNetCore.Mvc;

namespace FlightAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        readonly ILogger<FlightController> _logger;
        readonly IFlightBusinessLogic _bll;

        public FlightController(IFlightBusinessLogic BusinessLogic, ILogger<FlightController> Logger)
        {
            _bll = BusinessLogic;
            _logger = Logger;
        }

        //[HttpPost("Book")]
        //public FlightBooking Book(Flight flight, Person passenger)
        //{
        //    return _bll.Book(flight, passenger);
        //}

        [HttpPost("CancelBooking")]
        public BookingCancellation CancelBooking(FlightBooking booking)
        {
            return _bll.CancelBooking(booking);
        }

        [HttpPost("ConfirmBooking")]
        public BookingConfirmation ConfirmBooking(FlightBooking booking)
        {
            return _bll.ConfirmBooking(booking);
        }

        [HttpGet("GetAirLine/{AireLineId}")]
        public AirLine? GetAirLine(Guid AireLineId)
        {
            return _bll.GetAirLine(AireLineId);
        }

        [HttpGet("GetAirLines")]
        public AirLine[] GetAirLines()
        {
            return _bll.GetAirLines();
        }

        [HttpGet("GetAirport/{IATACode}")]
        public Airport? GetAirport(string IATACode)
        {
            return _bll.GetAirport(IATACode);
        }

        [HttpGet("GetAirports")]
        public Airport[] GetAirports()
        {
            return _bll.GetAirports();
        }

        [HttpGet("GetBookingCancellation")]
        public BookingCancellation? GetBookingCancellation(FlightBooking booking)
        {
            return _bll.GetBookingCancellation(booking);
        }

        [HttpGet("GetBookingConfirmation")]
        public BookingConfirmation? GetBookingConfirmation(FlightBooking booking)
        {
            return _bll.GetBookingConfirmation(booking);
        }

        [HttpGet("GetFlight/{FlightId}")]
        public Flight? GetFlight(Guid FlightId)
        {
            return _bll.GetFlight(FlightId);
        }

        [HttpGet("GetFlightBooking")]
        public FlightBooking[] GetFlightBooking(Person passenger)
        {
            return _bll.GetFlightBooking(passenger);
        }

        //[HttpGet("GetFlightBooking")]
        //public FlightBooking[] GetFlightBooking(Flight flight)
        //{
        //    return _bll.GetFlightBooking(flight);
        //}

        [HttpGet("GetFlights")]
        public Flight[] GetFlights(AirLine airline)
        {
            return _bll.GetFlights(airline);
        }

        //[HttpGet("GetFlights")]
        //public Flight[] GetFlights(Airport airport)
        //{
        //    return _bll.GetFlights(airport);
        //}
    }
}
