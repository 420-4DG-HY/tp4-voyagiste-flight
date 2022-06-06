using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using FlightDTO;

using CommonDataDTO;

namespace FlightDAL
{
    public interface IFlightDataAccess
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

        public FlightBooking Book(Flight flight, Seat seat, Person passenger);
        public BookingConfirmation ConfirmBooking(FlightBooking booking);
        public BookingConfirmation? GetBookingConfirmation(Guid BookingId);
        public BookingCancellation CancelBooking(FlightBooking booking);
        public BookingCancellation? GetBookingCancellation(Guid BookingId);
        public Seat? GetSeat(string seatCode);
        public Seat[] GetSeats(Flight flight);
    }

    public class FlightDataAccess : IFlightDataAccess
    {
        private IConfiguration _configuration;
        private ILogger _logger;

        public FlightDataAccess(IConfiguration configuration, ILogger<FlightDataAccess> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public Airport[] GetAirports()
        {
            return FakeData.airports.ToArray();
        }
        public Airport? GetAirport(string IATACode)
        {
            return FakeData.airports.Where(c => c.IATACode == IATACode).SingleOrDefault();
        }

        public AirLine[] GetAirLines()
        {
            return FakeData.airLines.ToArray();
        }
        public AirLine? GetAirLine(Guid AireLineId)
        {
            return FakeData.airLines.Where(c => c.AirelineId == AireLineId).SingleOrDefault();
        }

        public Flight? GetFlight(Guid FlightId)
        {
            return FakeData.flights.Where(c => c.FlightId == FlightId).Single();
        }
        public Flight[] GetFlightsAirline(Guid AirlineId)
        {
            return FakeData.flights.Where(c => c.AirLine.AirelineId == AirlineId).ToArray();
        }
        public Flight[] GetFlightsAirport(Guid AirportId)
        {
            return FakeData.flights.Where(c => c.ArrivalAirport.AirportId == AirportId).ToArray();
        }
        public FlightBooking[] GetFlightBookingPassenger(Guid PassengerId)
        {
            return FakeData.GetInstance().flightBookings.Where(cb => cb.Passenger.PersonId == PassengerId).ToArray();
        }
        public FlightBooking[] GetFlightBookingFlight(Guid FlightId)
        {
            return FakeData.GetInstance().flightBookings.Where(cb => cb.Flight.FlightId == FlightId).ToArray();
        }

        public FlightBooking Book(Flight flight, Seat seat, Person passenger)
        {
            // Ajouter le booking
            FakeData.GetInstance().flightBookings.Add(new FlightBooking(new Guid(), flight, seat, passenger, new DateTime()));

            // Retourner le booking
            return new FlightBooking(new Guid(), flight, seat, passenger, new DateTime());
        }
        public BookingConfirmation ConfirmBooking(FlightBooking booking)
        {
            BookingCancellation? bBancel = GetBookingCancellation(booking.BookingId);
            if (bBancel != null)
            {
                string message = "Cannot confirm booking : \n" + booking.BookingId + " \nBecause it has been cancelled for : \n" + bBancel.Booking.traveler.firstName + " " + bBancel.Booking.traveler.lastName + "on" + bBancel.CancelledWhen;
                _logger.LogError(message);
                throw new Exception(message);
            }
            else
            {
                BookingConfirmation bc = new BookingConfirmation(new Guid(), booking, new DateTime());
                FakeData.GetInstance().bookingConfirmations.Add(bc);
                return bc;
            }
        }
        public BookingConfirmation? GetBookingConfirmation(Guid BookingId)
        {
            return FakeData.GetInstance().bookingConfirmations.Where(bc => bc.Booking.BookingId == BookingId).FirstOrDefault();
        }
        public BookingCancellation CancelBooking(FlightBooking booking)
        {
            BookingConfirmation? bc = GetBookingConfirmation(booking.BookingId);
            if (bc != null)
            {
                string message = "Cannot cancel booking : \n" + booking.BookingId + " \nBecause it has been confirmed for : \n" + bc.Booking.traveler.firstName + " " + bc.Booking.traveler.lastName + "on " + bc.Booking.BookedWhen;
                _logger.LogError(message);
                throw new Exception(message);
            }
            else
            {
                BookingCancellation bCancel = new BookingCancellation(new Guid(), booking, new DateTime());
                FakeData.GetInstance().bookingCancellations.Add(bCancel);
                return bCancel;
            }
        }
        public BookingCancellation? GetBookingCancellation(Guid BookingId)
        {
            return FakeData.GetInstance().bookingCancellations.Where(bc => bc.Booking.BookingId == BookingId).FirstOrDefault();
        }
        public Seat[] GetSeats(Flight flight)
        {
            return FakeData.seats.Where(c => c.Flight == flight).ToArray();
        }
        public Seat? GetSeat(string seatCode)
        {
            return FakeData.seats.Where(c => c.SeatCode == seatCode).Single();
        }
    }
}
