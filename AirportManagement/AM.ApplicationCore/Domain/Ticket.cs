using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public double prix { get; set; }
        public String Siege { get; set; }
        public bool VIP { get; set; }
        public string PassportNumber { get; set; }

        //objet de navigation laison bin 1..*
        //        [ForeignKey ("PassengerFK")]   soit totha fou9 el objet ou taatina passangerFk walla t7otha fou9 el PassangerFk ou taatiha el PAssanger

        public virtual Passenger Passenger { get; set; }

      // hathy el methode el 2 ou yelzem el objet de navigation
        [ForeignKey ("Passenger")]
        public string PassangerFK { get; set; }

        public virtual Flight Flight { get; set; }
        [ForeignKey ("Flight")]
        public int FlightFK { get; set; }

    }
}
