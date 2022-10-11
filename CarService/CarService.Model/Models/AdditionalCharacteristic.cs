using System;
namespace CarService.Model.Models
{
    public class AdditionalCharacteristic
    {
        public int Id { get; set; }

        public string SystemSecurity { get; set; } = null!;
        public string Pillow { get; set; } = null!;
        public string SystemAssist { get; set; } = null!;
        public string Comfort { get; set; } = null!;
        public string Heating { get; set; } = null!;
        public string Climate { get; set; } = null!;
        public string Multimedia { get; set; } = null!;
        public string Lights { get; set; } = null!;

        public Car Car { get; set; }
    }
}

