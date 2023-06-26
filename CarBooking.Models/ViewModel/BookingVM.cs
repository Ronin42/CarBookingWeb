using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.Models.ViewModel
{
	public class BookingVM
	{
		public Car Car { get; set; }

		public Seat Seat { get; set; }
		public IEnumerable<BookingOrder> BookingOrder { get;set; }

		
    }
}
