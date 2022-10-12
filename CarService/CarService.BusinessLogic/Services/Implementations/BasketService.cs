using System;
using AutoMapper;
using CarService.Common.ModelDto;
using CarService.Model;
using CarService.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace CarService.BusinessLogic.Services
{
    public class BasketService: IBasketService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;

        public BasketService(CarServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Add(int detailId)
        {
            var basket = new Basket { DetailId = detailId };

            _context.Baskets.Add(basket);
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(int id)
        {
            var basket = _context.Baskets.FirstOrDefault(b => b.Id == id)!;

            _context.Baskets.Remove(basket);
            return _context.SaveChanges() > 0 ? true : false;
        }
        public int GetIdItem(int id)
        {
            var itemId = _context.Baskets.FirstOrDefault(b => b.Id == id)!.DetailId;
            return itemId;
        }
        public List<BasketDto> Get()
        {
            var basket = _context.Baskets
                .Include(b=>b.Detail)
                .ThenInclude(d=>d.Cost)
                .AsNoTracking()
                .ToList();

            var basketDto = _mapper.Map<List<BasketDto>>(basket);

            return basketDto;
        }
    }
}

