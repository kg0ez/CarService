using System;
namespace CarService.Model.Models
{
    public class DetailStore:BaseStore
    {
        public int DetailId { get; set; }
        public Detail Detail { get; set; }
    }
}

