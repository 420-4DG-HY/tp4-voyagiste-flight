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

        [HttpPost("Book")]
        public FlightBooking Book(Guid flightId, string seatCode, Person passenger)
        {
            return _bll.Book(flightId, seatCode, passenger);
        }

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

        // Tested, working
        [HttpGet("GetAirLine/{AireLineId}")]
        public AirLine? GetAirLine(Guid AireLineId)
        {
            return _bll.GetAirLine(AireLineId);
        }

        // Tested, working
        [HttpGet("GetAirLines")]
        public AirLine[] GetAirLines()
        {
            return _bll.GetAirLines();
        }

        // Tested, working
        [HttpGet("GetAirport/{IATACode}")]
        public Airport? GetAirport(string IATACode)
        {
            return _bll.GetAirport(IATACode);
        }

        // Tested, working
        [HttpGet("GetAirports")]
        public Airport[] GetAirports()
        {
            return _bll.GetAirports();
        }

        [HttpGet("GetBookingCancellation/{BookingId}")]
        public BookingCancellation? GetBookingCancellation(Guid BookingId)
        {
            return _bll.GetBookingCancellation(BookingId);
        }

        [HttpGet("GetBookingConfirmation/{BookingId}")]
        public BookingConfirmation? GetBookingConfirmation(Guid BookingId)
        {
            return _bll.GetBookingConfirmation(BookingId);
        }

        // Tested, working
        [HttpGet("GetFlight/{FlightId}")]
        public Flight? GetFlight(Guid FlightId)
        {
            return _bll.GetFlight(FlightId);
        }

        // Tested, working
        [HttpGet("GetFlightBookingPassenger/{PassengerId}")]
        public FlightBooking[] GetFlightBookingPassenger(Guid PassengerId)
        {
            return _bll.GetFlightBookingPassenger(PassengerId);
        }

        // Tested, working
        [HttpGet("GetFlightBookingFlight/{FlightId}")]
        public FlightBooking[] GetFlightBookingFlight(Guid FlightId)
        {
            return _bll.GetFlightBookingFlight(FlightId);
        }

        // Tested, working
        [HttpGet("GetFlightsAirline/{AirlineId}")]
        public Flight[] GetFlightsAirline(Guid AirlineId)
        {
            return _bll.GetFlightsAirline(AirlineId);
        }

        // Tested, working
        [HttpGet("GetFlightsAirport/{AirportId}")]
        public Flight[] GetFlightsAirport(Guid AirportId)
        {
            var flight = _bll.GetFlightsAirport(AirportId);
            return flight;
        }
    }
}
