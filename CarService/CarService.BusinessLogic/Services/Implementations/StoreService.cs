using System;
using AutoMapper;
using CarService.Common.ModelDto;
using CarService.Model;
using Microsoft.EntityFrameworkCore;

namespace CarService.BusinessLogic.Services
{
    public class StoreService: IStoreService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;

        public StoreService(CarServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public StoreDto Get()
        {
            var detailsStore = _context.DetailStores
                .Include(ds => ds.Detail)
                .ThenInclude(d => d.Cost)
                .AsNoTracking()
                .ToList();
            var detailsStoreDto = _mapper.Map<List<DetailStoreDto>>(detailsStore);

            var carStore = _context.CarStores
                .Include(cs => cs.Car)
                .AsNoTracking()
                .ToList();
            var carsStoreDto = _mapper.Map<List<CarStoreDto>>(carStore);

            var storeDto = new StoreDto { CarStores = carsStoreDto, DetailStores = detailsStoreDto };

            return storeDto;
        }
    }
}

