using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarBooking.Models
{
    
    public class Car
    {
        
        [Key]
        public int Id { get; set; }
        
        public string? CarName { get; set; }
        
        public string? CarType { get; set; }
        
        public int? TotalSeats { get; set; }
        public string? status { get; set; } //สถานะ (พร้อมใช้/ที่เต็มแล้ว/อยู่ระหว่างใช้งาน/กำลังซ่อม)

        public float?  pricePerKm { get; set; }  //ราคาต่อระยะทาง()
    }
   
}
