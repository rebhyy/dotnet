// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore;
using AM.ApplicationCore.Domain;

Console.WriteLine("Hello, World!");

//constructeur par défaut
Plane plane = new Plane();
plane.Capacity = 300;
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Boing;
//Constructeur paramétré
Plane plane2 = new Plane(PlaneType.Boing,new DateTime(2018,2,12),200);

//initialiseur d'objet 
Plane plane3 = new Plane
{
    Capacity = 100,
    ManufactureDate = DateTime.Now,
    PlaneType = PlaneType.Boing,
    PlaneId = 2
};


var flight = new Flight
{
    FlightId = 1,
    FlightDate = new DateTime(2024, 1, 1),
    Plane = plane, // Associate with the first plane
    Passengers = new List<Passenger>
            {
                new Traveller { PassengerName = new FullName { FirstName = "John", LastName = "Doe" }, BirthDate = new DateTime(1950, 1, 1) },
                new Traveller { PassengerName = new FullName { FirstName = "Jane", LastName = "Smith" }, BirthDate = new DateTime(1940, 1, 1) },
                new Traveller { PassengerName = new FullName { FirstName = "Bob", LastName = "Brown" }, BirthDate = new DateTime(1960, 1, 1) },
                new Staff { PassengerName = new FullName { FirstName = "Alice", LastName = "Johnson" }, BirthDate = new DateTime(1930, 1, 1) },
                // Add more Travellers if needed
            }
};

// Testing the SeniorTravellers method
var seniorTravellers = SeniorTravellers(flight);

// Write the results to the console
foreach (var traveller in seniorTravellers)
{
    Console.WriteLine($"{traveller.PassengerName.FirstName} {traveller.PassengerName.LastName}, BirthDate: {traveller.BirthDate.ToShortDateString()}");
}

 static IList<Traveller> SeniorTravellers(Flight flight)
{
    return flight.Passengers
                .OfType<Traveller>()
                .OrderByDescending  (t => t.BirthDate)
                .Take(3)
                .ToList();
}













