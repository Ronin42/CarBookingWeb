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
        public IEnumerable<Seat> GetSeatToDisplay(IEnumerable<Car> cars)
        {
            List<Seat> seats = new List<Seat>();

            foreach (var car in cars)
            {
                var matchingSeats = _db.Seats.Where(s => s.CarName.ToLower().Contains(car.CarName.ToLower()));
                seats.AddRange(matchingSeats);
            }

            return seats;
        }

        //public IEnumerable<Seat> GetSeatToDisplay(List<Car> carObj)
        //{
        //    List<Seat> seatsToDisplay = new List<Seat>();

        //    foreach (var car in carObj)
        //    {
        //        IQueryable<Seat> query = _db.Seats;

        //        query = query.Where(s => s.CarName.ToLower().Contains(car.CarName.ToLower()));

        //        seatsToDisplay.AddRange(query.ToList());
        //    }

        //    return seatsToDisplay;
        //}

        //public IEnumerable<Seat> GetSeatToDisplay(Car CarObj)
        //{

        //    IQueryable<Seat> query = _db.Seats;


        //    query = query.Where(c => c.CarName.ToLower().Contains(CarObj.CarName.ToLower()));

        //    return query.ToList();
        //}

        public void update(Seat obj)
        {
            _db.Seats.Update(obj);
        }
    }
}
