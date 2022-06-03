using FlightDTO;

using CommonDataDTO;

namespace FlightDAL
{
    /// <summary>
    /// Singleton pour simuler une base de données contenant les
    /// données de références et les transactions.
    /// </summary>
    internal class FakeData
    {
        private static FakeData? Singleton;

        #region creation des données de références
        // Création des adresses des aéroports
        internal static readonly Address[] addresses =
        {
            new Address(new Guid("567cde74-6b76-4cc2-b10b-f9810978a889"), new Country("United States"), new Region("Georgia"), new City("Atlanta"), new PostalCode("6000 N Terminal Pkwy"), "30320"),
            new Address(new Guid("14d89790-dd0c-4726-a8ce-6498062a86ed"), new Country("United States"), new Region("Texas"), new City("Dallas"), new PostalCode("75261"), "2400 Aviation Dr,"),
            new Address(new Guid("7e67d002-5e1d-448d-8ea0-dece5cd6decf"), new Country("United States"), new Region("Colorado"), new City("Denver"), new PostalCode("80249"), "8500 Peña Blvd"),
            new Address(new Guid("236fbdec-00a6-4f88-bfee-c78d0dc59b5b"), new Country("United States"), new Region("Illinois"), new City("Chicago"), new PostalCode("60666"), "10000 W O’Hare Ave"),
            new Address(new Guid("665b494a-f48c-423a-8cda-aa2eab86c45a"), new Country("United States"), new Region("California"), new City("Los Angeles"), new PostalCode("90045"), "1 World Way"),
            new Address(new Guid("40d173f5-6d75-4821-b432-90d590dfe3b1"), new Country("Canada"), new Region("Quebec"), new City("Montreal"), new PostalCode("H4Y 1H1"), "975 boulevard Roméo-Vachon Nord"),
            new Address(new Guid("9810b2c2-1ad3-434f-9b3d-09d71e27fcd7"), new Country("Canada"), new Region("Quebec"), new City("Quebec City"), new PostalCode("G2G 0J4"), "505 rue Principale"),
            new Address(new Guid("bd0cfd64-5c91-4ecf-b7b0-5d71f4aee990"), new Country("Canada"), new Region("Ontario"), new City("Ottawa"), new PostalCode("K1V 9B4"), "2550-1000 Airport Parkway Private"),
            new Address(new Guid("6dd0cc24-3de9-4c63-bc04-be3d8b581d3a"), new Country("Canada"), new Region("Ontario"), new City("Toronto"), new PostalCode("L5P 1B2"), "6301 Silver Dart Dr, Mississauga"),
            new Address(new Guid("8026e12a-dfe6-42f3-b377-b573bef27726"), new Country("Canada"), new Region("Alberta"), new City("Calgery"), new PostalCode("T2E 6W5"), "2000 Airport Rd"),
            new Address(new Guid("0b4b4ced-c1f9-4182-8b39-20a171ab3101"), new Country("Canada"), new Region("Alberta"), new City("Edmonton"), new PostalCode("T9E 0V3"), "1000 Airport Rd"),
            new Address(new Guid("4c93804a-aee8-44e5-813b-5d13c2641985"), new Country("Canada"), new Region("Manitoba"), new City("Winnipeg"), new PostalCode("R3H 1C2"), "2000 Wellington Ave"),
            new Address(new Guid("d9d0842f-9c50-4ba1-bfc2-98ec5c8f50e1"), new Country("Canada"), new Region("British Columbia"), new City("Vancouver"), new PostalCode("V7B 0A4"), "3211 Grant McConachie Way Richmond")
        };
        
        // Création des aéroports.
        internal static readonly Airport[] airports =
        {
            new Airport("ATL", "Hartsfield-Jackson International Airport", addresses[0]),
            new Airport("DFW", "Dallas/Fort Worth International Airport", addresses[1]),
            new Airport("DEN", "Denver International Airport", addresses[2]),
            new Airport("ORD", "O'Hare International Airport", addresses[3]),
            new Airport("LAX", "Los Angeles International Airport", addresses[4]),
            new Airport("YUL", "Montréal–Trudeau International Airport", addresses[5]),
            new Airport("YQB", "Québec/Jean Lesage International Airport", addresses[6]),
            new Airport("YOW", "Ottawa Macdonald–Cartier International Airport", addresses[7]),
            new Airport("YYZ", "Toronto Pearson International Airport", addresses[8]),
            new Airport("YYC", "Calgary International Airport", addresses[9]),
            new Airport("YEG", "Edmonton International Airport", addresses[10]),
            new Airport("YWG", "Winnipeg International Airport", addresses[11]),
            new Airport("YVR", "Vancouver International Airport", addresses[12]),
        };

