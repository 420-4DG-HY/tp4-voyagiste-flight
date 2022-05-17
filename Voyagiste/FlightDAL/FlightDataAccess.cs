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
        public Airport? GetAirport(int IATACode);
        public AirLine[] GetAirLines();
        public AirLine? GetAirLine(Guid AireLineId);
        public Flight? GetFlight(Guid FlightId);
        public Flight[] GetFlights(AirLine airline);
        public Flight[] GetFlights(Airport airport);
        public FlightBooking[] GetFlightBooking(Person passenger);
        public FlightBooking[] GetFlightBooking(Flight flight);

        public FlightBooking Book(Flight flight, Person passenger);
        public BookingConfirmation ConfirmBook(FlightBooking booking);
        public BookingConfirmation? GetBookingConfirmation(FlightBooking booking);
        public BookingCancellation CancelBooking(FlightBooking booking);
        public BookingCancellation? GetBookingCancellation(FlightBooking booking);
    }

    //public class FlightDataAccess : IFlightDataAccess
    //{
    //
    //}
}
