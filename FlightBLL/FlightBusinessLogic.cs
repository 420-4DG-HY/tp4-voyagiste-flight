using CommonDataDTO;
using FlightDAL;
using FlightDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBLL
{
    public interface IFlightBusinessLogic
    {
        public Airport[] GetAirports();
        public Airport? GetAirport(string IATACode);
        public AirLine[] GetAirLines();
        public AirLine? GetAirLine(Guid AireLineId);
        public Flight? GetFlight(Guid FlightId);
        public Flight[] GetFlights(AirLine airline);
        public Flight[] GetFlights(Airport airport);
        public FlightBooking[] GetFlightBooking(Person passenger);
        public FlightBooking[] GetFlightBooking(Flight flight);

        public FlightBooking Book(Flight flight, Person passenger);
        public BookingConfirmation ConfirmBooking(FlightBooking booking);
        public BookingConfirmation? GetBookingConfirmation(FlightBooking booking);
        public BookingCancellation CancelBooking(FlightBooking booking);
        public BookingCancellation? GetBookingCancellation(FlightBooking booking);
    }
    public class FlightBusinessLogic : IFlightBusinessLogic
    {
        readonly ILogger<FlightBusinessLogic> _logger;
        readonly IFlightDataAccess _dal;

        public FlightBusinessLogic(IFlightDataAccess DataAccess, ILogger<FlightBusinessLogic> Logger)
        {
            _dal = DataAccess;
            _logger = Logger;
        }

        public FlightBooking Book(Flight flight, Person passenger)
        {
            return _dal.Book(flight, passenger);
        }

        public BookingCancellation CancelBooking(FlightBooking booking)
        {
            return _dal.CancelBooking(booking);
        }

        public BookingConfirmation ConfirmBooking(FlightBooking booking)
        {
            return _dal.ConfirmBooking(booking);
        }

        public AirLine? GetAirLine(Guid AireLineId)
        {
            return _dal.GetAirLine(AireLineId);
        }

        public AirLine[] GetAirLines()
        {
            return _dal.GetAirLines();
        }

        public Airport? GetAirport(string IATACode)
        {
            return _dal.GetAirport(IATACode);
        }

        public Airport[] GetAirports()
        {
            return _dal.GetAirports();
        }

        public BookingCancellation? GetBookingCancellation(FlightBooking booking)
        {
            return _dal.GetBookingCancellation(booking);
        }

        public BookingConfirmation? GetBookingConfirmation(FlightBooking booking)
        {
            return _dal.GetBookingConfirmation(booking);
        }

        public Flight? GetFlight(Guid FlightId)
        {
            return _dal.GetFlight(FlightId);
        }

        public FlightBooking[] GetFlightBooking(Person passenger)
        {
            return _dal.GetFlightBooking(passenger);
        }

        public FlightBooking[] GetFlightBooking(Flight flight)
        {
            return _dal.GetFlightBooking(flight);
        }

        public Flight[] GetFlights(AirLine airline)
        {
            return _dal.GetFlights(airline);
        }

        public Flight[] GetFlights(Airport airport)
        {
            return _dal.GetFlights(airport);
        }
    }
}
