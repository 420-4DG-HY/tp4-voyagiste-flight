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
        public Flight[] GetFlights(AirLine airline);
        public Flight[] GetFlights(Airport airport);
        public FlightBooking[] GetFlightBooking(Person passenger);
        public FlightBooking[] GetFlightBooking(Flight flight);

        public FlightBooking Book(Flight flight, Seat seat, Person passenger);
        public BookingConfirmation ConfirmBooking(FlightBooking booking);
        public BookingConfirmation? GetBookingConfirmation(FlightBooking booking);
        public BookingCancellation CancelBooking(FlightBooking booking);
        public BookingCancellation? GetBookingCancellation(FlightBooking booking);
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
            return FakeData.airLines.Where(c => c.AireLineId == AireLineId).SingleOrDefault();
        }

        public Flight? GetFlight(Guid FlightId)
        {
            return FakeData.flights.Where(c => c.FlightId == FlightId).Single();
        }
        public Flight[] GetFlights(AirLine airline)
        {
            return FakeData.flights.Where(c => c.AirLine == airline).ToArray();
        }
        public Flight[] GetFlights(Airport airport)
        {
            return FakeData.flights.Where(c => c.ArrivalAiport == airport).ToArray();
        }
        public FlightBooking[] GetFlightBooking(Person passenger)
        {
            return FakeData.GetInstance().flightBookings.Where(cb => cb.Passenger == passenger).ToArray();
        }
        public FlightBooking[] GetFlightBooking(Flight flight)
        {
            return FakeData.GetInstance().flightBookings.Where(cb => cb.Flight == flight).ToArray();
        }

        public FlightBooking Book(Flight flight, Seat seat, Person passenger)
        {
            return new FlightBooking(new Guid(), flight, seat, passenger, new DateTime());
        }
        public BookingConfirmation ConfirmBooking(FlightBooking booking)
        {
            BookingCancellation? bBancel = GetBookingCancellation(booking);
            if (bBancel != null)
            {
                string message = "Cannot confirm booking : \n" + booking + " \nBecause it has been cancelled by : \n" + bBancel;
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
        public BookingConfirmation? GetBookingConfirmation(FlightBooking booking)
        {
            return FakeData.GetInstance().bookingConfirmations.Where(bc => bc.Booking == booking).FirstOrDefault();
        }
        public BookingCancellation CancelBooking(FlightBooking booking)
        {
            BookingCancellation bc = new BookingCancellation(new Guid(), booking, new DateTime());
            FakeData.GetInstance().bookingCancellations.Add(bc);
            return bc;
        }
        public BookingCancellation? GetBookingCancellation(FlightBooking booking)
        {
            return FakeData.GetInstance().bookingCancellations.Where(bc => bc.Booking == booking).FirstOrDefault();
        }
    }
}
