using System;
using AutoMapper;
using CarService.Common.ModelDto;
using CarService.Model;
using CarService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CarService.BusinessLogic.Services
{
    public class PurchaseHistoryService: IPurchaseHistoryService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;

        public PurchaseHistoryService(CarServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PurchaseHistoryDto> Get()
        {
            var history = _context.PurchaseHistories
                .AsNoTracking()
                .ToList();

            var historyDto = _mapper.Map<List<PurchaseHistoryDto>>(history);

            return historyDto;
        }

        public bool SyncDetail(int detailId)
        {
            var storeDetail = _context.DetailStores.FirstOrDefault(x => x.DetailId == detailId);

            if (storeDetail.Amount<0)
                return false;

            storeDetail.Amount = storeDetail.Amount - 1;

            var detail = _context.Details.Include(d=>d.Cost).AsNoTracking().FirstOrDefault(d => d.Id == detailId);

            var purchaseHistory = new PurchaseHistory
            {
                Name = detail.Name,
                Price = detail.Cost.Price,
                Img = "details/" + detail.Img
            };

            _context.PurchaseHistories.Add(purchaseHistory);
            _context.DetailStores.Update(storeDetail);
            return Save();
        }
        public bool SyncCar(int carId)
        {
            var storeCar = _context.CarStores.FirstOrDefault(x => x.CarId == carId);

            if (storeCar.Amount < 0)
                return false;
            storeCar.Amount = storeCar.Amount - 1;

            var car = _context.Cars.AsNoTracking().FirstOrDefault(d => d.Id == carId);

            var purchaseHistory = new PurchaseHistory
            {
                Name = car.Brand+ " "+ car.Model,
                Price = car.Cost,
                Img = "cars/" + car.Img
            };

            _context.PurchaseHistories.Add(purchaseHistory);
            _context.CarStores.Update(storeCar);

            return Save();
        }

        public bool Delete(int id)
        {
            var hirstory = _context.PurchaseHistories.FirstOrDefault(hp => hp.Id == id);

            _context.PurchaseHistories.Remove(hirstory);

            return Save();
        }

        private bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}

