using System;
namespace CarService.Model.Models
{
    public class Basket
    {
        public int Id { get; set; }

        public int DetailId { get; set; }
        public Detail Detail { get; set; }
    }
}

