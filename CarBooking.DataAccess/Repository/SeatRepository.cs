using CarBooking.DataAccess.data;
using CarBooking.DataAccess.Repository;
using CarBooking.DataAccess.Repository.IRepository;
using CarBooking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBooking.DataAccess.Repository
{
    public class SeatRepository : Repository<Seat>, ISeatRepository
    {
        private ApplicationDBcontext _db;
        public SeatRepository(ApplicationDBcontext db): base(db)
        {
            _db = db;
        }

        //public async Task GenerateSeats(Car car)
        //{
        //    // Generate seats for the car
        //    List<Seat> seats = new List<Seat>();

        //    for (int i = 1; i <= car.TotalSeats; i++)
        //    {
        //        Seat seat = new Seat
        //        {
        //            CarId = car.Id,
        //            SeatCode = car.CarName + "_" + i.ToString(),

        //        };

        //        seats.Add(seat);
        //    }

        //    // Save the generated seats to the database
        //    await _db.Seats.AddRangeAsync(seats);
        //    await _db.SaveChangesAsync();
        //}

        public void update(Seat obj)
        {
            _db.Seats.Update(obj);
        }
    }
}
