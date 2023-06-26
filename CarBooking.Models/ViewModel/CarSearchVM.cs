using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Models.ViewModel
{
    public class CarSearchVM
    {
        public int? Seat { get; set; }
        public string? CarType { get; set; }
        public DateTime? StartDateTime { get; set; } //วันไป
        public DateTime? ReturnDateTime { get; set; } //วันกลับ

        //public IEnumerable<Car>? Cars { get; set; }

        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public string? Distance { get; set; }
        public string? Duration { get; set; }
    }
}
