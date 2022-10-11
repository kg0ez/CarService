using System;
using AutoMapper;
using CarService.Common.ModelDto;
using CarService.Model.Models;

namespace CarService.BusinessLogic.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Basket, BasketDto>().ReverseMap();
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<CarStore, CarStoreDto>().ReverseMap();
            CreateMap<Characteristic, CharacteristicDto>().ReverseMap();
            CreateMap<Cost, CostDto>().ReverseMap();
            CreateMap<Detail, DetailDto>().ReverseMap();
            CreateMap<DetailStore, DetailStoreDto>().ReverseMap();
            CreateMap<PurchaseHistory, PurchaseHistoryDto>().ReverseMap();
            CreateMap<AdditionalCharacteristic, AdditionalCharacteristicDto>().ReverseMap();
        }
    }
}

