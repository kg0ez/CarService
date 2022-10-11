using System;
using AutoMapper;
using CarService.Common.ModelDto;
using CarService.Model;
using CarService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CarService.BusinessLogic.Services
{
    public class CarService: ICarService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;

        public CarService(CarServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CarDto> Get()
        {
            var cars = _context.Cars.AsNoTracking().ToList();

            var carsDto = _mapper.Map<List<CarDto>>(cars);

            return carsDto;
        }

        public CarDto Get(int id)
        {
            var car = _context.Cars
                .Include(c => c.Characteristics)
                .Include(c=>c.AdditionalCharacteristic)
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);

            var carDto = _mapper.Map<CarDto>(car);
            return carDto;
        }

        public void Sync()
        {
            var car = new Car
            {
                Brand="BMW",
                Model="e39",
                Img = "01.jpeg",
                Cost = 22058,
                Characteristics = new Characteristic
                {
                    Transmission = "механика",
                    Carcase = "седан",
                    EngineType ="дизель",
                    DriveUnit = "передний привод",
                    Year = "2003",
                    Description = "бмв е39, только из Германии( покупалась у дилера Мюнхен) , в самом топовом цвете карбоншварц, выпуск 04.19 первая регистрация 05.19 , пробег оригинальный и подтвержден дилером бмв, растаможен на РФ, в заказной(максимальной) комплектации и состоянии нового авто! ",
                    Mileage = 150000
                },
                CarStore = new CarStore
                {
                    Amount = 2
                },
                AdditionalCharacteristic = new AdditionalCharacteristic
                {
                    SystemSecurity = "ABS, ESP, сигнализация, иммобилайзер, антипробуксовочная",
                    Pillow = "передние, боковые, задние",
                    SystemAssist= "датчик дождя, парктроники, контроль мертвых зон на зеркалах",
                    Comfort= "круиз-контроль, управление мультимедиа с руля, электрорегулировка сидений, передние электро-стеклоподъёмники, задние электро-стеклоподъёмники",
                    Heating="руля, зеркал, сидений",
                    Climate="климат-контроль, кондиционер",
                    Multimedia="AUX или iPod, Bluetooth, CD или MP3, USB, мультимедийный экран, штатная навигация",
                    Lights="Ксеноновые, противотуманные, светодиодные",
                }
                
            };
            _context.Cars.Add(car);
            _context.SaveChanges();
        }
    }
}

