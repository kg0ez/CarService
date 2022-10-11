using System;
using AutoMapper;
using CarService.Common.ModelDto;
using CarService.Model;
using CarService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CarService.BusinessLogic.Services
{
    public class DetailService:IDetailService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;

        public DetailService(CarServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<DetailDto> Get()
        {
            var details = _context.Details
                .Include(d => d.Cost)
                .AsNoTracking()
                .ToList();

            var detailsDto = _mapper.Map<List<DetailDto>>(details);

            return detailsDto;
        }

        public DetailDto Get(int id)
        {
            var detail = _context.Details
                .Include(d=>d.Cost)
                .AsNoTracking()
                .FirstOrDefault(c => c.Id == id);

            var detailDto = _mapper.Map<DetailDto>(detail);
            return detailDto;
        }

        public void Sync()
        {
            var detail = new Detail
            {
                Name = "Ступица",
                Img = "ступица.png",
                Year = "2022",
                Description = "Ступица колеса — деталь, предназначена для установки колеса автомобиля на ось, именуемой цапфой. Подшипники ступицы, в таком соединении, являются ключевым элементом не только ступицы, но и всей ходовой части в целом, так как именно они отвечают за управляемость автомобилем и во многом обеспечивают безопасность водителя.",
                Weight = 960,
                Cost = new Cost
                {
                    Price = (decimal)14.60,
                    CostDelivery = 2,
                    TimeDelivery = "2 дня"
                },
                DetailStore = new DetailStore { Amount = 6 }
            };

            _context.Details.Add(detail);
            _context.SaveChanges();
        }
    }
}

