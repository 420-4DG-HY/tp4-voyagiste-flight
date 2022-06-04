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

        public FlightBooking Book(Guid FlightId, string codeSeat, Person passenger);
        public BookingConfirmation ConfirmBooking(FlightBooking booking);
        public BookingConfirmation? GetBookingConfirmation(FlightBooking booking);
        public BookingCancellation CancelBooking(FlightBooking booking);
        public BookingCancellation? GetBookingCancellation(FlightBooking booking);
        public void CleanupAvailabilities(Flight flight);
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

        public FlightBooking Book(Guid FlightId, string seatCode, Person passenger)
        {
            Flight? flight = _dal.GetFlight(FlightId);
            //Seat seat = _dal.GetSeat(seatCode);
            if(flight == null)
            {
                string message = "Invalid Flight GUID: " + FlightId;
                _logger.LogError(message);
                throw new Exception(message);
            }
            if(seat == null)
            {
                string message = "Invalid Flight GUID: " + FlightId;
                _logger.LogError(message);
                throw new Exception(message);
            }

            //_dal.RemoveFlightAvailability(flight);
            return _dal.Book(flight, seat, passenger);
        }

        public BookingCancellation CancelBooking(FlightBooking booking)
        {
            //_dal.AddFlightAvailability(booking.Flight, booking.BookedWhen);
            CleanupAvailabilities(booking.Flight);

            return _dal.CancelBooking(booking);
        }


        public void CleanupAvailabilities(Flight flight)
        {
            // ici on devrait éventuellement fusionner les disponibilités adjacentes
            // Une forme de défragmentation du calendrier après une annulation...

            //FlightAvailability[]? availabilities = _dal.GetFlightAvailabilities(flight);

            // On identifie les disponibilités adjacentes 
            // On les supprime et crée une nouvelle disponibilité qui les remplace
        }

        #region délégation du DAL
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
        public BookingConfirmation ConfirmBooking(FlightBooking booking)
        {
            return _dal.ConfirmBooking(booking);
        }
        #endregion
    }
}
