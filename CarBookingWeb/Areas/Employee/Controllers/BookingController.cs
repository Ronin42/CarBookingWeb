using Bulky.DataAccess.Repository;
using CarBooking.DataAccess.data;
using CarBooking.DataAccess.Repository;
using CarBooking.DataAccess.Repository.IRepository;
using CarBooking.Models;
using CarBooking.Models.ViewModel;
using CarBooking.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System;
using System.Data;
using System.Runtime.ConstrainedExecution;
using System.Xml.XPath;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis;

namespace CarBookingWeb.Areas.Employee.Controllers
{
    [Area("Employee")]
    //[Authorize(Roles = SD.Role_Employee)]

    public class BookingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public CarSearchVM CarSearchVM { get; set; }

        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


        }

        public IActionResult Index() //ตาราง มีปุ่มเพิ่มรายการจอง
        {
            return View();
        }


        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(Car CarObj)
        {

            var cars = _unitOfWork.CarRepo.GetMatchingCars(CarObj);
            var displayseat = _unitOfWork.SeatRepo.GetSeatToDisplay(cars);

            ViewData["Cars"] = cars;
            ViewData["Seat"] = displayseat;

            return View();
        }


        #region API CALLS

        [HttpPatch]
        public IActionResult seatbooking(int seatId) 
        {
            //เข้าถึง seat ตาม id
            var seat = _unitOfWork.SeatRepo.Get(u => u.Id == seatId);
            var car = _unitOfWork.CarRepo.Get(c => c.Id == seat.CarId);

            BookingOrder order = new()
            {
                Seat = seat,
                SeatId = seatId
            };

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userid = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            order.ApplicationUserId = userid;

            BookingOrder orderFromDb = _unitOfWork.BookingRepo.Get(u => u.ApplicationUserId == userid && u.SeatId == order.SeatId);

            if (orderFromDb != null)
            {
                _unitOfWork.BookingRepo.Remove(orderFromDb);
               
            }
            else
            {
                _unitOfWork.BookingRepo.Add(order);
            }

            if (seat == null)
            {
                return Json(new { success = false, message = "ไม่พบที่นั่งที่ระบุ" });
            }

            seat.IsAvailable = !seat.IsAvailable;
            if(seat.IsAvailable == true)
            {
                
                car.BookedSeats -= 1;
            }
            else if(seat.IsAvailable == false)
            {
                car.BookedSeats += 1;
                
            }

            
            //ทุกครั้งที่เพิ่มการจอง จะเช็คว่าที่นั่งเต็มรึยัง ถ้าเต็มแล้ว ตั้งสถานะ statusseatfully ถ้ายังไม่เต็ม SeatsRemain ถ้าก่อนจองสถานะเป็น available ให้เพิ่มเวลาไปกลับไปที่รถ
            if (car.BookedSeats == 0)
            {
                // ถ้ายังไม่มีการจองที่นั่ง
                car.status = SD.StatusAvailable;
            }
            else if (car.BookedSeats == car.TotalSeats)
            {
                // ถ้าที่นั่งเต็มแล้ว
                car.status = SD.StatusSeatsFully;

            }
            else
            {
                // ถ้าที่นั่งยังไม่เต็ม
                car.status = SD.StatusSeatsRemain;
            }


            //ทุกครั้งที่ยกเลิกการจอง จะเช็คว่าจำนวนที่จอง เท่ากับ 0 มั้ย ถ้าใช่ตั้งสถานะ available ถ้าจำนวนที่จองมากกว่า 0 แต่ไม่เท่าจำนวนสูงสุด ตั้งสถานะ SeatsRemain
            //ยกเลิกการจองทำได้โดยคนที่กดจอง โดยยกเลิกในหน้ารายการจอง(Index) 
            //ข้อมูลการจองมีวันไป-กลับ ระยะทาง ค่าใช้จ่ายต่อระยะทาง

            _unitOfWork.CarRepo.update(car);
            _unitOfWork.SeatRepo.update(seat);
            _unitOfWork.Save();

            return Json(new { success = true, message = "อัปเดตสถานะเรียบร้อยแล้ว" });
            
            
            //สิ่งที่จะเกิดหลังจบ function นี้ 1.สร้าง order ใหม่

            }

        #endregion

    }
}
