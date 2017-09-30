using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Reservation
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public DateTime CreateTime;

        public Guid rowGuid;
    }
}
