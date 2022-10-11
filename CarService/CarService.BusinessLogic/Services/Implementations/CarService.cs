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
            var cars = _context.Cars.ToList();

            var carsDto = _mapper.Map<List<CarDto>>(cars);

            return carsDto;
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
                }
                
            };
            _context.Cars.Add(car);
            _context.SaveChanges();
        }
    }
}

