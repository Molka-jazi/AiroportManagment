using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public  class Flight
    {
       // public string Airline { get; set; }
        public int FlightId { get; set; }
        public DateTime FlightDate { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime EffectiveArrival { get; set; }
        //definition d'un champs optionelle with ?
        public string? Departure { get; set; }
        public string Destination { get; set; }
        //prop de navigation
     //   public  ICollection<Passenger> Passengers { get; set; } // lazy loading maaha virtual aala les objet de navigation
     public virtual ICollection<Ticket> Tickets { get; set; }
        //M2 soit hathy bich n9oul elli heya foreign key
       public virtual Plane Plane { get; set; }
        [ForeignKey("Plane")]

        //hathy el M2 bich n9oulou elli heya foregin key
        public int PlaneId { get; set; }
        //M3: na3melha fel classe configuration bel has key
        //TP1-Q6: Réimplémenter la méthode ToString()
        public override string ToString()
        {
            return "FlightId: " + FlightId + " FlightDate: " + FlightDate + " Destination: " + Destination;
        }
    }
}
