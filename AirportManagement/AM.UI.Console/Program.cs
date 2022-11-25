// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;

//Plane plane = new Plane();
//plane.PlaneType = PlaneType.Airbus;
//plane.Capacity = 200;
//plane.ManufactureDate = new DateTime(2018, 11, 10);

//Plane plane2 = new Plane(PlaneType.Boing, 300, DateTime.Now);
Plane plane3 = new Plane { PlaneType = PlaneType.Airbus, Capacity = 150, ManufactureDate = new DateTime(2015, 02, 03) };

Console.WriteLine("************************************ Testing Signature Polymorphisme ****************************** ");
Passenger p1 = new Passenger { FullName = new FullName { FirstName = "steave", LastName = "jobs" }, EmailAddress = "steeve.jobs@gmail.com", BirthDate = new DateTime(1955, 01, 01) };
Console.WriteLine("la méthode Checkpassenger");
Console.WriteLine(p1.CheckProfile("Steave", "Jobs"));
Console.WriteLine(p1.CheckProfile("steave", "jobs", "steeve.jobs@gmail"));

Console.WriteLine("************************************ Testing Inheritance Polymorphisme ****************************** ");
Staff s1 = new Staff {  FullName = new FullName { FirstName = "Bill", LastName = "Gates" }, EmailAddress = "Bill.gates@gmail.com", BirthDate = new DateTime(1945, 01, 01), EmployementDate = new DateTime(1990, 01, 01), Salary = 99999 };
Traveller t1 = new Traveller { FullName = new FullName { FirstName = "Mark", LastName = "Zuckerburg" }, EmailAddress = "Mark.Zuckerburg@gmail.com", BirthDate = new DateTime(1980, 01, 01), HealthInformation = "Some troubles", Nationality = "American" };
p1.PassengerType();
s1.PassengerType();
t1.PassengerType();

Console.WriteLine("************************************ Testing Services  ****************************** ");
ServiceFlightFirst sf = new ServiceFlightFirst();

sf.Flights = TestData.listFlights;

Console.WriteLine("************************************ GetFlightDates (string destination)  ****************************** ");
Console.WriteLine("Flight dates to Madrid");
foreach (var item in sf.GetFlightDates("Madrid"))
    Console.WriteLine(item);
Console.WriteLine("************************************ GetFlights(string filterType, string filterValue)  ****************************** ");
sf.GetFlights("Destination", "Paris");
Console.WriteLine("************************************ ShowFlightDetails(Plane plane)  ****************************** ");
sf.ShowFlightDetails(TestData.Airbusplane);
Console.WriteLine("************************************ ProgrammedFlightNumber(DateTime startDate)  ****************************** ");
Console.WriteLine("Number of programmed flights in 01/01/2022 week: ");
sf.ProgrammedFlightNumber(new DateTime(2022, 01, 01));
Console.WriteLine("************************************ DurationAverage(string destination) ****************************** ");
Console.WriteLine("Duration average of flights to Madrid: " + sf.DurationAverage("Madrid"));
Console.WriteLine("************************************ OrderedDurationFlights()  ****************************** ");
foreach (var item in sf.OrderedDurationFlights())
    Console.WriteLine(item);
Console.WriteLine("************************************ SeniorTravellers(Flight flight) ****************************** ");
/*foreach (var item in sf.SeniorTravellers(TestData.flight1))
    Console.WriteLine(item);
Console.WriteLine("************************************ DestinationGroupedFlights()  ****************************** ");
sf.DestinationGroupedFlights();*/

Console.WriteLine("************************************ Testing Delegates  ****************************** ");

sf.FlightDetailsDel(TestData.BoingPlane);
Console.WriteLine("Average duration of flight To Paris; " + sf.DurationAverageDel("Paris"));

Console.WriteLine("************************************ Testing Extension methods  ****************************** ");
p1.UpperFullName();
Console.WriteLine("First Name: " + p1.FullName.FirstName + " Last Name: " + p1.FullName.LastName);

Console.WriteLine("************************************ Chargement des données fill database  ****************************** ");
AMContext ctx=new AMContext();
//ctx.Planes.Add(TestData.Airbusplane);
//ctx.Planes.Add(TestData.BoingPlane);
IUnitOfWork uow = new UnitOfWork(ctx);
ServicePlane sp = new ServicePlane(uow);
sp.Add(TestData.Airbusplane);
sp.Add(TestData.BoingPlane);

//ctx.Flights.Add(TestData.flight1);
//ctx.Flights.Add(TestData.flight2);
//ctx.Flights.Add(TestData.flight3);
//to save in the base de donnée
//ctx.SaveChanges();

foreach(Flight f in ctx.Flights)
    Console.WriteLine("date du vole "+f.FlightDate+"plane capacity"+f.Plane.Capacity);


Console.WriteLine("************************************Insertion de 2 avion unit of work****************************** ");
//instancier le service
AMContext ctx1 = new AMContext();
IUnitOfWork uow1 = new UnitOfWork(ctx1);
IServicePlane sp1 = new ServicePlane(uow1); //c'est faux !!!  couplage fort 

//Insertion de 2 avion
sp1.Add(TestData.Airbusplane);
sp1.Add(TestData.BoingPlane);
sp1.Commit(); //men service
Console.WriteLine("************************************affichage***************************** ");

//Afficher tous les avions
foreach (Plane p in sp1.GetMany())
    Console.WriteLine(p);
Console.WriteLine("************************************affichage where clause***************************** ");

//afficher les avions avec des id superieur a 2
foreach (Plane p in sp1.GetMany(p=> p.PlaneId>2))
    Console.WriteLine(p);

