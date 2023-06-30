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



        public IActionResult Create() //ปุ่มจอง สามารถตรวจสอบจากตาราง
        {
            return View();
        }

        public IActionResult Delete() //ลบรายการจอง สามารถตรวจสอบจากตาราง
        {
            return View();
        }

        #region API CALLS

        [HttpPatch]
        public IActionResult seatbooking(int seatId)
        {
            var seat = _unitOfWork.SeatRepo.Get(u => u.Id == seatId);
            
            if (seat == null)
            {
                return Json(new { success = false, message = "ไม่พบที่นั่งที่ระบุ" });
            }

            seat.IsAvailable = !seat.IsAvailable;
            _unitOfWork.SeatRepo.update(seat);
            _unitOfWork.Save();

            return Json(new { success = true, message = "อัปเดตสถานะเรียบร้อยแล้ว" });
            

        }

        #endregion

    }
}