        // Création des compagnies aériennes
        internal static readonly AirLine[] airLines =
        {
            new AirLine(new Guid("02142456-4c0e-4cf5-8531-166da499d46d"), "Delta Air Lines"),
            new AirLine(new Guid("5620dede-05f5-43d0-a74b-11764da7c9b0"), "Americain Airlines"),
            new AirLine(new Guid("91891b62-7781-40c5-9e2b-4309e9de4718"), "Southwest"),
            new AirLine(new Guid("6c6c39cd-adaa-44c6-91a6-a2ed1544a75b"), "United"),
            new AirLine(new Guid("b12a5e7e-4b92-4b5c-8927-3fb052516e5d"), "Alaska Airlines"),
            new AirLine(new Guid("b13ed065-9b00-4980-97e6-f76d19821d96"), "JetBlue"),
            new AirLine(new Guid("6b290027-c49e-44de-a485-6336be243776"), "Lufthansa"),
            new AirLine(new Guid("1c446278-d275-4ba3-ba7f-4722590f886e"), "British Airways"),
            new AirLine(new Guid("46c3679c-9e3c-417a-a69e-266b2aeccf70"), "Air Canada"),
            new AirLine(new Guid("d54e88b1-d894-4b66-a9ae-8ac9e213f4a2"), "Virgin America")
        };

        // Création des vols
        internal static readonly Flight[] flights =
        {
            new Flight(new Guid("835c9c07-629b-4f7f-9189-93160f43075a"), airLines[3], "AA8025", airports[1], DateTime.Now, airports[3], DateTime.Now + TimeSpan.FromHours(5)),
            new Flight(new Guid("18fb87a9-8a3f-4077-9373-2af7348c2ced"), airLines[1], "BA9725", airports[3], DateTime.Now + TimeSpan.FromHours(5), airports[3], DateTime.Now + TimeSpan.FromHours(14)),
            new Flight(new Guid("1c6d95a9-7d62-417d-ac23-56c34951b027"), airLines[2], "DA7025", airports[4], DateTime.Now, airports[3], DateTime.Now + TimeSpan.FromHours(6)),
            new Flight(new Guid("b79ed0cc-861c-479e-98e2-aa4eb60ba117"), airLines[4], "AW8025", airports[7], DateTime.Now + TimeSpan.FromHours(2), airports[3], DateTime.Now + TimeSpan.FromHours(8)),
            new Flight(new Guid("99e15c41-42c9-4094-a005-1c2b661c5b74"), airLines[5], "AQ0395", airports[1], DateTime.Now + TimeSpan.FromHours(1), airports[3], DateTime.Now + TimeSpan.FromHours(10)),
            new Flight(new Guid("57b498ce-7362-4300-99c9-405bed2ae392"), airLines[7], "BA8125", airports[3], DateTime.Now, airports[3], DateTime.Now + TimeSpan.FromHours(2))
        };

        #endregion

        #region données dynamiques : Celles vont changer avec les réservations
        internal List<FlightAvailability> flightAvailabilities;
        internal List<FlightBooking> flightBookings;
        internal List<BookingConfirmation> bookingConfirmations;
        internal List<BookingCancellation> bookingCancellations;
        #endregion

        private FakeData()
        {
            flightAvailabilities = new List<FlightAvailability>();
            flightBookings = new List<FlightBooking>();
            bookingConfirmations = new List<BookingConfirmation>();
            bookingCancellations = new List<BookingCancellation>();
        }

        /// <summary>
        /// Création ou utilisation de l'instance du Singleton.
        /// </summary>
        /// <returns></returns>
        internal static FakeData GetInstance()
        {
            if (Singleton == null) Singleton = new FakeData();
            return Singleton;
        }

        // TODO générer des données pour les codes d'aéroports IATA
        // avec https://en.wikipedia.org/wiki/IATA_airport_code

        // TODO Faites des avions simples avec peu de sièges, juste pour tester!
        // TODO Vous devez ajouter quelques compagnies, aéroports et disponibilités 
        // Utilisez des GUID statiques (fake) pour les distinguer
        // https://www.guidgenerator.com/online-guid-generator.aspx

        // TODO Simuler de la disponibilité. Attention, les disponibilités (Availability)
        // ne doivent pas être statiques puisqu'on doit voir 
        // la disponibilité changer après une réservation
    }
}