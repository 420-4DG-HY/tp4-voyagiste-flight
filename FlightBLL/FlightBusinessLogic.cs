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
        public Flight[] GetFlightsAirline(Guid AirlineId);
        public Flight[] GetFlightsAirport(Guid AirportId);
        public FlightBooking[] GetFlightBookingPassenger(Guid PassengerId);
        public FlightBooking[] GetFlightBookingFlight(Guid FlightId);
        public FlightBooking Book(Guid FlightId, string codeSeat, Person passenger);
        public BookingConfirmation ConfirmBooking(FlightBooking booking);
        public BookingConfirmation? GetBookingConfirmation(Guid BookingId);
        public BookingCancellation CancelBooking(FlightBooking booking);
        public BookingCancellation? GetBookingCancellation(Guid BookingId);
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
            Seat? seat = _dal.GetSeat(seatCode);
            if(flight == null)
            {
                string message = "Invalid Flight GUID: " + FlightId;
                _logger.LogError(message);
                throw new Exception(message);
            }
            //S'assurer d'avoir un siège dans un avion et dans le bon avion
            if(seat == null || seat.Flight.FlightId != flight.FlightId)
            {
                string message = "Invalid Seat Code: " + seatCode;
                _logger.LogError(message);
                throw new Exception(message);
            }

            //_dal.RemoveFlightAvailability(flight);
            return _dal.Book(flight, seat, passenger);
        }

        public BookingCancellation CancelBooking(FlightBooking booking)
        {
            // Rendre le booking available
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
        
        public BookingCancellation? GetBookingCancellation(Guid BookingId)
        {
            return _dal.GetBookingCancellation(BookingId);
        }
        
        public BookingConfirmation? GetBookingConfirmation(Guid BookingId)
        {
            return _dal.GetBookingConfirmation(BookingId);
        }

        public Flight? GetFlight(Guid FlightId)
        {
            return _dal.GetFlight(FlightId);
        }
        
        public FlightBooking[] GetFlightBookingPassenger(Guid PassengerId)
        {
            return _dal.GetFlightBookingPassenger(PassengerId);
        }

        public FlightBooking[] GetFlightBookingFlight(Guid FlightId)
        {
            return _dal.GetFlightBookingFlight(FlightId);
        }

        public Flight[] GetFlightsAirline(Guid AirlineId)
        {
            return _dal.GetFlightsAirline(AirlineId);
        }

        public Flight[] GetFlightsAirport(Guid AirportId)
        {
            return _dal.GetFlightsAirport(AirportId);
        }
        public BookingConfirmation ConfirmBooking(FlightBooking booking)
        {
            return _dal.ConfirmBooking(booking);
        }
        #endregion
    }
}
