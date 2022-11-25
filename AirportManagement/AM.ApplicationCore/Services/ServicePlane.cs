using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{//heritage o umba3ed implementation
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        //constructeur obligatoire
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DeletePlane()
        {
            Delete(p => (DateTime.Now - p.ManufactureDate).TotalDays >= 3650); 
        }

        public IEnumerable<Flight> GetFlight(int n)
        {
            return GetMany().OrderByDescending(p => p.PlaneId).Take(n).SelectMany(p=>p.Flights).OrderBy(f=>f.FlightDate);
        }

        public IEnumerable<Passenger> GetPassanger(Plane p)
        {
            //selct many 5Ater bich traja3 des tickets
            return p.Flights.SelectMany(f => f.Tickets).Select(t => t.Passenger);
        }

        public bool IsAvailablePlane(Flight f, int n)
        {
            return f.Plane.Capacity - f.Tickets.Count() >= n;
            
        }


    }
}
